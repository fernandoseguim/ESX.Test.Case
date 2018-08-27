using System;
using System.Collections.Generic;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Tests.Infra
{
	internal static class Scripts
	{
		public static Dictionary<Type, string> CreateTable => new Dictionary<Type, string>()
		{
			{ typeof(User), @"CREATE TABLE IF NOT EXISTS Users (UserID UNIQUEIDENTIFIER NOT NULL,
							Name NVARCHAR(120) NOT NULL,
							Email VARCHAR(50) NOT NULL UNIQUE,
							PasswordHash VARCHAR(128) NOT NULL,
							Salt VARCHAR(36) NOT NULL,
							PRIMARY KEY (UserID))" }, 
		};

		public static Dictionary<Type, string> InsertData => new Dictionary<Type, string>()
		{
			{ typeof(User), @"INSERT INTO Users (UserID, Name, Email, PasswordHash, Salt) 
						VALUES ('563C0799-B5D0-4F42-846B-B76A84F134F6', 
								'User de Teste', 
								'teste@gmail.com', 
								'1a88feb0c03d17df329d10ac1d2481c5e53b151a84969ee4c5a3fdb2bdb0c30f566dfd889bc95f9956b46bf001b0966ac6c23448917fbc9405f598d4804d0ab1', 
								'768ebcc6-d559-4c44-babf-1034f78f3c69')" },
		};
	}
}
