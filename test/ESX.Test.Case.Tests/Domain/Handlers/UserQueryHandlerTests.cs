using ESX.Test.Case.Domain.Handlers;
using ESX.Test.Case.Domain.Queries;
using ESX.Test.Case.Domain.Queries.Response;
using ESX.Test.Case.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace ESX.Test.Case.Tests.Domain.Handlers
{
	[TestClass]
	public class UserQueryHandlerTests : UnitTestBase
    {
	    private readonly IUserRepository repository;
	    private readonly IUserQueryHandler userQueryHandler;
	    
	    public UserQueryHandlerTests()
	    {
		    this.repository = Substitute.For<IUserRepository>();
		    this.userQueryHandler = new UserQueryHandler(this.repository);
	    }

	    [TestInitialize]
	    public void Setup()
	    {
		    this.repository.GetAll().Returns(new List<UserQueryResult>());
	    }

		[TestMethod]
	    [Description("When request all users" +
					 "then should return a successful query result")]
		public void Should_return_a_successful_query_result()
		{
			var result = this.userQueryHandler.GetAll();
			Assert.IsInstanceOfType(result, typeof(SuccessfulQueryResult));
		}
    }
}
