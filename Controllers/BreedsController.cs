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
    public class BreedsController : Controller
    {
        private testdbContext db;

        public BreedsController(testdbContext context)
        {
            db = context;
        }
        // GET: BreedsController
        [Authorize]
        public ActionResult Index()
        {
            var breeds = db.Breeds.Include(breed => breed.Group).OrderBy(breed => breed.id);
            return View(breeds);
        }

        // GET: BreedsController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(db.Groups);
        }

        // POST: BreedsController/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Breed model)
        {
            try
            {
                if (model != null)
                {
                    db.Breeds.AddRange(new Breed { nameBreed = model.nameBreed, GroupId = model.GroupId });
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

        // GET: BreedsController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Breed breed = db.Breeds.Where(user => user.id == id).FirstOrDefault();
            var breedWithGroups = new BreedEdit() { nameBreed = breed.nameBreed, GroupId = breed.GroupId, Groups = db.Groups.ToList(), id = breed.id };
            return View(breedWithGroups);
        }

        // POST: BreedsController/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Breed model)
        {
            try
            {
                var breed = db.Breeds.Where(breed => breed.id == model.id).FirstOrDefault();
                if (breed != null)
                {
                    breed.nameBreed = model.nameBreed;
                    breed.GroupId = model.GroupId;
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

        // GET: BreedsController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var breeds = db.Breeds.Include(breed => breed.Group).OrderBy(breed => breed.id).Where(breed => breed.id == id).FirstOrDefault();
            return View(breeds);
        }

        // POST: BreedsController/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Breed model)
        {
            try
            {
                var breed = db.Breeds.Where(user => user.id == model.id).FirstOrDefault();
                if (breed != null)
                {
                    db.Breeds.Remove(breed);
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
