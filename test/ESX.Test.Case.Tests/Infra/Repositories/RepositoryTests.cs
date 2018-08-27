using ESX.Test.Case.Infra;
using NSubstitute;

namespace ESX.Test.Case.Tests.Infra.Repositories
{
	public abstract class RepositoryTests<T> where T : class
	{
		protected RepositoryTests()
		{
			var fakeDatabase = new InMemoryDatabase();
			fakeDatabase.CreateTable<T>();

			this.Context = Substitute.For<IDatabaseContext>();
			this.Context.Connection.Returns(fakeDatabase.OpenConnection());
		}

		public IDatabaseContext Context { get; }
	}
}