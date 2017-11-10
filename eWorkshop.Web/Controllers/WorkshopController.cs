using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	[Authorize(Roles = AppConstants.Workshop)]
	public class WorkshopController : BaseController
    {
    }
}
