using System;
using ESX.Test.Case.Shared.Entities;

namespace ESX.Test.Case.Domain.Repositories
{
	public interface IEntityRepository<in TEntity> where TEntity : Entity
	{
		void Save(TEntity entity);
		bool Delete(Guid id);
	}
}
