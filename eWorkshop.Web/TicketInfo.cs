using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eWorkshop.Business.Register;
using Microsoft.AspNetCore.Http;
using XCommon.Application.Executes;
using XCommon.Extensions.String;

namespace eWorkshop.Web
{
	public class TicketInfo : ITicketInfo
	{
		private IHttpContextAccessor Accessor { get; set; }

		public TicketInfo(IHttpContextAccessor httpContext)
		{
			Accessor = httpContext;
		}

		public bool IsAuthenticated
		{
			get
			{
				return Accessor.HttpContext.User.Identities.Any(c => c.IsAuthenticated);
			}
		}

		public Guid UserKey
		{
			get
			{
				var result = Guid.Empty;

				if (!IsAuthenticated)
				{
					return result;
				}

				var identifier = Accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

				if (identifier.IsEmpty())
				{
					return result;
				}

				Guid.TryParse(identifier, out result);

				return result;
			}
		}

		public ExecuteUser UserInfo
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
					Name = Accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value,
					Culture = "en-US"
				};
			}
		}
	}
}
