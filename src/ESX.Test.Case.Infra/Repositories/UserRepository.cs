using Dapper;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Infra.Builders;

namespace ESX.Test.Case.Infra.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IDatabaseContext context;

		public UserRepository(IDatabaseContext context) => this.context = context;

		public void Save(User user)
		{
			var (query, parameters) = new UserQueryBuilder(user).CreateUser().Build();

			this.context.Connection.Execute(query, parameters);
		}

		public bool CheckEmail(Email email) => throw new System.NotImplementedException();

		public bool CheckPassword(SecurityPassword password) => throw new System.NotImplementedException();
	}
}
