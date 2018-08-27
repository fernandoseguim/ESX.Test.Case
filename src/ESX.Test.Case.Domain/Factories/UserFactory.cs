using System.Collections.Generic;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.ValueObjects;
using Flunt.Notifications;

namespace ESX.Test.Case.Domain.Factories
{
	public class UserFactory
	{
		public static User Create(UserCommand command)
		{
			var name = new Name(command.FirstName, command.LastName);
			var email = new Email(command.Email);
			var password = new SecurityPassword(command.Password);
			var user = new User(name, email, password);

			return user;
		}
	}
}
