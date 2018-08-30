using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Domain.Factories
{
	public class AssetFactory
	{
		public static Asset Create(AssetCommand command, Brand brand)
		{
			var asset = new Asset(command.Name, brand);
			asset.AddDescription(command.Description);
			return asset;
		}
	}
}