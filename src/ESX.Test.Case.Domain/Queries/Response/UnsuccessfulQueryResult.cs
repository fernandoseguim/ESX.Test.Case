using ESX.Test.Case.Shared.Commands;
using ESX.Test.Case.Shared.Queries;

namespace ESX.Test.Case.Domain.Queries.Response
{
	public class UnsuccessfulQueryResult : IQueryResult
	{
		public UnsuccessfulQueryResult(StatusCodeResult statusCode, object data)
		{
			this.StatusCode = statusCode;
			this.Data = data;
		}

		public StatusCodeResult StatusCode { get; }
		public bool Success => false;
		public object Data { get; }
	}
}
