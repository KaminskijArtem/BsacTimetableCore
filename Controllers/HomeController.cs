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
        private readonly bsac_timetableContext _context;

        public HomeController(bsac_timetableContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            

            var ss = (from s in _context.Faculty 
                join sa in _context.Group 
                on s.IdFaculty equals sa.IdFaculty
                select new {s.NameFaculty, s.IdFaculty, sa.NameGroup, sa.IdGroup, IdFaculty2 = sa.IdFaculty}).ToList();//Test Join

            var tests = (from p in _context.Group 
            select new GroupViewModel{IdGroup = p.IdGroup,  NameGroup = p.NameGroup}).ToList();


            ViewBag.tests = tests;

            var cns = (from s in _context.Record select s).ToList(); // (date test);

            //Faculty newFaculty = new Faculty{NameFaculty = "TestFuck"};
            //_context.Faculty.Add(newFaculty);
            
            Cancellation newStudent = new Cancellation{
                IdRecord = 40, 
                DateFrom = new DateTime(1000),
                DateTo = new DateTime(1000)};

            _context.Cancellation.Add(newStudent);
            var a = _context.SaveChanges();
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
