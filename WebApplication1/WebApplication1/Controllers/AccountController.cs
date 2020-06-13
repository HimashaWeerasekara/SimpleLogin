using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            var user = new User()
            {
                NIC = model.NIC,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                PersonalAddress = model.PersonalAddress
            };

            if (model.RegisterAsFarmer)
            {
                user.DivisionId = model.DivisionId;
                await userManager.CreateAsync(user, model.Password);
                if (!await roleManager.RoleExistsAsync("Farmer"))
                    await roleManager.CreateAsync(new IdentityRole() { Name = "Farmer" });
                await userManager.AddToRoleAsync(user, "Farmer");
            }
            else
            {
                await userManager.CreateAsync(user, model.Password);
                if (!await roleManager.RoleExistsAsync("Buyer"))
                    await roleManager.CreateAsync(new IdentityRole() { Name = "Buyer" });
                await userManager.AddToRoleAsync(user, "Buyer");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretsecuritykey"));

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = new JwtSecurityToken(
                        issuer: "http://localhost:4200",
                        audience: "http://localhost:4200",
                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync()
        {
            var email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByEmailAsync(email);
            return Ok(new
            {
                email = user.Email,
                firstName = user.FirstName,
                lastName = user.LastName
            });
        }
    }
}