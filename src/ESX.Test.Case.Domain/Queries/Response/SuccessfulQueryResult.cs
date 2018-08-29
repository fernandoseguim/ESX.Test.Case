using ESX.Test.Case.Shared.Commands;
using ESX.Test.Case.Shared.Queries;
using Newtonsoft.Json;

namespace ESX.Test.Case.Domain.Queries.Response
{
	public class SuccessfulQueryResult : IQueryResult
	{
		public SuccessfulQueryResult(object data)
		{
			this.Data = data;
		}

		[JsonIgnore]
		public StatusCodeResult StatusCode => StatusCodeResult.Success;
		public bool Success => true;
		public object Data { get; }
	}
}
