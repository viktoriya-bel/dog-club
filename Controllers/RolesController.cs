using dog_club.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Controllers
{
    public class RolesController : Controller
    {
        private testdbContext db;

        public RolesController(testdbContext context)
        {
            db = context;
        }

        // GET: RolesController
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Roles.OrderBy(role => role.id));
        }

        // GET: RolesController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Role model)
        {
            try
            {
                if (model != null)
                {
                    //Boolean isAdmin = model.isAdmin ? true : false;
                    db.Roles.AddRange(new Role{ name = model.name, isAdmin = false  });
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

        // GET: RolesController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Role roleData = db.Roles.Where(role => role.id == id).FirstOrDefault();
            return View(roleData);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Role model)
        {
            try
            {
                var role = db.Roles.Where(role => role.id == model.id).FirstOrDefault();
                if (role != null)
                {
                    role.name = model.name;
                    role.isAdmin = model.isAdmin;
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

        // GET: RolesController/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Role roleData = db.Roles.Where(role => role.id == id).FirstOrDefault();
            return View(roleData);
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Role model)
        {
            try
            {
                var role = db.Roles.Where(role => role.id == model.id).FirstOrDefault();
                if (role != null)
                {
                    db.Roles.Remove(role);
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
