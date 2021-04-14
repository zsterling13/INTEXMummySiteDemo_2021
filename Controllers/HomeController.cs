using INTEX2Mock.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using INTEX2Mock.Data;
using INTEX2Mock.Models.ViewModels;
using INTEX2Mock.Models.Searching;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace INTEX2Mock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        RoleManager<IdentityRole> _roleManager;

        //Initialize a few contexts and variables to be used throughout the home controller
        private PWOIKMContext _mummyContext { get; set; }
        public MainTable mainTableItem;
        public MummySearchLogic _mummySearchLogic { get; set; }

        //Initialize page size
        private int pageSize = 75;

        //Constructor for the Home Controller
        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, PWOIKMContext mummyContext)
        {
            _logger = logger;
            _roleManager = roleManager;
            _mummyContext = mummyContext;
        }

        //Returns the homepage
        public IActionResult Index()
        {
            return View();
        }

        //Get method to easily show all mummy records in an enumerated table
        public IActionResult ViewMummyRecords(MummySearchModel? searchModel, int pageNum = 1)
        {
            //initialize a few variables to be used in the later business logic
            var mummyLogic = new MummySearchLogic(_mummyContext);
            int nullProps = 0;

            //Logic to determine whether there are any filters being used
            Type type = typeof(MummySearchModel);
            PropertyInfo[] propertyInfo = searchModel.GetType().GetProperties();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if(property.GetValue(searchModel, null) == null)
                {
                    nullProps = nullProps + 1;
                }
            }

            bool emptyFilter = false;

            if(nullProps == properties.Count())
            {
                emptyFilter = true;
            }

            //If statement to determine whether to try to filter or not
            if (emptyFilter == false)
            {
                //Create a modified query based on the search model that is filled in by the filters on the page
                var queryModel = mummyLogic.GetMummies(searchModel);
                
                //return the view with the necessary queried list and other necessary models
                return View(new SeeMummiesViewModel
                {
                    Mummies = (queryModel
                    .OrderBy(x => x.PrimaryKeyId)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                    PageNumberingInfo = new PageNumberingInfo
                    {
                        NumItemsPerPage = pageSize,
                        CurrentPage = pageNum,
                        TotalNumItems = (queryModel.Count())
                    },

                    mummySearchModel = searchModel,

                    UrlInfo = Request.QueryString.Value

                }); 
            }
            else
            {
                //If there are no filters being used then return an unfiltered list of all possible records
                //along with other necessary models
                return View(new SeeMummiesViewModel
                {
                    Mummies = (_mummyContext.MainTables
                    .OrderBy(x => x.PrimaryKeyId)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                    PageNumberingInfo = new PageNumberingInfo
                    {
                        NumItemsPerPage = pageSize,
                        CurrentPage = pageNum,
                        TotalNumItems = (_mummyContext.MainTables.Count())
                    },

                    mummySearchModel = searchModel

                });
            }
        }

        //Post action that passes in the necessary info into an edit form for the specified record
        [HttpPost]
        public IActionResult ViewMummyRecords(MainTable passedMummy)
        {
            return View("EditMummyRecord", passedMummy);
        }

        //Action that takes a user to an empty form for adding a record
        [Authorize(Policy = "writepolicy")]
        [HttpGet]
        public IActionResult AddMummyRecord()
        {
            return View();
        }

        //Action to submit a new record
        [Authorize(Policy = "writepolicy")]
        [HttpPost]
        public IActionResult AddMummyRecord(MainTable newRecord)
        {
            //Logic to ensure that the submitted record is assigned the largest primarykeyId
            var wumbo = _mummyContext.MainTables.OrderByDescending(x => x.PrimaryKeyId).FirstOrDefault();
            newRecord.PrimaryKeyId = wumbo.PrimaryKeyId + 1;

            //Submit the info for the database to store
            if (ModelState.IsValid == true)
            {
                //Communicates with the sqlite database through the private context object to modify data in the database
                _mummyContext.MainTables.Add(newRecord);
                _mummyContext.SaveChanges();

                return View("Confirmation", newRecord);
            }

            //If there are missing fields or incorrect fields then reload the page with errors for the user to see
            else
            {
                //Reload the page in a way that allows mistyped info to be called-out
                return View();
            }
        }

        //Initial action that populates info for the selected mummy record in the edit form
        [Authorize(Policy = "writepolicy")]
        [HttpGet]
        public IActionResult EditMummyRecord(MainTable recordInfo)
        {
            var returnedRecordInfo = _mummyContext.MainTables.Where(x => x.PrimaryKeyId == recordInfo.PrimaryKeyId);

            MainTable passedInInfo = mainTableItem;
            foreach(var x in returnedRecordInfo)
            {
                passedInInfo = x;
            }

            return View(passedInInfo);
        }

        //Action that submits changes in the edit form for the database to process
        [Authorize(Policy = "writepolicy")]
        [HttpPost]
        public IActionResult EditMummyRecordPost(MainTable passedMummy)
        {
            if (ModelState.IsValid == true)
            {
                    //Create an Iqueryable object that returns the one specific record that is being edited
                    IQueryable<MainTable> editedMummy = _mummyContext.MainTables.Where(p => p.PrimaryKeyId == passedMummy.PrimaryKeyId);

                    //loop to edit the data of the desired record
                    foreach (var x in editedMummy)
                    {
                        x.BurialLocationNs = passedMummy.BurialLocationNs;
                        x.BurialLocationEw = passedMummy.BurialLocationEw;
                        x.LowPairNs = passedMummy.LowPairNs;
                        x.HighPairNs = passedMummy.HighPairNs;
                        x.LowPairEw = passedMummy.LowPairEw;
                        x.HighPairEw = passedMummy.HighPairEw;
                        x.BurialSubplot = passedMummy.BurialSubplot;
                        x.BurialNumber = passedMummy.BurialNumber;
                        x.BurialDepth = passedMummy.BurialDepth;
                        x.FieldBook = passedMummy.FieldBook;
                        x.FieldBookPageNum = passedMummy.FieldBookPageNum;
                        x.InitialOfDataExpert = passedMummy.InitialOfDataExpert;
                        x.InitialsChecker = passedMummy.InitialsChecker;
                        x.BodyAnalyzeYear = passedMummy.BodyAnalyzeYear;
                        x.SouthToHead = passedMummy.SouthToHead;
                        x.SouthToFeet = passedMummy.SouthToFeet;
                        x.EastToHead = passedMummy.EastToHead;
                        x.EastToFeet = passedMummy.EastToFeet;
                        x.WestToHead = passedMummy.WestToHead;
                        x.WestToFeet = passedMummy.WestToFeet;
                        x.BurialSituation = passedMummy.BurialSituation;
                        x.LengthOfRemains = passedMummy.LengthOfRemains;
                        x.SampleNumber = passedMummy.SampleNumber;
                        x.GeFunctionTotal = passedMummy.GeFunctionTotal;
                        x.GenderBodyCol = passedMummy.GenderBodyCol;
                        x.HowGenderDetermined = passedMummy.HowGenderDetermined;
                        x.BasilarSuture = passedMummy.BasilarSuture;
                        x.VentralArc = passedMummy.VentralArc;
                        x.SubpubicAngle = passedMummy.SubpubicAngle;
                        x.SciaticNotch = passedMummy.SciaticNotch;
                        x.PubicBone = passedMummy.PubicBone;
                        x.PreaurSulcus = passedMummy.PreaurSulcus;
                        x.MedialIpRamus = passedMummy.MedialIpRamus;
                        x.DorsalPitting = passedMummy.DorsalPitting;
                        x.ForemanMagnum = passedMummy.ForemanMagnum;
                        x.FemurHead = passedMummy.FemurHead;
                        x.HumerusHead = passedMummy.HumerusHead;
                        x.Osteophytosis = passedMummy.Osteophytosis;
                        x.PubicSymphysis = passedMummy.PubicSymphysis;
                        x.BoneLength = passedMummy.BoneLength;
                        x.MedialClavicle = passedMummy.MedialClavicle;
                        x.IliacCrest = passedMummy.IliacCrest;
                        x.FemurDiameter = passedMummy.FemurDiameter;
                        x.Humerus = passedMummy.Humerus;
                        x.FemurLength = passedMummy.FemurLength;
                        x.HumerusLength = passedMummy.HumerusLength;
                        x.TibiaLength = passedMummy.TibiaLength;
                        x.Robust = passedMummy.Robust;
                        x.SupraorbitalRidges = passedMummy.SupraorbitalRidges;
                        x.OrbitEdge = passedMummy.OrbitEdge;
                        x.ParietalBossing = passedMummy.ParietalBossing;
                        x.Gonian = passedMummy.Gonian;
                        x.NuchalCrest = passedMummy.NuchalCrest;
                        x.ZygomaticCrest = passedMummy.ZygomaticCrest;
                        x.CranialSuture = passedMummy.CranialSuture;
                        x.MaximumCranialLength = passedMummy.MaximumCranialLength;
                        x.MaximumCranialBreadth = passedMummy.MaximumCranialBreadth;
                        x.BasionBregmaHeight = passedMummy.BasionBregmaHeight;
                        x.BasionNasion = passedMummy.BasionNasion;
                        x.BasionProsthionLength = passedMummy.BasionProsthionLength;
                        x.BizygomaticDiameter = passedMummy.BizygomaticDiameter;
                        x.NasionProsthion = passedMummy.NasionProsthion;
                        x.MaximumNasalBreadth = passedMummy.MaximumNasalBreadth;
                        x.InterorbitalBreadth = passedMummy.InterorbitalBreadth;
                        x.ArtifactsDescription = passedMummy.ArtifactsDescription;
                        x.HairColor = passedMummy.HairColor;
                        x.PreservationIndex = passedMummy.PreservationIndex;
                        x.HairTaken = passedMummy.HairTaken;
                        x.SoftTissueTaken = passedMummy.SoftTissueTaken;
                        x.BoneTaken = passedMummy.BoneTaken;
                        x.ToothTaken = passedMummy.ToothTaken;
                        x.TextileTaken = passedMummy.TextileTaken;
                        x.DescriptionOfTaken = passedMummy.DescriptionOfTaken;
                        x.ArtifactFound = passedMummy.ArtifactFound;
                        x.AgeMethod = passedMummy.AgeMethod;
                        x.EstimateAge = passedMummy.EstimateAge;
                        x.AgeClassification = passedMummy.AgeClassification;
                        x.EstimateLivingStature = passedMummy.EstimateLivingStature;
                        x.ToothAttrition = passedMummy.ToothAttrition;
                        x.ToothEruption = passedMummy.ToothEruption;
                        x.PathologyAnomalies = passedMummy.PathologyAnomalies;
                        x.EpiphysealUnion = passedMummy.EpiphysealUnion;
                        x.YearFound = passedMummy.YearFound;
                        x.MonthFound = passedMummy.MonthFound;
                        x.DayFound = passedMummy.DayFound;
                        x.HeadDirection = passedMummy.HeadDirection;
                        x.Rack = passedMummy.Rack;
                        x.CribraOrbitala = passedMummy.CribraOrbitala;
                        x.PoroticHyperostosis = passedMummy.PoroticHyperostosis;
                        x.PoroticHyperostosisLocations = passedMummy.PoroticHyperostosisLocations;
                        x.MetopicSuture = passedMummy.MetopicSuture;
                        x.ButtonOsteoma = passedMummy.ButtonOsteoma;
                        x.PostcraniaTrauma = passedMummy.PostcraniaTrauma;
                        x.OsteologyUnknownComment = passedMummy.OsteologyUnknownComment;
                        x.TemporalMandibularJointOsteoarthritisTmjOa = passedMummy.TemporalMandibularJointOsteoarthritisTmjOa;
                        x.LinearHypoplasiaEnamel = passedMummy.LinearHypoplasiaEnamel;
                        x.LinearHypoplasiaEnamel = passedMummy.LinearHypoplasiaEnamel;
                        x.AreaHillBurials = passedMummy.AreaHillBurials;
                        x.Tomb = passedMummy.Tomb;
                        x.YearOnSkull = passedMummy.YearOnSkull;
                        x.MonthOnSkull = passedMummy.MonthOnSkull;
                        x.DateOnSkull = passedMummy.DateOnSkull;
                        x.Cluster = passedMummy.Cluster;
                        x.Notes = passedMummy.Notes;
                        x.Shaft = passedMummy.Shaft;
                        x.SharedShaft = passedMummy.SharedShaft;
                        x.PreservationIndex2 = passedMummy.PreservationIndex2;
                        x.BurialMaterials = passedMummy.BurialMaterials;
                        x.BurialGoods = passedMummy.BurialGoods;
                        x.Photo = passedMummy.Photo;
                        x.BurialId = passedMummy.BurialId;
                    }

                    _mummyContext.SaveChanges();

                    //Then return a customized confirmation page that confirms that the record has been modified/edited
                    return View("Confirmation", passedMummy);
            }

            //If there are missing fields or incorrect fields then reload the page with errors for the user to see
            else
            {
                return View(passedMummy);
            }
        }

        //Action that redirects the user to a page for them to confirm that they want to delete the specified record
        [Authorize(Policy = "managepolicy")]
        public IActionResult DeleteMummyRecord(MainTable passedMummy)
            {
                return View(passedMummy);
            }

        //Action that works with the database to eliminate the specified record
        [Authorize(Policy = "managepolicy")]
        [HttpPost]
        public IActionResult EliminateRecord(MainTable passedMummy)
        {

            //Find the right record to delete
            IQueryable<MainTable> removingRecord = _mummyContext.MainTables.Where(p => p.PrimaryKeyId == passedMummy.PrimaryKeyId);

            //loop to remove the record in the database
            foreach (var x in removingRecord)
            {
                _mummyContext.MainTables.Remove(x);
            }

            //Submit changes for the database to process
            _mummyContext.SaveChanges();

            //Redirect to the confirmation page for the user to know that everything was successful
            return View("Confirmation", passedMummy);
        }

        //Action that allows for a user to view all of the details for the specified record
        [HttpPost]
        public async Task<IActionResult> MummyRecordDetails(MainTable mainTable)
        {
            if (mainTable == null)
            {
                return NotFound();
            }

            //Queried object that is equal to the selected record
            var mummy = await _mummyContext.MainTables
                .FirstOrDefaultAsync(m => m.PrimaryKeyId == mainTable.PrimaryKeyId);
            if (mummy == null)
            {
                return NotFound();
            }

            return View(mummy);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
