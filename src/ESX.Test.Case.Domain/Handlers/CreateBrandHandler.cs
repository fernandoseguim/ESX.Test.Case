using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;
using System;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Factories;
using ESX.Test.Case.Domain.Repositories;

namespace ESX.Test.Case.Domain.Handlers
{
	public partial class BrandHandler : Notifiable, ICommandHandler<BrandCommand>
	{
		private readonly IBrandRepository repository;

		public BrandHandler(IBrandRepository repository) => this.repository = repository;

		public ICommandResult Create(BrandCommand command)
		{
			try
			{
				if (command.IsValid())
				{
					var brand = BrandFactory.Create(command);
					
					if (this.CheckBrand(brand.Name))
					{
						return new UnsuccessfulCommandResult(StatusCodeResult.Conflict,
							"Please, check the properties before creating the user", this.Notifications);
					}

					this.repository.Save(brand);

					return new SuccessfulCommandResult("Brand was saved with successful", new
					{
						UserId = brand.Id,
						Name = brand.Name,
					});
				}

				return new UnsuccessfulCommandResult(StatusCodeResult.BadRequest,
					"Please, check the properties before creating the brand", command.Notifications);
			}
			catch (Exception ex)
			{
				return new UnsuccessfulCommandResult(StatusCodeResult.InternalServerError,
					"There was an error saving the user, please contact your system administrator.",
					ex.Message);
			}
		}

		public bool CheckBrand(string name)
		{
			var brandAlreadyExists = this.repository.CheckBrand(name);

			if (brandAlreadyExists)
			{
				this.AddNotification("Name", "Brand already exists on database");
			}
			return brandAlreadyExists;
		}
	}
}
