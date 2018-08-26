using System;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESX.Test.Case.Tests.Domain.Entities
{
	[TestClass]
	public class UserTests : UnitTestBase
	{
		private readonly Email email;
		private readonly Password password;

		public UserTests()
		{
			this.email = new Email("fernando.seguim@gmail.com");
			this.password = new Password(this.MockString());
		}

		[TestMethod]
		[Description("Given that name is null, " +
		             "when trying to create a new user, " +
		             "then should throw argument null exception")]
		public void Should_throw_argument_null_exception_when_trying_to_create_a_new_user_with_null_name()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new User(null, this.email, this.password));
		}

		[TestMethod]
		[Description("Given that name is withspace, " +
		             "when trying to create a new user, " +
		             "then should throw argument null exception")]
		public void Should_throw_argument_null_exception_when_trying_to_create_a_new_user_with_withspace_name()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new User("", this.email, this.password));
		}

		[TestMethod]
		[Description("Given that e-mail is null, " +
		             "when trying to create a new user, " +
		             "then should throw argument null exception")]
		public void Should_throw_argument_null_exception_when_trying_to_create_a_new_user_with_null_email()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new User(this.MockString(), null, this.password));
		}

		[TestMethod]
		[Description("Given that e-mail is null, " +
		             "when trying to create a new user, " +
		             "then should throw argument null exception")]
		public void Should_throw_argument_null_exception_when_trying_to_create_a_new_user_with_null_password()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new User(this.MockString(), null, this.password));
		}
	}
}
