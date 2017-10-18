using eWorkshop.Business.Sample;
using eWorkshop.Entity.Sample;
using eWorkshop.Entity.Sample.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	public class SampleController : BaseController
	{
		private SampleTableBusiness SampleTable => new SampleTableBusiness();

		[HttpGet]
		public async Task<List<SampleTableEntity>> GetSample()
		{
			return await SampleTable.GetByFilterAsync(new SampleTableFilter { });
		}
	}
}
