using System;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using StatusCodeResult = ESX.Test.Case.Shared.Commands.StatusCodeResult;

namespace ESX.Test.Case.Api.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class UsersController : Controller
	{
		private readonly ICommandHandler<UserCommand> useCommandHandler;
		private readonly IUserRepository repository;

		public UsersController(ICommandHandler<UserCommand> useCommandHandler, IUserRepository repository)
		{
			this.useCommandHandler = useCommandHandler;
			this.repository = repository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var result = this.repository.GetAll();

				return this.Ok(result);
			}
			catch (Exception ex)
			{
				var result = new UnsuccessfulCommandResult(StatusCodeResult.InternalServerError,
					"There was an error saving the user, please contact your system administrator.",
					ex.Message);

				return this.StatusCode((int)result.StatusCode, result);
			}
		}

		// POST api/users
		[HttpPost]  
		public IActionResult Post([FromBody] UserCommand userCommand)
		{
			var result = this.useCommandHandler.Create(userCommand);
			
			return this.StatusCode((int)result.StatusCode, result);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete([FromRoute] string id)
		{
			var result = this.useCommandHandler.Delete(id);

			return this.StatusCode((int)result.StatusCode, result);
		}
	}
}
