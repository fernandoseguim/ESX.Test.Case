using System;
using Flunt.Notifications;

namespace ESX.Test.Case.Shared
{
	public abstract class Entity
	{
		protected Entity() => this.Id = Guid.NewGuid();

		public Guid Id { get; }
	}
}
