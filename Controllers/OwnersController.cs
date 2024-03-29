﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dog_club.Models;
using Microsoft.AspNetCore.Authorization;

namespace dog_club.Controllers
{
    public class OwnersController : Controller
    {
        private testdbContext db;

        public OwnersController(testdbContext context)
        {
            db = context;
        }

        // GET: OwnersController
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Owners.OrderBy(owner => owner.id));
        }

        // GET: OwnersController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController/Create[ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public ActionResult Create(Owner model)
        {
            try
            {
                if (model != null)
                {
                    db.Owners.AddRange(new Owner { fullName = model.fullName, address = model.address, phone = model.phone });
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

        // GET: OwnersController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Owner ownerData = db.Owners.Where(owner => owner.id == id).FirstOrDefault();
            return View(ownerData);
        }

        // POST: OwnersController/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Owner model)
        {
            try
            {
                var owner = db.Owners.Where(owner => owner.id == model.id).FirstOrDefault();
                if (owner != null)
                {
                    owner.fullName = model.fullName;
                    owner.address = model.address;
                    owner.phone = model.phone;
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

        // GET: OwnersController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Owner ownerData = db.Owners.Where(owner => owner.id == id).FirstOrDefault();
            return View(ownerData);
        }

        // POST: OwnersController/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Owner model)
        {
            try
            {
                var owner = db.Owners.Where(owner => owner.id == model.id).FirstOrDefault();
                if (owner != null)
                {
                    db.Owners.Remove(owner);
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
