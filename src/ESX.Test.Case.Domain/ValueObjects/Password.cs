using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ESX.Test.Case.Domain.ValueObjects
{
	public class Password
	{
		private const string PASSWORD_PATTERN = @"^\w{8,}$";

		private readonly string value;

		public Password(string value) : this (value, null) { }

		public Password(string value, string salt)
		{
			this.value = value;
			this.Salt = salt ?? Guid.NewGuid().ToString();

			if (Regex.IsMatch(this.value ?? "", PASSWORD_PATTERN) == false)
				throw new ArgumentException($"The password value address is invalid");
		}

		public string HashValue => CreateHmacSha512(this.value, this.Salt);

		public string Salt { get; }

		public static bool CompareHashValues(string expectedHash, string comparedHash) 
			=> expectedHash.Equals(comparedHash);

		private static string CreateHmacSha512(string value, string salt)
		{
			var bytesValue = Encoding.UTF8.GetBytes(value);
			var hmac = new HMACSHA512(bytesValue);
			var bytesSalt = Encoding.UTF8.GetBytes(salt);
			var hashValue = hmac.ComputeHash(bytesSalt);

			return GetStringFromHash(hashValue);
		}

		private static string GetStringFromHash(IEnumerable<byte> hashValue)
		{
			var result = new StringBuilder();

			foreach(var item in hashValue)
			{
				result.Append(item.ToString("X2"));
			}
			return result.ToString().ToLower();
		}
	}
}
