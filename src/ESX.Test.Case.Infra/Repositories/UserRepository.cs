using System.Linq;
using Dapper;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Repositories;
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
			var (query, parameters) = new UserQueryBuilder().CreateUser(user).Build();

			this.context.Connection.Execute(query, parameters);
		}

		public bool CheckEmail(Email email)
		{
			var (query, parameters) = new UserQueryBuilder().CheckEmail(email).Build();

			var result = this.context.Connection.Query<bool>(query, parameters).FirstOrDefault();
			return result;
		}

		public bool CheckPassword(SecurityPassword password) => throw new System.NotImplementedException();
	}
}
