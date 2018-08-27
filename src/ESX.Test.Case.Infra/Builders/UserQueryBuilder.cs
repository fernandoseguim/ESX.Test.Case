using System;
using Dapper;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.ValueObjects;

namespace ESX.Test.Case.Infra.Builders
{
	public partial class UserQueryBuilder
	{
		private readonly DynamicParameters parameters;
		private string query = "";

		public UserQueryBuilder()
		{
			this.parameters = new DynamicParameters();
		}

		public UserQueryBuilder CheckEmail(Email email)
		{
			this.query = @"SELECT 1 FROM Users WHERE Email = @Email";
			this.parameters.Add("Email", email.ToString());
			return this;
		}

		public (string, DynamicParameters) Build() =>
			(this.query, this.parameters);
	}
}
