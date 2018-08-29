using System;
using System.Linq;
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
	public class BrandResposityTests : RepositoryTests<Brand>
	{
		private readonly IBrandRepository repository;

		public BrandResposityTests()
		{
			this.repository = new BrandRepository(this.Context);
		}

		[TestMethod]
		[Description("Given that I has a new brand, " +
					 "when trying to save a new brand in the database, " +
					 "then should save new brand in the users table")]
		public void Should_save_the_new_user_in_the_users_table()
		{
			var brand = new Brand(MockString());

			this.repository.Save(brand);

			this.Context
				.Received()
				.Connection
				.Execute(
					Arg.Is<string>(query => query.Contains("INSERT INTO Brands (BrandID, Name)")),
					Arg.Any<object>());
		}

		[TestMethod]
		[Description("Given that I check if a brand exists in the database, " +
					 "when the brand exists, " +
					 "then should return true")]
		public void Should_return_true_when_brand_exists_in_database()
		{
			var brand = new Brand("Brand Test");

			var result = this.repository.CheckBrand(brand.Name);

			Assert.IsTrue(result);
		}

		[TestMethod]
		[Description("Given that I check if a brand exists in the database, " +
					 "when the brand not exists, " +
					 "then should return false")]
		public void Should_return_false_when_brand_exists_in_database()
		{
			var brand = new Brand(MockString());

			var result = this.repository.CheckBrand(brand.Name);

			Assert.IsFalse(result);
		}

		[TestMethod]
		[Description("Given that I trying delete the brand, " +
					 "when brand identifier not exist on database, " +
					 "then should return false")]
		public void Should_return_false_when_not_found_brand_by_id_to_delete()
		{
			var result = this.repository.Delete(Guid.NewGuid());

			Assert.IsFalse(result);
		}

		[TestMethod]
		[Description("Given that I trying delete the brand, " +
					 "when brand identifier exist on database, " +
					 "then should return true")]
		public void Should_return_true_when_delete_brand_from_database()
		{
			var brand = new Brand(MockString());

			this.repository.Save(brand);

			var result = this.repository.Delete(brand.Id);

			Assert.IsTrue(result);
		}

		//[TestMethod]
		//[Description("Given that I trying delete the brand, " +
		//			 "when brand identifier exist on database, " +
		//			 "then should return true")]
		//public void Should_return_all_users_from_database()
		//{
		//	var result = this.repository.GetAll();

		//	Assert.IsTrue(result.ToList().Any());
		//}
	}
}