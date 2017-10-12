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
    public class LectureController : Controller
    {
        private readonly bsac_timetableContext _context;

        public LectureController(bsac_timetableContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searchString, int? page)
        {
            ViewData["searchString"] = searchString;
            var lecturers = (from p in _context.Lecturer 
            select new LectureViewModel{IdLecturer = p.IdLecturer,  NameLecturer = p.NameLecturer});

            if (!String.IsNullOrEmpty(searchString))
            {
                lecturers = lecturers.Where(g => g.NameLecturer.Contains(searchString));
            }

            return View(PaginatedList<LectureViewModel>.Create(lecturers, page ?? 1, 10));
        }
        
        public IActionResult DetailsWeek(int id)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
