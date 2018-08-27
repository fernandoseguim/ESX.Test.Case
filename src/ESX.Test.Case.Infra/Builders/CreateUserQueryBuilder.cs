using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Infra.Builders
{
	public partial class UserQueryBuilder
	{
		public UserQueryBuilder CreateUser(User user)
		{
			this.query = @"INSERT INTO Users (UserID, Name, Email, PasswordHash, Salt) 
							VALUES(@UserID, @Name, @Email, @PasswordHash, @Salt)";
			this.parameters.Add("UserID", user.Id);
			this.parameters.Add("Name", user.Name.ToString());
			this.parameters.Add("Email", user.Email.ToString());
			this.parameters.Add("PasswordHash", user.Password.HashValue);
			this.parameters.Add("Salt", user.Password.Salt);
			return this;
		}
	}
}
