using System;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Queries.Response;

namespace ESX.Test.Case.Domain.Factories
{
	public class BrandFactory
	{
		public static Brand Create(BrandCommand command) => new Brand(command.Name);
		public static Brand Create(BrandQueryResult queryResult) => new Brand(new Guid(queryResult.Id), queryResult.Name);
	}
}