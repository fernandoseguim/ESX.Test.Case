using System;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;

namespace ESX.Test.Case.Domain.Handlers
{
	public partial class AssetHandler : Notifiable, ICommandHandler<AssetCommand>
	{
		public ICommandResult Delete(string id)
		{
			try
			{
				if (Guid.TryParse(id, out var assetId))
				{
					var removed = this.assetRepository.Delete(assetId);
					if (removed)
					{
						return new SuccessfulCommandResult($"The asset {assetId} was removed with successful", null);
					}

					return new UnsuccessfulCommandResult(StatusCodeResult.NotFound,
						$"The asset {assetId} not found", null);
				}

				return new UnsuccessfulCommandResult(StatusCodeResult.BadRequest,
					"The asset identifier should be a valid GUID", null);
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
