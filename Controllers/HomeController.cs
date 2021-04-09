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

namespace INTEX2Mock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        RoleManager<IdentityRole> _roleManager;

        private MummyDbContext _mummyContext { get; set; }

        private int pageSize = 3;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, MummyDbContext mummyContext)
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

        

        public IActionResult ViewMummyRecords(int pageNum = 1)
        {
            return View(new SeeMummiesViewModel
            { 
                Mummies = (_mummyContext.Mummies
                .OrderBy(x => x.MummyID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (_mummyContext.Mummies.Count())
                }

            });

        // IQueryable<Mummy> mummy_DB = _mummyContext.Mummies;
        // return View(mummy_DB);
        }

        [HttpPost]
        public IActionResult ViewMummyRecords(Mummy passedMummy)
        {
            return View("EditMummyRecord", passedMummy);
        }

        public IActionResult AddMummyRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMummyRecord(Mummy newRecord)
        {
            if (ModelState.IsValid == true)
            {
                //Communicates with the sqlite database through the private context object to modify data in the database
                _mummyContext.Mummies.Add(newRecord);
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
        public IActionResult EditMummyRecord(Mummy passedMummy)
        {
            if (ModelState.IsValid == true)
            {
                    //Create an Iqueryable object that returns the one specific record that is being edited
                    IQueryable<Mummy> editingMummy = _mummyContext.Mummies.Where(p => p.MummyID == passedMummy.MummyID);

                    //loop to edit the data of the desired record
                    foreach (var x in editingMummy)
                    {
                        x.Name = passedMummy.Name;
                        x.Age = passedMummy.Age;
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
        public IActionResult RemoveRecord(Mummy passedMummy)
        {
            IQueryable<Mummy> removingRecord = _mummyContext.Mummies.Where(p => p.MummyID == passedMummy.MummyID);

            //loop to remove the record in the database
            foreach (var x in removingRecord)
            {
                _mummyContext.Mummies.Remove(x);
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
