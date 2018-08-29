using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Domain.Factories
{
	public class BrandFactory
	{
		public static Brand Create(BrandCommand command) => new Brand(command.Name);
	}
}