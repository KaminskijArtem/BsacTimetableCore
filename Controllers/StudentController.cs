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
        public IActionResult Index(string searchString, int? page)
        {
            ViewData["searchString"] = searchString;
            var groups = (from p in _context.Group 
            select new GroupViewModel{IdGroup = p.IdGroup,  NameGroup = p.NameGroup});

            if (!String.IsNullOrEmpty(searchString))
            {
                groups = groups.Where(g => g.NameGroup.Contains(searchString));
            }

            return View(PaginatedList<GroupViewModel>.Create(groups, page ?? 1, 10));
        }
        
        public IActionResult DetailsCurrWeek(int idgroup, int subgroup)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
