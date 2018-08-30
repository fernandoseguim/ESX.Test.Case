using System;
using System.Collections.Generic;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Queries.Response;

namespace ESX.Test.Case.Domain.Repositories
{
	public interface IAssetRepository : IEntityRepository<Asset>
	{
		IEnumerable<AssetQueryResult> GetAll();
		AssetQueryResult GetById(Guid assetId);
		IEnumerable<AssetQueryResult> GetAllByBrandId(Guid brandId);
		bool Update(Guid id, AssetCommand assetCommand);
	} 
}

