using System;
using Flunt.Notifications;

namespace ESX.Test.Case.Shared.Entities
{
	public abstract class Entity : Notifiable
	{
		protected Entity() => this.Id = Guid.NewGuid();

		public Guid Id { get; }
	}
}
