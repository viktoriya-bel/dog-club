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
    public class DogsController : Controller
    {
        private testdbContext db;

        public DogsController(testdbContext context)
        {
            db = context;
        }
        // GET: DogsController
        [Authorize]
        public ActionResult Index()
        {
            var dogs = db.Dogs.Include(dog => dog.Owner).OrderBy(dog => dog.id)
                .Include(dog => dog.Breed).OrderBy(dog => dog.id)
                .Include(dog => dog.Mother).OrderBy(dog => dog.id);
            return View(dogs);
        }

        // GET: DogsController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DogsController/Create
        [Authorize]
        public ActionResult Create()
        {
            SelectDataDog data = new SelectDataDog { Owners = db.Owners.ToList(), Breeds = db.Breeds.ToList(), Dogs = db.Dogs.ToList() };
            return View(data);
        }

        // POST: DogsController/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Dog model)
        {
            try
            {
                if (model != null)
                {
                    db.Dogs.AddRange(new Dog { 
                        BreedId = model.BreedId, 
                        dateBirth = model.dateBirth, 
                        dateDeath = model.dateDeath, 
                        FatherId = model.FatherId, 
                        MotherId = model.MotherId, 
                        gender = model.gender, 
                        name = model.name, 
                        OwnerId = model.OwnerId 
                    });
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

        // GET: DogsController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Dog dogCurrent = db.Dogs.Where(dog => dog.id == id).FirstOrDefault();
            SelectDataDog data = new SelectDataDog { 
                Owners = db.Owners.ToList(), 
                Breeds = db.Breeds.ToList(), 
                Dogs = db.Dogs.ToList(), 
                id = dogCurrent.id,
                name = dogCurrent.name, 
                gender = dogCurrent.gender, 
                dateBirth = dogCurrent.dateBirth, 
                dateDeath = dogCurrent.dateDeath 
            };
            return View(data);
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Dog model)
        {
            try
            {
                Dog dogCurrent = db.Dogs.Where(dog => dog.id == model.id).FirstOrDefault();
                if (dogCurrent != null)
                {
                    dogCurrent.name = model.name;
                    dogCurrent.gender = model.gender;
                    dogCurrent.BreedId = model.BreedId;
                    dogCurrent.OwnerId = model.OwnerId;
                    dogCurrent.MotherId = model.MotherId;
                    dogCurrent.FatherId = model.FatherId;
                    dogCurrent.dateBirth = model.dateBirth;
                    dogCurrent.dateDeath = model.dateDeath;
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

        // GET: DogsController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var dogs = db.Dogs.Include(dog => dog.Owner).OrderBy(dog => dog.id)
                .Include(dog => dog.Breed).OrderBy(dog => dog.id)
                .Include(dog => dog.Mother).OrderBy(dog => dog.id).Where(dog => dog.id == id).FirstOrDefault();
            return View(dogs);
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Dog model)
        {
            try
            {
                Dog dogCurrent = db.Dogs.Where(dog => dog.id == model.id).FirstOrDefault();
                if (dogCurrent != null)
                {
                    db.Dogs.Remove(dogCurrent);
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
