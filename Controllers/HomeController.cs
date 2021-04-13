﻿using INTEX2Mock.Models;
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

        private PWOIKMContext _mummyContext { get; set; }

        public MummySearchLogic _mummySearchLogic { get; set; }

        private int pageSize = 75;

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
        public IActionResult ViewMummyRecords(PWOIKMContext passedMummy)
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

        [HttpPost]
        public IActionResult EditMummyRecord(MainTable passedMummy)
        {
            if (ModelState.IsValid == true)
            {
                    //Create an Iqueryable object that returns the one specific record that is being edited
                    IQueryable<MainTable> editingMummy = _mummyContext.MainTables.Where(p => p.PrimaryKeyId == passedMummy.PrimaryKeyId);

                    //loop to edit the data of the desired record
                    foreach (var x in editingMummy)
                    {
                        //x.Name = passedMummy.Name;
                        //x.Age = passedMummy.Age;
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

        [HttpPost]
        public IActionResult RemoveRecord(MainTable passedMummy)
        {
            IQueryable<MainTable> removingRecord = _mummyContext.MainTables.Where(p => p.PrimaryKeyId == passedMummy.PrimaryKeyId);

            //loop to remove the record in the database
            foreach (var x in removingRecord)
            {
                //_mummyContext.Mummies.Remove(x);
            }

            _mummyContext.SaveChanges();

            return View("Confirmation", passedMummy);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: shows details for the quote
        [HttpPost]
        public async Task<IActionResult> MummyRecordDetails(MainTable mainTable)
        {
            if (mainTable == null)
            {
                return NotFound();
            }

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
