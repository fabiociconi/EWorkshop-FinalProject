using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eWorkshop.Business.Register;
using eWorkshop.Entity.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using XCommon.Application.Executes;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	public class AccountController : BaseController
	{
		[Inject]
		private PeopleBusiness PeopleBusiness { get; set; }

		private JwtSecurityToken GetTokenAsync(TokenEntity token)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, token.IdPerson.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, $"{token.FirstName} {token.LastName}"),
				new Claim(ClaimTypes.Role, token.RoleType.ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConstants.TokenKey));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


			return new JwtSecurityToken(AppConstants.TokenAudience, AppConstants.TokenAudience, claims, expires: DateTime.Now.AddDays(30), signingCredentials: credentials);
		}

		[HttpPost("signup")]
		public async Task<Execute<TokenEntity>> SignUp([FromBody] SignUpEntity signUpEntity)
		{
			var result = await PeopleBusiness.SignUpAsync(signUpEntity);

			if (!result.HasErro)
			{
				result.Entity.Token = new JwtSecurityTokenHandler().WriteToken(GetTokenAsync(result.Entity));
			}

			return result;
		}

		[HttpPost("signin")]
		public async Task<Execute<TokenEntity>> SignIn([FromBody] SignInEntity signInEntity)
		{
			var result = await PeopleBusiness.SignInAsync(signInEntity);

			if (!result.HasErro)
			{
				result.Entity.Token = new JwtSecurityTokenHandler().WriteToken(GetTokenAsync(result.Entity));
			}

			return result;
		}
	}
}
