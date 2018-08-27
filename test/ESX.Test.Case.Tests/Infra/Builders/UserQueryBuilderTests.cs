using System.Linq;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Infra.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESX.Test.Case.Tests.Infra.Builders
{
	[TestClass]
	public partial class UserQueryBuilderTests
	{
		private readonly User user;
		public UserQueryBuilderTests()
		{
			var name = new Name("Fernando", "Seguim");
			var email = new Email("fernando.seguim@gmail.com");
			var password = new SecurityPassword("12634567890");
			this.user = new User(name, email, password);
		}

		[TestMethod]
		[Description("Given that I want check email from user, " +
		             "when building a check email query, " +
		             "then should contains email into statement and parameters")]
		public void Should_contains_email_into_statement_when_building_a_check_email_query()
		{
			var (query, parameters) = new UserQueryBuilder()
				.CheckEmail(this.user.Email)
				.Build();

			Assert.IsTrue(query.Contains("Email") && query.Contains(@"@Email"));
			Assert.IsTrue(parameters.ParameterNames.Contains("Email"));
			Assert.AreEqual(this.user.Email.ToString(), parameters.Get<string>("Email"));
		}
	}
}
