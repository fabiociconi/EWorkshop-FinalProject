using eWorkshop.Business.Sample;
using eWorkshop.Entity.Sample;
using eWorkshop.Entity.Sample.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCommon.Application.Executes;
using System;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	public class SampleController : BaseController
	{
		private SampleTableBusiness SampleTable => new SampleTableBusiness();

		[HttpGet]
		public async Task<List<SampleTableEntity>> GetSamples()
		{
			return await SampleTable.GetByFilterAsync(new SampleTableFilter { });
		}

		[HttpGet("{id}")]
		public async Task<SampleTableEntity> GetSample(Guid id)
		{
			return await SampleTable.GetByKeyAsync(id);
		}

		[HttpPost]
		public async Task<Execute<SampleTableEntity>> SetSample([FromBody] SampleTableEntity entity)
		{
			return await SampleTable.SaveAsync(entity);
		}
	}
}
