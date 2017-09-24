using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BsacTimetableCore.Models;
using BsacTimetableCore.DBContextAndModelsfolder;

namespace BsacTimetableCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new bsac_timetableContext())
            {

                var tests = context.Group.Select(p => 
                new GroupViewModel{IdGroup = p.IdGroup,  NameGroup = p.NameGroup}).ToList();


                ViewBag.tests = tests;
            }


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
