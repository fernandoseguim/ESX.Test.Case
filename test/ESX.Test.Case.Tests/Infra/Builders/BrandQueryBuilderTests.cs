using System.Linq;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Infra.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESX.Test.Case.Tests.Infra.Builders
{
	[TestClass]
	public partial class BrandQueryBuilderTests : UnitTestBase
	{
		private readonly Brand brand;
		public BrandQueryBuilderTests() => this.brand = new Brand(MockString());

		[TestMethod]
		[Description("Given that I want check name from brand, " +
		             "when building a check name query, " +
		             "then should contains name into statement and parameters")]
		public void Should_contains_name_into_statement_when_building_a_check_brand_query()
		{
			var name = MockString();
			var (query, parameters) = new BrandQueryBuilder()
				.CheckBrand(name)
				.Build();

			Assert.IsTrue(query.Contains("Name") && query.Contains(@"@Name"));
			Assert.IsTrue(parameters.ParameterNames.Contains("Name"));
			Assert.AreEqual(name, parameters.Get<string>("Name"));
		}
	}
}
