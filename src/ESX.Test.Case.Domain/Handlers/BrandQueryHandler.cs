﻿using ESX.Test.Case.Shared.Queries;
using System;
using ESX.Test.Case.Domain.Queries.Response;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Shared.Commands;

namespace ESX.Test.Case.Domain.Handlers
{
	public class BrandQueryHandler : IBrandQueryHandler
	{
		private readonly IBrandRepository repository;

		public BrandQueryHandler(IBrandRepository repository) => this.repository = repository;


		public IQueryResult GetAll()
		{
			try
			{
				var result = this.repository.GetAll();

				return new SuccessfulQueryResult(result);
			}
			catch (Exception ex)
			{
				return new UnsuccessfulQueryResult(StatusCodeResult.InternalServerError, ex.Message);
			}
		}

		public IQueryResult GetById(string id)
		{
			try
			{
				if (Guid.TryParse(id, out var brandId))
				{
					var brand = this.repository.GetById(brandId);
					if (brand is null)
					{
						return new UnsuccessfulQueryResult(StatusCodeResult.NotFound,
							$"The brand {brandId} not found");
					}

					return new SuccessfulQueryResult(brand);
				}

				return new UnsuccessfulQueryResult(StatusCodeResult.BadRequest,
					"The brand identifier should be a valid GUID");
			}
			catch (Exception ex)
			{
				return new UnsuccessfulQueryResult(StatusCodeResult.InternalServerError,
					"There was an error saving the user, please contact your system administrator.");
			}
		}
	}
}
