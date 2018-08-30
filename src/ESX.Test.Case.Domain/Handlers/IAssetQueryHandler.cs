using ESX.Test.Case.Shared.Queries;

namespace ESX.Test.Case.Domain.Handlers
{
	public interface IAssetQueryHandler : IQueryHandler
	{
		IQueryResult GetById(string id);
		IQueryResult GetAllByBrandId(string id);
	}
}
