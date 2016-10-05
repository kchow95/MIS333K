using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chow_Kenneth_hw4.DAL;
using Chow_Kenneth_hw4.Models;

namespace Chow_Kenneth_hw4.Controllers
{
    public class EventsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.AllCommittees = GetAllCommittees();
            return View();
        }
        //GET: All Committees
        public SelectList GetAllCommittees()
        {
            var query = from c in db.Committees orderby c.CommitteeName select c;
            List<Committee> allCommittees = query.ToList();
            SelectList allCommitteeslist = new SelectList(allCommittees, "CommitteeID", "CommitteeName");

            return allCommitteeslist;
        }

        //GET: Committees if they already have a committee
        public MultiSelectList GetAllMembers(Event @event)
        {
            //find the list of members
            var query2 = from m in db.Members orderby m.str_Email select m;

            List<Member> allMembers = query2.ToList();

            List<Int32> SelectedMembers = new List<Int32>();

            foreach (Member m in @event.Members)
            {
                SelectedMembers.Add(m.int_MemberID);
            }

            MultiSelectList allMemberList = new MultiSelectList(allMembers, "int_MemberID", "str_Email", SelectedMembers);

            

            return allMemberList;
        }

        public SelectList GetAllCommittees(Event @event)
        {
            var query = from c in db.Committees orderby c.CommitteeName select c;

            //execute query and store in list
            List<Committee> allCommittees = query.ToList();

            SelectList list = new SelectList(allCommittees, "CommitteeID", "Name", @event.SponsoringCommittee.CommitteeID);

            return list;
        }


        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Title,EventDate,Location,MembersOnly")] Event @event, Int32 CommitteeID)
        {
            //find selected committee  
            Committee SelectedCommittee = db.Committees.Find(CommitteeID);

            //associate committee with event
            @event.SponsoringCommittee = SelectedCommittee;
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllCommittees = GetAllCommittees(@event);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            ViewBag.AllCommittees = GetAllCommittees(@event);
            ViewBag.AllMembers = GetAllMembers(@event);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,Title,EventDate,Location,MembersOnly")] Event @event, Int32 CommitteeID, int[] SelectedMembers) 
        {
            //find selected committee
            

            
            if (ModelState.IsValid)
            {
                Event eventToChange = db.Events.Find(@event.EventID);

                if(eventToChange.SponsoringCommittee.CommitteeID != CommitteeID)
                {
                    //find Committee
                    Committee SelectedCommittee = db.Committees.Find(CommitteeID);

                    eventToChange.SponsoringCommittee = SelectedCommittee;
                }

                //change members
                //remove any existing member
                eventToChange.Members.Clear();

                //if there are members, add to them
                if (SelectedMembers != null)
                {
                    foreach(int memberID in SelectedMembers)
                    {
                        Member memberToAdd = db.Members.Find(memberID);
                        eventToChange.Members.Add(memberToAdd);
                    }
                }

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                
            }

            //re-populate lists
            //add to viewbag
            ViewBag.AllCommittees = GetAllCommittees(@event);
            ViewBag.AllMembers = GetAllMembers(@event);
            

            
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
