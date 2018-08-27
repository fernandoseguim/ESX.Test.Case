namespace ESX.Test.Case.Shared.Commands
{
	public interface ICommandResult
	{
		bool Success { get; }
		string Message { get; }
		object Data { get; }
	}
}
