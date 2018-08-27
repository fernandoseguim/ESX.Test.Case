using ESX.Test.Case.Shared.Commands;
using Newtonsoft.Json;

namespace ESX.Test.Case.Domain.Commands.Response
{
	public class UnsuccesfulCommandResult : ICommandResult
	{
		public UnsuccesfulCommandResult(StatusCodeResult statusCode, string message, object data)
		{
			this.StatusCode = statusCode;
			this.Success = false;
			this.Message = message;
			this.Data = data;
			this.StatusCode = statusCode;
		}

		[JsonIgnore]
		public StatusCodeResult StatusCode { get; }
		public bool Success { get; }
		public string Message { get; }
		public object Data { get; }
	}
}
