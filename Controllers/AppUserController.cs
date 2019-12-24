using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PenguinAngularCore.Modules;

namespace PenguinAngularCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        [Route("Register")]
        //Post  : /api/AppUser/Register
        public async Task<Object> PostAppUser(AppUserModel model)
        {
            var appUser = new AppUser()
            {
                FullName = model.FullName,  
                Email = model.Email,
                UserName= model.UserName

            };
            try
            {
                var resualt = await _userManager.CreateAsync(appUser, model.Password);
                return Ok(resualt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}