using System;
using Dapper;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Infra.Builders
{
	public partial class UserQueryBuilder
	{
		private readonly User user;
		private readonly DynamicParameters parameters;
		private string query = "";

		public UserQueryBuilder(User user)
		{
			this.user = user ?? throw new ArgumentNullException(nameof(user));
			this.parameters = new DynamicParameters();
		}

		public (string, DynamicParameters) Build() =>
			(this.query, this.parameters);

		private void FormatQuery(string queryItem)
		{
			if (this.query != "") { this.query = $"{this.query} AND"; }
			this.query = $"{this.query} {queryItem}";
		}
	}
}
