using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using XCommon.Application.Executes;
using XCommon.Extensions.String;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web.Controllers
{
    public class BaseController : Controller
	{
		public BaseController()
		{
			Kernel.Resolve(this);
		}

		protected bool IsAuthenticated
		{
			get
			{
				return HttpContext.User.Identities.Any(c => c.IsAuthenticated);
			}
		}

		protected Guid UserKey
		{
			get
			{
				var result = Guid.Empty;

				if (!IsAuthenticated)
				{
					return result;
				}

				var identifier = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

				if (identifier.IsEmpty())
				{
					return result;
				}

				Guid.TryParse(identifier, out result);

				return result;
			}
		}

		protected ExecuteUser UserInfo
		{
			get
			{
				var userKey = UserKey;

				if (userKey == Guid.Empty)
				{
					return null;
				}

				return new ExecuteUser
				{
					Key = userKey,
					Name = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value,
					Culture = "en-US"
				};
			}
		}
	}
}
