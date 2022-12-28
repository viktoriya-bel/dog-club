using dog_club.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Controllers
{
    public class UsersController : Controller
    {
        private testdbContext db;

        public UsersController(testdbContext context)
        {
            db = context;
        }

        // GET: UsersController
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var users = db.Users.Include(user => user.Role).OrderBy(role => role.id);
            return View(users);
        }

        // GET: UsersController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View(db.Roles);
        }

        // POST: UsersController/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(User model)
        {
            try
            {
                if (model != null)
                {
                    db.Users.AddRange(new User { userName = model.userName, password = model.password, RoleId = model.RoleId });
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

        // GET: UsersController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            User user = db.Users.Where(user => user.id == id).FirstOrDefault();
            var userWithRoles = new UserEdit() { id = user.id, userName = user.userName, password = user.password, RoleId = user.RoleId, availableRoles = db.Roles.ToList() };
            return View(userWithRoles);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(User model)
        {
            try
            {
                var user = db.Users.Where(user => user.id == model.id).FirstOrDefault();
                if (user != null)
                {
                    user.userName = model.userName;
                    user.password = model.password;
                    user.RoleId = model.RoleId;
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

        // GET: UsersController/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var user = db.Users.Include(user => user.Role).Where(role => role.id == id).FirstOrDefault();
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(User model)
        {
            try
            {
                var user = db.Users.Where(user => user.id == model.id).FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
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
