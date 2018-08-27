using System.Data;

namespace ESX.Test.Case.Infra
{
	public class EsxTestCaseDatabaseContext : IDatabaseContext
	{
		public EsxTestCaseDatabaseContext(IDbConnection connection)
		{
			this.Connection = connection;
			this.Connection.Open();
		}

		public IDbConnection Connection { get; }

		public void Dispose()
		{
			if (this.Connection.State != ConnectionState.Closed)
			{
				this.Connection.Close();
			}
		}
	}
}
