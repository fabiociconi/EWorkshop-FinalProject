using System;
using eWorkshop.Business.Register;
using Microsoft.AspNetCore.Mvc;
using XCommon.Application.Executes;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web.Controllers
{
	public class BaseController : Controller
	{
		[Inject]
		private ITicketInfo Info { get; set; }

		public BaseController()
		{
			Kernel.Resolve(this);
		}

		protected bool IsAuthenticated => Info.IsAuthenticated;

		protected Guid UserKey => Info.UserKey;

		protected ExecuteUser UserInfo => Info.UserInfo;
	}
}
