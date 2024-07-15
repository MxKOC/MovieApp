using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;

        }

        [HttpPost("writerregister")]
        public async Task<IActionResult> WriterRegister(WriterRegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new Writer { UserName = model.UserName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var createdUser = await _userManager.FindByNameAsync(user.UserName);
                if (createdUser == null)
                {
                    return StatusCode(500, "User creation failed");
                }


                var token = _jwtService.GenerateTokenWriter(user);
                await _userManager.AddToRoleAsync(user, "Writer"); // Reader rolü ataması

                return Ok(new { token });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }


        [HttpPost("readerregister")]
        public async Task<IActionResult> ReaderRegister(ReaderRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new Reader { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Reader"); // Reader rolü ataması
                    var token = _jwtService.GenerateTokenReader(user);
                    return Ok(new { Token = token });
                }

                return BadRequest("asd");
            }
            return BadRequest("Model ");

        }


        /*[HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new { message = "Email or password is incorrect." });

            var token = _jwtService.GenerateTokenWriter(user);
            return Ok(new { Token = token });
        }*/

    }
}