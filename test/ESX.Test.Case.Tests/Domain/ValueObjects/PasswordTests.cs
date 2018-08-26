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
			Assert.AreNotEqual(value, password.HashValue);
		}

		[TestMethod]
		[Description("Given that compared hash value is the different expected hash value," +
		             "when compare hash values, " +
		             "then should return false")]
		public void Should_return_false_when_comparing_different_hash_values()
		{
			var expectedValue = this.MockString(8);
			var comparedValue = this.MockString(9);
			var expectedPassword = new Password(expectedValue);
			var comparedPassword = new Password(comparedValue);

			Assert.IsFalse(Password.CompareHashValues(expectedPassword.HashValue, comparedPassword.HashValue));
		}

		[TestMethod]
		[Description("Given that compared hash value is the same expected hash value," +
		             "when compare hash values, " +
		             "then should return true")]
		public void Should_return_true_when_comparing_equal_hash_values()
		{
			var value = this.MockString(8);
			var expectedPassword = new Password(value);
			var salt = expectedPassword.Salt;
			var comparedPassword = new Password(value, salt);
			
			Assert.IsTrue(Password.CompareHashValues(expectedPassword.HashValue, comparedPassword.HashValue));
		}
	}
}
