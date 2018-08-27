using Dapper;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ESX.Test.Case.Tests.Infra.Repositories
{
	[TestClass]
	public class UserResposityTests : RepositoryTests<User>
	{
		private readonly IUserRepository repository;

		public UserResposityTests()
		{
			this.repository = new UserRepository(this.Context);
		}

		[TestMethod]
		[Description("Given that I has a new user, " +
					 "when trying to save a new user in the database, " +
					 "then should save new user in the users table")]
		public void Should_save_the_new_user_in_the_users_table()
		{
			var name = new Name("Fernando", "Seguim");
			var email = new Email("fernando.seguim@gmail.com");
			var password = new SecurityPassword("12634567890");
			var user = new User(name, email, password);

			this.repository.Save(user);

			this.Context
				.Received()
				.Connection
				.Execute(
					Arg.Is<string>(query => query.Contains("INSERT INTO Users (UserID, Name, Email, PasswordHash, Salt)")), 
					Arg.Any<object>());
		}

		[TestMethod]
		[Description("Given that I check if a emails exists in the database, " +
		             "when the email exists, " +
		             "then should return true")]
		public void Should_return_true_when_email_exists_in_database()
		{
			var email = new Email("teste@gmail.com");
			
			var result = this.repository.CheckEmail(email);

			Assert.IsTrue(result);
		}

		[TestMethod]
		[Description("Given that I check if a emails exists in the database, " +
		             "when the email not exists, " +
		             "then should return false")]
		public void Should_return_false_when_email_exists_in_database()
		{
			var email = new Email($"{this.MockString()}@teste.com");

			var result = this.repository.CheckEmail(email);

			Assert.IsFalse(result);
		}
	}
}