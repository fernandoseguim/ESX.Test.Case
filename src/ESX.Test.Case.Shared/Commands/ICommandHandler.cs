namespace ESX.Test.Case.Shared.Commands
{
	public interface ICommandHandler<in TCommand> where TCommand : BaseCommand
	{
		ICommandResult Handle(TCommand command);
	}
}
