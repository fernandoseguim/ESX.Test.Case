using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Queries.Response;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Infra.Builders;

namespace ESX.Test.Case.Infra.Repositories
{
	public class BrandRepository : IBrandRepository
	{
		private readonly IDatabaseContext context;
		public BrandRepository(IDatabaseContext context) => this.context = context;

		public IEnumerable<BrandQueryResult> GetAll()
		{
			var (query, parameters) = new BrandQueryBuilder().GetAll().Build();

			var brands = this.context.Connection.Query<BrandQueryResult>(query);

			return brands;
		}

		public BrandQueryResult GetById(Guid brandId)
		{
			var (query, parameters) = new BrandQueryBuilder().GetById(brandId).Build();

			var brand = this.context.Connection.QueryFirstOrDefault<BrandQueryResult>(query, parameters);

			return brand;
		}

		public bool CheckBrand(string name)
		{
			var (query, parameters) = new BrandQueryBuilder().CheckBrand(name).Build();

			var result = this.context.Connection.Query<bool>(query, parameters).FirstOrDefault();
			return result;
		}

		public void Save(Brand brand)
		{
			var (query, parameters) = new BrandQueryBuilder().CreateBrand(brand).Build();

			this.context.Connection.Execute(query, parameters);
		}

		public bool Delete(Guid brandId)
		{
			var (query, parameters) = new BrandQueryBuilder().DeleteBrand(brandId).Build();

			var result = this.context.Connection.Execute(query, parameters);
			return Convert.ToBoolean(result);
		}
	}
}
