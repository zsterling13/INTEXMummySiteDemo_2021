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

namespace INTEX2Mock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        RoleManager<IdentityRole> _roleManager;

        private PWOIKMContext _mummyContext { get; set; }

        public MainTable mainTableItem;

        public MummySearchLogic _mummySearchLogic { get; set; }

        private int pageSize = 3;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, PWOIKMContext mummyContext)
        {
            _logger = logger;
            _roleManager = roleManager;
            _mummyContext = mummyContext;
        }

        //[Authorize(Policy = "readpolicy")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewMummyRecords(MummySearchModel? searchModel, int pageNum = 1)
        {
            var mummyLogic = new MummySearchLogic(_mummyContext);
            int nullProps = 0;

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

            if (emptyFilter == false)
            {
                var queryModel = mummyLogic.GetMummies(searchModel);

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

        [HttpPost]
        public IActionResult ViewMummyRecords(MainTable passedMummy)
        {
            return View("EditMummyRecord", passedMummy);
        }

        public IActionResult AddMummyRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMummyRecord(MainTable newRecord)
        {
            if (ModelState.IsValid == true)
            {
                //Communicates with the sqlite database through the private context object to modify data in the database
                _mummyContext.MainTables.Add(newRecord);
                _mummyContext.SaveChanges();

                return View("Confirmation", newRecord);
            }
            else
            {
                //Reload the page in a way that allows mistyped info to be called-out
                return View();
            }
        }

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
                    //    public string InitialOfDataExpert { get; set; }
                    //    public string InitialsChecker { get; set; }
                    //    public string BodyAnalyzeYear { get; set; }
                    //    public string SouthToHead { get; set; }
                    //    public string SouthToFeet { get; set; }
                    //    public string EastToHead { get; set; }
                    //    public string EastToFeet { get; set; }
                    //    public string WestToHead { get; set; }
                    //    public string WestToFeet { get; set; }
                    //    public string BurialSituation { get; set; }
                    //    public string LengthOfRemains { get; set; }
                    //    public int? SampleNumber { get; set; }
                    //    public string GeFunctionTotal { get; set; }
                    //    public string GenderBodyCol { get; set; }
                    //    public string HowGenderDetermined { get; set; }
                    //    public string BasilarSuture { get; set; }
                    //    public string VentralArc { get; set; }
                    //    public string SubpubicAngle { get; set; }
                    //    public string SciaticNotch { get; set; }
                    //    public string PubicBone { get; set; }
                    //    public string PreaurSulcus { get; set; }
                    //    public string MedialIpRamus { get; set; }
                    //    public string DorsalPitting { get; set; }
                    //    public string ForemanMagnum { get; set; }
                    //    public string FemurHead { get; set; }
                    //    public string HumerusHead { get; set; }
                    //    public string Osteophytosis { get; set; }
                    //    public string PubicSymphysis { get; set; }
                    //    public string BoneLength { get; set; }
                    //    public string MedialClavicle { get; set; }
                    //    public string IliacCrest { get; set; }
                    //    public string FemurDiameter { get; set; }
                    //    public string Humerus { get; set; }
                    //    public string FemurLength { get; set; }
                    //    public string HumerusLength { get; set; }
                    //    public string TibiaLength { get; set; }
                    //    public string Robust { get; set; }
                    //    public string SupraorbitalRidges { get; set; }
                    //    public string OrbitEdge { get; set; }
                    //    public string ParietalBossing { get; set; }
                    //    public string Gonian { get; set; }
                    //    public string NuchalCrest { get; set; }
                    //    public string ZygomaticCrest { get; set; }
                    //    public string CranialSuture { get; set; }
                    //    public string MaximumCranialLength { get; set; }
                    //    public string MaximumCranialBreadth { get; set; }
                    //    public string BasionBregmaHeight { get; set; }
                    //    public string BasionNasion { get; set; }
                    //    public string BasionProsthionLength { get; set; }
                    //    public string BizygomaticDiameter { get; set; }
                    //    public string NasionProsthion { get; set; }
                    //    public string MaximumNasalBreadth { get; set; }
                    //    public string InterorbitalBreadth { get; set; }
                    //    public string ArtifactsDescription { get; set; }
                    //    public string HairColor { get; set; }
                    //    public string PreservationIndex { get; set; }
                    //    public bool? HairTaken { get; set; }
                    //    public bool? SoftTissueTaken { get; set; }
                    //    public bool? BoneTaken { get; set; }
                    //    public bool? ToothTaken { get; set; }
                    //    public bool? TextileTaken { get; set; }
                    //    public string DescriptionOfTaken { get; set; }
                    //    public bool? ArtifactFound { get; set; }
                    //    public string AgeMethod { get; set; }
                    //    public string EstimateAge { get; set; }
                    //    public string AgeClassification { get; set; }
                    //    public string EstimateLivingStature { get; set; }
                    //    public string ToothAttrition { get; set; }
                    //    public string ToothEruption { get; set; }
                    //    public string PathologyAnomalies { get; set; }
                    //    public string EpiphysealUnion { get; set; }
                    //    public string YearFound { get; set; }
                    //    public string MonthFound { get; set; }
                    //    public string DayFound { get; set; }
                    //    public string HeadDirection { get; set; }
                    //    public string Rack { get; set; }
                    //    public string CribraOrbitala { get; set; }
                    //    public string PoroticHyperostosis { get; set; }
                    //    public string PoroticHyperostosisLocations { get; set; }
                    //    public string MetopicSuture { get; set; }
                    //    public string ButtonOsteoma { get; set; }
                    //    public string PostcraniaTrauma { get; set; }
                    //    public string OsteologyUnknownComment { get; set; }
                    //    public string TemporalMandibularJointOsteoarthritisTmjOa { get; set; }
                    //    public string LinearHypoplasiaEnamel { get; set; }
                    //    public string AreaHillBurials { get; set; }
                    //    public string Tomb { get; set; }
                    //    public string YearOnSkull { get; set; }
                    //    public string MonthOnSkull { get; set; }
                    //    public string DateOnSkull { get; set; }
                    //    public string Cluster { get; set; }
                    //    public string Notes { get; set; }
                    //    public string Shaft { get; set; }
                    //    public string SharedShaft { get; set; }
                    //    public string PreservationIndex2 { get; set; }
                    //    public string BurialMaterials { get; set; }
                    //    public string BurialGoods { get; set; }
                    //    public string Photo { get; set; }
                    }

                    _mummyContext.SaveChanges();

                    //Then return a customized confirmation page that confirms that the record has been modified/edited
                    return View("Confirmation", passedMummy);
            }
            else
            {
                return View(passedMummy);
            }
        }

        public IActionResult DeleteMummyRecord(MainTable passedMummy)
            {
                return View(passedMummy);
            }

        [HttpPost]
        public IActionResult EliminateRecord(MainTable passedMummy)
        {
            IQueryable<MainTable> removingRecord = _mummyContext.MainTables.Where(p => p.PrimaryKeyId == passedMummy.PrimaryKeyId);

            //loop to remove the record in the database
            foreach (var x in removingRecord)
            {
                _mummyContext.MainTables.Remove(x);
            }

            _mummyContext.SaveChanges();

            return View("Confirmation", passedMummy);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
