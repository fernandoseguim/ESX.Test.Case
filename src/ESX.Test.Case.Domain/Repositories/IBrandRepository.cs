using System;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Queries.Response;
using System.Collections.Generic;

namespace ESX.Test.Case.Domain.Repositories
{
	public interface IBrandRepository : IEntityRepository<Brand>
	{
		IEnumerable<BrandQueryResult> GetAll();
		BrandQueryResult GetById(Guid brandId);
		bool CheckBrand(string name);
	}
}
