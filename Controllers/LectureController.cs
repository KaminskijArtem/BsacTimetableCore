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
            IAcessoryService service = new AcessoryService();
            ViewData["currWeek"] = service.GetCurrentWeek();
            ViewData["lectureName"] = (from p in _context.Lecturer
                                     where p.IdLecturer == id
                                     select p.NameLecturer).First();

            var records = (from r in _context.Record
                           join l in _context.Group on r.IdGroup equals l.IdGroup
                           join s in _context.Subject on r.IdSubject equals s.IdSubject
                           join c in _context.Classroom on r.IdClassroom equals c.IdClassroom
                           where (r.IdLecturer == id)

                           //    && (r.DateTo >= DateTime.Today && r.DateFrom <= DateTime.Today)
                           orderby r.WeekDay, r.SubjOrdinalNumber, r.WeekNumber
                           select new LectureRecordViewModel
                            {
                                IdRecord = r.IdRecord,
                                WeekDay = r.WeekDay,
                                WeekNumber = r.WeekNumber,
                                GroupName = l.NameGroup,
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
