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
                          orderby p.IdGroup
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

            var sgId = subgroup + 2;//IDK why, but it shoud be before linq

            var records = (from r in _context.Record
                           join l in _context.Lecturer on r.IdLecturer equals l.IdLecturer
                           join s in _context.Subject on r.IdSubject equals s.IdSubject
                           join c in _context.Classroom on r.IdClassroom equals c.IdClassroom
                           where (r.IdGroup == idgroup) &&
                           new[] { sgId, 1, 2 }.Contains(r.IdSubjectFor)

                           //    && (r.DateTo >= DateTime.Today && r.DateFrom <= DateTime.Today)
                           orderby r.WeekDay, r.SubjOrdinalNumber, r.WeekNumber
                           select new StudentRecordViewModel
                            {
                                IdRecord = r.IdRecord,
                                WeekDay = r.WeekDay,
                                WeekNumber = r.WeekNumber,
                                LectureName = l.NameLecturer,
                                SubjectName = s.AbnameSubject,
                                SubjOrdinalNumber = r.SubjOrdinalNumber,
                                Classroom = c.Name + " (к." + c.Building + ")",
                                IdSubjectType = r.IdSubjectType
                            }
            ).ToList();

            return View(records);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
