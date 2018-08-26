using System;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Shared;

namespace ESX.Test.Case.Domain.Entities
{
	public class User : Entity
	{
		public User(string name, Email email, Password password)
		{
			this.Name = name;
			this.Email = email ?? throw new ArgumentNullException($"The user email can not be null");
			this.Password = password ?? throw new ArgumentNullException($"The user password can not be null");
			
			if (string.IsNullOrWhiteSpace(this.Name))
				throw new ArgumentNullException($"The user name can not be null or whitespace");
		}

		public string Name { get; }

		public Email Email { get; }

		public Password Password { get; }
	}
}
