using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ESX.Test.Case.Api.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class UsersController : Controller
	{
		private readonly ICommandHandler<UserCommand> useCommandHandler;

		public UsersController(ICommandHandler<UserCommand> useCommandHandler) 
			=> this.useCommandHandler = useCommandHandler;

		// POST api/users
		[HttpPost]  
		public IActionResult Post([FromBody] UserCommand userCommand)
		{
			var result = this.useCommandHandler.Handle(userCommand);
			
			return this.StatusCode((int)result.StatusCode, result);
		}
	}
}
