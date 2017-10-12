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
                          select new GroupViewModel { IdGroup = p.IdGroup, NameGroup = p.NameGroup });

            if (!String.IsNullOrEmpty(searchString))
            {
                groups = groups.Where(g => g.NameGroup.Contains(searchString));
            }

            return View(PaginatedList<GroupViewModel>.Create(groups, page ?? 1, 10));
        }

        public IActionResult DetailsWeek(int idgroup, int subgroup)
        {
            IAcessoryService service = new AcessoryService();
            ViewData["currWeek"] = service.GetCurrentWeek();
            ViewData["subgroup"] = subgroup;
            ViewData["groupName"] = (from p in _context.Group
                                     where p.IdGroup == idgroup
                                     select p.NameGroup).First();

            var records = (from r in _context.Record
                            join l in _context.Lecturer on r.IdLecturer equals l.IdLecturer
                           where r.IdGroup == idgroup
                           select new StudentRecordViewModel { IdRecord = r.IdRecord, WeekDay = r.WeekDay, WeekNumber = r.WeekNumber, LectureName = l.NameLecturer}
            ).ToList();

            return View(records);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
