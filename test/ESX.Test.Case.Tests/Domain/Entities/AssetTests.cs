using ESX.Test.Case.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ESX.Test.Case.Tests.Domain.Entities
{
	[TestClass]
	public class AssetTests : UnitTestBase
	{
		private readonly Brand brand;
		public AssetTests() => 
			this.brand = new Brand(base.MockString());

		[TestMethod]
		[Description("Given that name is null, " +
		             "when trying to create a new asset, " +
		             "then should throw argument null exception")]
		public void Should_throw_argument_null_exception_when_trying_to_create_a_new_asset_with_null_name()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Asset(null, this.brand));
		}

		[TestMethod]
		[Description("Given that name is withspace, " +
		             "when trying to create a new asset, " +
		             "then should throw argument null exception")]
		public void Should_throw_argument_null_exception_when_trying_to_create_a_new_asset_with_withspace_name()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Asset("", this.brand));
		}

		[TestMethod]
		[Description("Given that brand is null, " +
		             "when trying to create a new asset, " +
		             "then should throw argument null exception")]
		public void Should_generate_a_register_number_when_trying_to_create_a_new_asset_with_null_brand()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Asset(base.MockString(), null));
		}

		[TestMethod]
		[Description("Given that name is valid, " +
		             "when trying to create a new asset, " +
		             "then should generate a registry number")]
		public void Should_generate_a_register_number_when_trying_to_create_a_new_asset_with_valid_name()
		{
			var asset = new Asset(base.MockString(), this.brand);

			Assert.IsNotNull(asset.Registry);
		}

		[TestMethod]
		[Description("Given that I add a asset description, " +
		             "when I get the description," +
		             "then should return the same description added")]
		public void Should_return_the_same_description_added_when_I_get_the_description()
		{
			var asset = new Asset(base.MockString(), this.brand);
			var description = this.MockString(10);

			asset.AddDescription(description);

			Assert.IsNotNull(asset.Description);
		}
	}
}
