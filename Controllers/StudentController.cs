using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BsacTimetableCore.Models;
using BsacTimetableCore.DBContextAndModelsfolder;
using BsacTimetableCore.Services;

namespace BsacTimetableCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly bsac_timetableContext _context;

        public StudentController(bsac_timetableContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var groups = (from p in _context.Group 
            select new GroupViewModel{IdGroup = p.IdGroup,  NameGroup = p.NameGroup}).ToList();

            ViewBag.groups = groups;

            IAcessoryService service = new AcessoryService();
            var a = service.GetCurrentWeek();

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
