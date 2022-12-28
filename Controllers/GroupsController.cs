using dog_club.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Controllers
{
    public class GroupsController : Controller
    {
        private testdbContext db;

        public GroupsController(testdbContext context)
        {
            db = context;
        }
        // GET: GroupsController1
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Groups.OrderBy(group => group.id));
        }

        // GET: GroupsController1/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupsController1/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Group model)
        {
            try
            {
                if (model != null)
                {
                    db.Groups.AddRange(new Group { nameGroup = model.nameGroup });
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupsController1/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Group groupData = db.Groups.Where(group => group.id == id).FirstOrDefault();
            return View(groupData);
        }

        // POST: GroupsController1/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Group model)
        {
            try
            {
                var group = db.Groups.Where(group => group.id == model.id).FirstOrDefault();
                if (group != null)
                {
                    group.nameGroup = model.nameGroup;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupsController1/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Group groupData = db.Groups.Where(group => group.id == id).FirstOrDefault();
            return View(groupData);
        }

        // POST: GroupsController1/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Group model)
        {
            try
            {
                var group = db.Groups.Where(group => group.id == model.id).FirstOrDefault();
                if (group != null)
                {
                    db.Groups.Remove(group);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
