using System;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Shared;
using ESX.Test.Case.Shared.Entities;

namespace ESX.Test.Case.Domain.Entities
{
	public class User : Entity
	{
		public User(Name name, Email email, SecurityPassword password)
		{
			this.Name = name ?? throw new ArgumentNullException($"The user name can not be null");
			this.Email = email ?? throw new ArgumentNullException($"The user email can not be null");
			this.Password = password ?? throw new ArgumentNullException($"The user password can not be null");
		}

		public Name Name { get; }

		public Email Email { get; }

		public SecurityPassword Password { get; }
	}
}
