using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Shared;
using ESX.Test.Case.Shared.Commands;
using Flunt.Validations;

namespace ESX.Test.Case.Domain.Commands.Request
{
	public class UserCommand : BaseCommand
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public override bool IsValid()
		{
			base.AddNotifications(new Contract()
				.Requires()
				.HasMinLength(this.FirstName, Name.MINIMUM_FIRST_NAME_SIZE, nameof(this.FirstName),
					$"Firstname does not be lower than {Name.MINIMUM_FIRST_NAME_SIZE} characters")
				.HasMinLength(this.LastName, Name.MINIMUM_LAST_NAME_SIZE, nameof(this.LastName),
					$"Lastname does not be lower than {Name.MINIMUM_LAST_NAME_SIZE} characters")
				.IsEmail(this.Email, nameof(this.Email), "The e-mail address is invalid")
				.HasMinLength(this.Password, SecurityPassword.MINIMUM_PASSWORD_SIZE, nameof(this.Password),
					$"The password does not be lower than {SecurityPassword.MINIMUM_PASSWORD_SIZE} characters")
			);
			return this.Valid;
		}
	}
}