using System;
using System.Data;

namespace ESX.Test.Case.Infra
{
	public interface IDatabaseContext : IDisposable
	{
		IDbConnection Connection { get; }
	}
}