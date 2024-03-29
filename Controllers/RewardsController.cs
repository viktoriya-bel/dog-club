﻿using dog_club.Models;
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
    public class RewardsController : Controller
    {
        private testdbContext db;

        public RewardsController(testdbContext context)
        {
            db = context;
        }
        // GET: RewardsController
        [Authorize]
        public ActionResult Index()
        {
            var rewards = db.Rewards.Include(reward => reward.Dog).OrderBy(reward => reward.id);
            return View(rewards);
        }

        // GET: RewardsController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(db.Dogs);
        }

        // POST: RewardsController/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Reward model)
        {
            try
            {
                if (model != null)
                {
                    db.Rewards.AddRange(new Reward { name = model.name, date = model.date, DogId = model.DogId });
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

        // GET: RewardsController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Reward rewardData = db.Rewards.Where(reward => reward.id == id).FirstOrDefault();
            var rewardWithDogs = new RewardEdit() { date = rewardData.date, DogId = rewardData.DogId, Dogs = db.Dogs.ToList(), id = rewardData.id, name = rewardData.name };
            return View(rewardWithDogs);
        }

        // POST: RewardsController/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Reward model)
        {
            try
            {
                Reward reward = db.Rewards.Where(reward => reward.id == model.id).FirstOrDefault();
                if (reward != null)
                {
                    reward.name = model.name;
                    reward.date = model.date;
                    reward.DogId = model.DogId;
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

        // GET: RewardsController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Reward rewardData = db.Rewards.Include(reward => reward.Dog).Where(reward => reward.id == id).FirstOrDefault();
            return View(rewardData);
        }

        // POST: RewardsController/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Reward model)
        {
            try
            {
                Reward reward = db.Rewards.Where(reward => reward.id == model.id).FirstOrDefault();
                if (reward != null)
                {
                    db.Rewards.Remove(reward);
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
