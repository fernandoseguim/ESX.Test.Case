using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Handlers;
using ESX.Test.Case.Domain.Queries.Response;
using ESX.Test.Case.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ESX.Test.Case.Api.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class BrandsController : Controller
	{
		private readonly ICommandHandler<BrandCommand> brandCommandHandler;
		private readonly IBrandQueryHandler brandQueryHandler;

		public BrandsController(ICommandHandler<BrandCommand> brandCommandHandler, IBrandQueryHandler brandQueryHandler)
		{
			this.brandCommandHandler = brandCommandHandler;
			this.brandQueryHandler = brandQueryHandler;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var result = this.brandQueryHandler.GetAll();

			return this.StatusCode((int)result.StatusCode, result);
		}

		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var result = this.brandQueryHandler.GetById(id);

			return this.StatusCode((int)result.StatusCode, result);
		}

		[HttpPost]
		public IActionResult Post([FromBody] BrandCommand brandCommand)
		{
			var result = this.brandCommandHandler.Create(brandCommand);

			return this.StatusCode((int)result.StatusCode, result);
		}

		[HttpPut("{id}")]
		public IActionResult Put(string id, [FromBody] BrandCommand brandCommand)
		{
			var result = this.brandCommandHandler.Update(id, brandCommand);

			return this.StatusCode((int)result.StatusCode, result);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete([FromRoute] string id)
		{
			var result = this.brandCommandHandler.Delete(id);

			return this.StatusCode((int)result.StatusCode, result);
		}
	}
}
