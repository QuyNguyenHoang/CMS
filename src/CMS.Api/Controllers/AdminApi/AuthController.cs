using CMS.Api.Services;
using CMS.Core.Domain.Identity;
using CMS.Core.Models.Auth;
using CMS.Core.SeedWorks.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace CMS.Api.Controllers.AdminApi
{
    [Route("api/admin/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<ActionResult<LoginResult>> Login([FromBody] Login_Request request)
        {
            //Authentication
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || user.IsActive == false || user.LockoutEnabled)
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.PassWord, false, true);
            if (!result.Succeeded)
            {
                return Unauthorized();

            }
            //Authorization
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(UserClaims.Id, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(UserClaims.FirstName, user.FirstName),
                    new Claim(UserClaims.Roles, string.Join(";", roles)),
                    //new Claim(UserClaims.Permissions, JsonSerializer.Serialize(permissions)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refresToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refresToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(30);
            await _userManager.UpdateAsync(user);
            return Ok(new LoginResult()
            {
                Token = accessToken,
                RefreshToken = refresToken
            });


        }
    }
}

