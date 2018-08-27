using System;
using Flunt.Notifications;

namespace ESX.Test.Case.Shared.Commands
{
	public abstract class BaseCommand : Notifiable
	{
		public abstract bool IsValid();
	}
}
