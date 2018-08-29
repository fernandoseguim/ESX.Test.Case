using ESX.Test.Case.Shared.Queries;
using System;
using ESX.Test.Case.Domain.Queries.Response;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Shared.Commands;

namespace ESX.Test.Case.Domain.Handlers
{
	public class UserQueryHandler : IUserQueryHandler
	{
		private readonly IUserRepository repository;

		public UserQueryHandler(IUserRepository repository) => this.repository = repository;


		public IQueryResult GetAll()
		{
			try
			{
				var result = this.repository.GetAll();

				return new SuccessfulQueryResult(result);
			}
			catch (Exception ex)
			{
				return new UnsuccessfulQueryResult(StatusCodeResult.InternalServerError,ex.Message);
			}
		}
	}
}
