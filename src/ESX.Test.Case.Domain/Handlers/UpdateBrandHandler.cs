using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Factories;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;
using System;

namespace ESX.Test.Case.Domain.Handlers
{
	public partial class BrandHandler : Notifiable, ICommandHandler<BrandCommand>
	{
		public ICommandResult Update(string id, BrandCommand command)
		{
			try
			{
				if (command.IsValid())
				{
					if (this.CheckBrand(command.Name))
					{
						return new UnsuccessfulCommandResult(StatusCodeResult.Conflict,
							"Please, check the properties before updating the user", this.Notifications);
					}

					var updated = this.repository.Update(new Guid(id), command);

					if (updated)
					{
						return new SuccessfulCommandResult("Brand was updated with successful", 
							new { UserId = id, Name = command.Name });
					}

					AddNotification("Id", $"The brand {id} not found");
					return new UnsuccessfulCommandResult(StatusCodeResult.NotFound,
						"Please, check the properties before updating the brand", this.Notifications);
				}

				return new UnsuccessfulCommandResult(StatusCodeResult.BadRequest,
					"Please, check the properties before updating the brand", command.Notifications);
			}
			catch (Exception ex)
			{
				return new UnsuccessfulCommandResult(StatusCodeResult.InternalServerError,
					"There was an error saving the user, please contact your system administrator.", ex.Message);
			}
		}
	}
}
