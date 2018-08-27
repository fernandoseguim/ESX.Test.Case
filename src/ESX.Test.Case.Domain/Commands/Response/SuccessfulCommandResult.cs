using ESX.Test.Case.Shared.Commands;
using Newtonsoft.Json;

namespace ESX.Test.Case.Domain.Commands.Response
{
	public class SuccessfulCommandResult : ICommandResult
	{
		public SuccessfulCommandResult(string message, object data)
		{
			this.StatusCode = StatusCodeResult.Success;
			this.Success = true;
			this.Message = message;
			this.Data = data;
		}

		[JsonIgnore]
		public StatusCodeResult StatusCode { get; }
		public bool Success { get; }
		public string Message { get; }
		public object Data { get; }
	}
}
