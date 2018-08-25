using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ESX.Test.Case.Domain.ValueObjects
{
	public class Password
	{
		private const string PASSWORD_PATTERN = @"^\w{8,}$";

		private readonly string value;

		public Password(string value)
		{
			this.value = value;
			if (Regex.IsMatch(this.value ?? "", PASSWORD_PATTERN) == false)
				throw new ArgumentException($"The password value address is invalid");
		}
		
		public string MaskedValue
		{
			get
			{
				var bytes = Encoding.ASCII.GetBytes(this.value);
				return Convert.ToBase64String(bytes);
			}
		}
	}
}
