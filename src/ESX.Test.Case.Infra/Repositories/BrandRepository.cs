using Dapper;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Infra.Repositories
{
	public class BrandRepository : IBrandRepository
	{
		private readonly IDatabaseContext context;
		public BrandRepository(IDatabaseContext context) => this.context = context;

		public void Save(Brand brand)
		{
			const string QUERY = @"INSERT INTO Brand (BrandID, Name) 
								VALUES (@BrandID, @Name)";

			this.context
				.Connection
				.Execute(QUERY, new { BrandID = brand.Id, Name = brand.Name });
		}
	}
}
