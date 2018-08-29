using ESX.Test.Case.Shared.Queries;

namespace ESX.Test.Case.Domain.Handlers
{
	public interface IBrandQueryHandler : IQueryHandler
	{
		IQueryResult GetById(string id);
	}
}
