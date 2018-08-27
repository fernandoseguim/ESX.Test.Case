namespace ESX.Test.Case.Infra.Builders
{
	public partial class UserQueryBuilder
	{
		public UserQueryBuilder CreateUser()
		{
			this.query = @"INSERT INTO Users (UserID, Name, Email, PasswordHash, Salt) 
							VALUES(@UserID, @Name, @Email, @PasswordHash, @Salt)";
			this.parameters.Add("UserID", this.user.Id);
			this.parameters.Add("Name", this.user.Name.ToString());
			this.parameters.Add("Email", this.user.Email.ToString());
			this.parameters.Add("PasswordHash", this.user.Password.HashValue);
			this.parameters.Add("Salt", this.user.Password.Salt);
			return this;
		}
	}
}
