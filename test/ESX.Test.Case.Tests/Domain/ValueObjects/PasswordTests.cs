using ESX.Test.Case.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Tests.Domain.ValueObjects
{
	[TestClass]
	public class PasswordTests : UnitTestBase
	{
		[TestMethod]
		[Description("Given that password value is invalid, " +
		             "when trying to create a new password, " +
		             "then should throw argument exception")]
		public void Should_throw_argument_exception_when_trying_to_create_a_new_password_with_invalid_value()
		{
			Assert.ThrowsException<ArgumentException>(() => new Password(this.MockString(5)));
		}

		[TestMethod]
		[Description("Given that password value is valid, " +
		             "when creating a new password, " +
		             "then should mask password value")]
		public void Should_mask_value_when_creating_a_new_password_with_valid_value()
		{
			var value = this.MockString(8);
			var password = new Password(value);
			Assert.AreNotEqual(value, password.MaskedValue);
		}
	}
}
