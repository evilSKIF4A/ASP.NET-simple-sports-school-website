using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Sport_school_Fortune.Data;
using Sport_school_Fortune.Models;
using Sport_school_Fortune.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_school_Fortune.Controllers
{
    public class HomeController : Controller
    {
        SchoolContext db;
        public HomeController(SchoolContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TrainerSport()
        {
            TrainerSportViewModel obj = new TrainerSportViewModel();
            obj.allTrainer = db.Trainers.OrderBy(p => p.f_name);
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpPost]
        public ActionResult TrainerSport(string filter, string filter2, string filter3, string filter4)
        {
            TrainerSportViewModel obj = new TrainerSportViewModel();
            if (filter != null || filter2 != null || filter3 != null || filter4 != null)
            {
                IEnumerable<Trainer> trainer = db.Trainers;
                if (filter != null)
                    trainer = trainer.Where(x => x.f_name.Contains(filter)).ToArray();
                if (filter2 != null)
                    trainer = trainer.Where(x => x.s_name.Contains(filter2)).ToArray();
                if (filter3 != null)
                    trainer = trainer.Where(x => x.m_name.Contains(filter3)).ToArray();

                IEnumerable<Sport> sports = db.Sports;
                if (filter4 != null)
                    sports = sports.Where(x => x.sport_name.Contains(filter4));

                List<Trainer> trai = new List<Trainer>();
                trai = (List<Trainer>)trai.AsEnumerable();
                foreach (var tr in trainer)
                {
                    foreach(var s in sports)
                    {
                        if (tr.sportId == s.Id)
                            trai.Add(tr);
                    }
                }

                obj.allTrainer = trai.OrderBy(p => p.f_name);
                obj.allSport = db.Sports;
            }
            else
            {
                obj.allTrainer = db.Trainers.OrderBy(p => p.f_name);
                obj.allSport = db.Sports;
            }

            return View(obj);
        }

        public ActionResult Sport()
        {
            SportViewModel obj = new SportViewModel();
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpGet]
        public ActionResult Journal()
        {
            JournalViewModel obj = new JournalViewModel();
            obj.allJournal = db.Journals;
            obj.allSportsman = db.Sportsmans.OrderBy(p => p.f_name);
            obj.allSport = db.Sports;
            obj.allTrainer = db.Trainers;
            return View(obj);
        }
        [HttpPost]
        public ActionResult Journal(string filter, string filter2, string filter3, string filter4)
        {
            JournalViewModel obj = new JournalViewModel(); 
            if(filter != null || filter2 != null || filter3 != null || filter4 != null)
            {
                IEnumerable<Sportsman> sportsmen = db.Sportsmans;
                if (filter != null)
                    sportsmen = sportsmen.Where(x => x.f_name.Contains(filter)).ToArray();
                if (filter2 != null)
                    sportsmen = sportsmen.Where(x => x.s_name.Contains(filter2)).ToArray();
                if (filter3 != null)
                    sportsmen = sportsmen.Where(x => x.m_name.Contains(filter3)).ToArray();

                IEnumerable<Sport> sports = db.Sports;
                if (filter4 != null)
                    sports = sports.Where(x => x.sport_name.Contains(filter4));
                List<Journal> jour = new List<Journal>();
                jour = (List<Journal>)jour.AsEnumerable();
                foreach(var sp in sportsmen)
                {
                    foreach(var j in db.Journals.AsEnumerable())
                    {
                        if(sp.Id == j.sportsmanId)
                        {
                            foreach(var s in sports)
                            {
                                if(j.sportId == s.Id)
                                    jour.Add(j);
                            }
                        }
                    }
                }
                obj.allJournal = jour;
                obj.allSportsman = db.Sportsmans;
                obj.allSport = db.Sports;
                obj.allTrainer = db.Trainers;
            }
            else
            {
                obj.allJournal = db.Journals;
                obj.allSportsman = db.Sportsmans;
                obj.allSport = db.Sports;
                obj.allTrainer = db.Trainers;
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Activity()
        {
            ActivityViewModel obj = new ActivityViewModel();
            obj.allActivity = db.Activitys.OrderBy(p => p.sportId);
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Activity(string filter)
        {
            ActivityViewModel obj = new ActivityViewModel();
            if(filter != null) {
                IEnumerable<Sport> sport = db.Sports;
                if (filter != null)
                    sport = sport.Where(x => x.sport_name.Contains(filter)).ToArray();

                List<Activity> act = new List<Activity>();
                act = (List<Activity>)act.AsEnumerable();
                foreach (var s in sport)
                {
                    foreach (var ac in db.Activitys.AsEnumerable())
                    {
                        if (s.Id == ac.sportId)
                        {
                            act.Add(ac);
                        }
                    }
                }
                obj.allActivity = act;
                obj.allSport = db.Sports;
            }
            else
            {
                obj.allActivity = db.Activitys;
                obj.allSport = db.Sports;
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Member()
        {
            MemberViewModel obj = new MemberViewModel();
            obj.allMember = db.Members;
            obj.allSportsman = db.Sportsmans;
            obj.allActivity = db.Activitys;
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Member(string filter, string filter2, string filter3, string filter4)
        {
            MemberViewModel obj = new MemberViewModel();
            if (filter != null || filter2 != null || filter3 != null || filter4 != null)
            {
                IEnumerable<Sportsman> sportsmen = db.Sportsmans;
                if (filter != null)
                    sportsmen = sportsmen.Where(x => x.f_name.Contains(filter)).ToArray();
                if (filter2 != null)
                    sportsmen = sportsmen.Where(x => x.s_name.Contains(filter2)).ToArray();
                if (filter3 != null)
                    sportsmen = sportsmen.Where(x => x.m_name.Contains(filter3)).ToArray();

                IEnumerable<Sport> sports = db.Sports;
                if (filter4 != null)
                    sports = sports.Where(x => x.sport_name.Contains(filter4));
                List<Member> memb = new List<Member>();
                memb = (List<Member>)memb.AsEnumerable();
                foreach (var sp in sportsmen)
                {
                    foreach (var m in db.Members.AsEnumerable())
                    {
                        if (sp.Id == m.sportsmanId)
                        {
                            foreach (var ac in db.Activitys.AsEnumerable())
                            {
                                if(m.activityId == ac.Id)
                                {
                                    foreach (var s in sports)
                                    {
                                        if (ac.sportId == s.Id)
                                        {
                                            memb.Add(m);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                obj.allMember = memb;
                obj.allSportsman = db.Sportsmans;
                obj.allActivity = db.Activitys;
                obj.allSport = db.Sports;
            }
            else
            {
                obj.allMember = db.Members;
                obj.allSportsman = db.Sportsmans;
                obj.allActivity = db.Activitys;
                obj.allSport = db.Sports;
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            TrainerSportViewModel obj = new TrainerSportViewModel();
            obj.allTrainer = db.Trainers;
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Registration(string SpFname, string SpSname, string SpMname, string SpGender, DateTime SpBirthday, int SpPhone, int SpHeight, int SpWeight, int trainerid)
        {
            db.Sportsmans.AddRange(
                new Sportsman
                {
                    f_name = SpFname,
                    s_name = SpSname,
                    m_name = SpMname,
                    gender = SpGender,
                    birthday = SpBirthday.ToShortDateString(),
                    phone = SpPhone,
                    height = SpHeight,
                    weight = SpWeight
                }
                );
            db.SaveChanges();


            Trainer lastTrainer = db.Trainers.FirstOrDefault(p => p.Id == trainerid);
            db.Journals.AddRange(
                new Journal
                {
                    sportsmanId = db.Sportsmans.Max(c => c.Id),
                    sportId = lastTrainer.sportId,
                    trainerId = trainerid
                }
                );
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddActivity()
        {
            SportViewModel obj = new SportViewModel();
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddActivity(int sportid, DateTime ActivityDate, string ActivityName)
        {
            db.Activitys.AddRange(
                new Activity
                {
                    sportId = sportid,
                    date = ActivityDate.ToShortDateString(),
                    name = ActivityName
                }
                );
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            MemberViewModel obj = new MemberViewModel();
            obj.allMember = db.Members;
            obj.allSportsman = db.Sportsmans.OrderBy(p => p.f_name);
            obj.allActivity = db.Activitys.OrderBy(p => p.sportId);
            obj.allSport = db.Sports;
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddMember(int sportsmanid, int activityid, int member_place)
        {
            db.Members.AddRange(
                new Member
                {
                    sportsmanId = sportsmanid,
                    activityId = activityid,
                    place = member_place
                }
                );
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ExportTrainerSport()
        {
            List<Trainer> trai = db.Trainers.ToList();
            List<Sport> sports = db.Sports.ToList();
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("TrainerSport");
                for (int i = 0; i < trai.Count; i++)
                {
                    for (int j = 0; j < sports.Count; j++)
                    {
                        if (trai[i].sportId == sports[j].Id)
                        {
                            worksheet.Cell(i + 1, 1).Value = trai[i].f_name;
                            worksheet.Cell(i + 1, 2).Value = trai[i].s_name;
                            worksheet.Cell(i + 1, 3).Value = trai[i].m_name;
                            worksheet.Cell(i + 1, 4).Value = trai[i].gender;
                            worksheet.Cell(i + 1, 5).Value = trai[i].birthday;
                            worksheet.Cell(i + 1, 6).Value = trai[i].phone;
                            worksheet.Cell(i + 1, 7).Value = sports[j].sport_name;
                            break;
                        }
                    }

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();
                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"TrainerSport_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }

        public ActionResult ExportJournal()
        {
            List<Trainer> trai = db.Trainers.ToList();
            List<Sport> sports = db.Sports.ToList();
            List<Sportsman> sportsmans = db.Sportsmans.ToList();
            List<Journal> jour = db.Journals.ToList();
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Journal");
                for (int i = 0; i < jour.Count; i++)
                {
                    for (int j = 0; j < sportsmans.Count; j++)
                    {
                        if(jour[i].sportsmanId == sportsmans[j].Id)
                        {
                            worksheet.Cell(i + 1, 1).Value = sportsmans[j].f_name;
                            worksheet.Cell(i + 1, 2).Value = sportsmans[j].s_name;
                            worksheet.Cell(i + 1, 3).Value = sportsmans[j].m_name;
                            worksheet.Cell(i + 1, 4).Value = sportsmans[j].gender;
                            worksheet.Cell(i + 1, 5).Value = sportsmans[j].birthday;
                            worksheet.Cell(i + 1, 6).Value = sportsmans[j].phone;
                            worksheet.Cell(i + 1, 7).Value = sportsmans[j].height;
                            worksheet.Cell(i + 1, 8).Value = sportsmans[j].height;
                            break;
                        }
                    }
                    for(int j = 0; j < sports.Count; j++)
                    {
                        if(jour[i].sportId == sports[j].Id)
                        {
                            worksheet.Cell(i + 1, 9).Value = sports[j].sport_name;
                            break;
                        }
                    }
                    for (int j = 0; j < trai.Count; j++)
                    {
                        if (jour[i].trainerId == trai[j].Id)
                        {
                            worksheet.Cell(i + 1, 10).Value = trai[j].f_name;
                            worksheet.Cell(i + 1, 11).Value = trai[j].s_name;
                            worksheet.Cell(i + 1, 12).Value = trai[j].m_name;
                            worksheet.Cell(i + 1, 13).Value = trai[j].gender;
                            worksheet.Cell(i + 1, 14).Value = trai[j].birthday;
                            worksheet.Cell(i + 1, 15).Value = trai[j].phone;
                            break;
                        }
                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();
                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"Journal_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }

        public ActionResult ExportMember()
        {
            List<Sport> sports = db.Sports.ToList();
            List<Sportsman> sportsmans = db.Sportsmans.ToList();
            List<Activity> activitys = db.Activitys.ToList();
            List<Member> members = db.Members.ToList();
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Member");
                for (int i = 0; i < members.Count; i++)
                {
                    for (int j = 0; j < sportsmans.Count; j++)
                    {
                        if (members[i].sportsmanId == sportsmans[j].Id)
                        {
                            worksheet.Cell(i + 1, 1).Value = sportsmans[j].f_name;
                            worksheet.Cell(i + 1, 2).Value = sportsmans[j].s_name;
                            worksheet.Cell(i + 1, 3).Value = sportsmans[j].m_name;
                            break;
                        }
                    }
                    for (int j = 0; j < activitys.Count; j++)
                    {
                        if (members[i].activityId == activitys[j].Id)
                        {
                            for(int k = 0; k < sports.Count; k++)
                            {
                                if(activitys[j].sportId == sports[k].Id)
                                {
                                    worksheet.Cell(i + 1, 4).Value = sports[k].sport_name;
                                    break;
                                }
                            }
                            worksheet.Cell(i + 1, 5).Value = activitys[j].date;
                            worksheet.Cell(i + 1, 6).Value = activitys[j].name;
                            break;
                        }
                    }
                    worksheet.Cell(i + 1, 7).Value = members[i].place;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();
                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"Member_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }

        public ActionResult ExportActivity()
        {
            List<Sport> sports = db.Sports.ToList();
            List<Activity> activitys = db.Activitys.ToList();
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Activity");
                for (int i = 0; i < activitys.Count; i++)
                {
                    for (int j = 0; j < sports.Count; j++)
                    {
                        if (activitys[i].sportId == sports[j].Id)
                        {
                            worksheet.Cell(i + 1, 1).Value = sports[j].sport_name;
                            break;
                        }
                    }
                    worksheet.Cell(i + 1, 2).Value = activitys[i].date;
                    worksheet.Cell(i + 1, 3).Value = activitys[i].name;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();
                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"Activity_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
    }
}
