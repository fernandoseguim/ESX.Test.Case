using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;
using System;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Factories;
using ESX.Test.Case.Domain.Repositories;

namespace ESX.Test.Case.Domain.Handlers
{
	public partial class AssetHandler : Notifiable, ICommandHandler<AssetCommand>
	{
		private readonly IAssetRepository assetRepository;
		private readonly IBrandRepository brandRepository;

		public AssetHandler(IAssetRepository repository, IBrandRepository brandRepository)
		{
			this.assetRepository = repository;
			this.brandRepository = brandRepository;
		}

		public ICommandResult Create(AssetCommand command)
		{
			try
			{
				if (command.IsValid())
				{
					var brandResult = this.brandRepository.GetById(new Guid(command.BrandId));

					if (brandResult is null)
					{
						AddNotification("BrandID", "Brand not found");
						return new UnsuccessfulCommandResult(StatusCodeResult.NotFound,
							"Please, check the properties before creating the user", this.Notifications);
					}

					var brand = BrandFactory.Create(brandResult);
					var asset = AssetFactory.Create(command, brand);

					this.assetRepository.Save(asset);

					return new SuccessfulCommandResult("Asset was saved with successful", new
					{
						id = asset.Id,
						Name = asset.Name,
						Description = asset.Description,
						Registry = asset.Registry,
						Brand = new
						{
							id = asset.Brand.Id,
							Name = asset.Brand.Name,
						}
					});
				}

				return new UnsuccessfulCommandResult(StatusCodeResult.BadRequest,
					"Please, check the properties before creating the asset", command.Notifications);
			}
			catch (Exception ex)
			{
				return new UnsuccessfulCommandResult(StatusCodeResult.InternalServerError,
					"There was an error saving the user, please contact your system administrator.",
					ex.Message);
			}
		}
	}
}
