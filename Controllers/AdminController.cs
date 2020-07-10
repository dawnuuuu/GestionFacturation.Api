using GestionFacturation.Api.Models;
using GestionFacturation.Api.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionFacturation.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ILogger<BaseController<ApplicationUser>> logger, 
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager) : base(logger, context)
        {
            _userManager = userManager;
        }



        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await AddUserModel(model);
                if (user != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }


        #region private Methods

        private async Task<ApplicationUser> AddUserModel(AddUserModel model)
        {
            if (model == null)
            {
                return null;
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        #endregion

    }
}