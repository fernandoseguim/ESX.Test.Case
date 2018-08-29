using System.Collections.Generic;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Queries;
using ESX.Test.Case.Domain.ValueObjects;

namespace ESX.Test.Case.Domain.Repositories
{
	public interface IBrandRepository : IEntityRepository<Brand>
	{
		//IEnumerable<BrandQueryResult> GetAll();
		//BrandQueryResult GetById(string brandId);
		bool CheckBrand(string name);
	}
}
