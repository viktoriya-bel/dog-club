using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Controllers
{
    public class LkController : Controller
    {
        [Authorize]
        public ViewResult Profile()
        {
            return View();//User.Identity.Name
        }
    }
}
