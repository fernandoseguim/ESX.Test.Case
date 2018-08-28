using System;
using Dapper;
using ESX.Test.Case.Domain.Entities;

namespace ESX.Test.Case.Infra.Repositories
{
	public class AssetRepository : IAssetRepository
	{
		private readonly IDatabaseContext context;
		public AssetRepository(IDatabaseContext context) => this.context = context;

		public void Save(Asset asset)
		{
			const string QUERY = @"INSERT INTO Assets (AssetID, Name, Description, Registry, BrandID) 
								VALUES (@AssetID, @Name, @Description, @Registry, @BrandID)";

			this.context
				.Connection
				.Execute(QUERY, new {
					AssetID = asset.Id,
					Name = asset.Name,
					Description = asset.Description,
					Resgistry = asset.Registry,
					BrandID = asset.Brand.Id
				});
		}
	}
}
