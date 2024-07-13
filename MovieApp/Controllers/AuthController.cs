using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTOs.AuthDto;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Reader> _userManager;
        private readonly SignInManager<Reader> _signInManager;


        public AuthController(UserManager<Reader> userManager, SignInManager<Reader> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpPost("register")]
        public async Task<IActionResult> ReaderRegister(ReaderRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new Reader { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Reader"); // Reader rolü ataması
                    return Ok("User created successfully");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // Başarılı giriş durumunda işlemler buraya yazılabilir
                return Ok("Login successful");
            }

            return Unauthorized();
        }

    }
}