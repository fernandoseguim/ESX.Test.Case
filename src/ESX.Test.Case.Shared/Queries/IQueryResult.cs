using ESX.Test.Case.Shared.Commands;

namespace ESX.Test.Case.Shared.Queries
{
	public interface IQueryResult
    {
	    StatusCodeResult StatusCode { get; }
	    bool Success { get; }
	    object Data { get; }
	}
}
