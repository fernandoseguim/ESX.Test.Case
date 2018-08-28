using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Factories;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;
using System;
using ESX.Test.Case.Domain.ValueObjects;

namespace ESX.Test.Case.Domain.Handlers
{
	public class CreateUserHandler : Notifiable, ICommandHandler<UserCommand>
	{
		private readonly IUserRepository repository;

		public CreateUserHandler(IUserRepository repository) => this.repository = repository;

		public ICommandResult Handle(UserCommand command)
		{
			try
			{
				if (command.IsValid())
				{	
					var user = UserFactory.Create(command);

					if(this.CheckEmail(user.Email))
					{
						return new UnsuccessfulCommandResult(StatusCodeResult.BadRequest,
							"Please, check the properties before creating the user", this.Notifications);
					}

					this.repository.Save(user);

					return new SuccessfulCommandResult("User was saved with successful", new
					{
						Name = user.Name.ToString(),
						Email = user.Email.ToString()
					});
				}

				return new UnsuccessfulCommandResult(StatusCodeResult.BadRequest, 
					"Please, check the properties before creating the user", command.Notifications);
			}
			catch(Exception ex)
			{
				return new UnsuccessfulCommandResult(StatusCodeResult.InternalServerError, 
					"There was an error saving the user, please contact your system administrator.",
					ex.Message);
			}
		}

		private bool CheckEmail(Email email)
		{
			var emailAlreadyExists = this.repository.CheckEmail(email);

			if (emailAlreadyExists)
			{
				this.AddNotification(nameof(email), "Email already exists on database");
			}			
			return emailAlreadyExists;
		}
	}
}
