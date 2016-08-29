using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HarmonicPatternsBase.Models.UserViewModels;
using HarmonicPatternBase.Repositories.Abstract;

namespace HarmonicPatternsBase.Controllers
{
    public class UserController : Controller
    {
        private IUsersRepo _usersRepo;

        public UserController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<IActionResult> Index(string userId)
        {
            var model = new UserIndexViewModel();

            if(userId != null)
            {
                model.User = await _usersRepo.GetUserAsync(userId);
            }
            else
            {
                model.User = null;
            }

            return View(model);
        }
    }
}