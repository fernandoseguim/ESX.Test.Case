using ESX.Test.Case.Shared.Commands;

namespace ESX.Test.Case.Domain.Commands.Response
{
	public class UserCommandResult : ICommandResult
	{
		public UserCommandResult(bool success, string message, object data)
		{
			this.Success = success;
			this.Message = message;
			this.Data = data;
		}

		public bool Success { get; }
		public string Message { get; }
		public object Data { get; }
	}
}
