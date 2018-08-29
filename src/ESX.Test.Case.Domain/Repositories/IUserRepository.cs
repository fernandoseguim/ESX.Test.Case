using System.Collections.Generic;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Queries;
using ESX.Test.Case.Domain.ValueObjects;

namespace ESX.Test.Case.Domain.Repositories
{
	public interface IUserRepository : IEntityRepository<User>
	{
		IEnumerable<UserQueryResult> GetAll();
		bool CheckEmail(Email email);
	}
}
