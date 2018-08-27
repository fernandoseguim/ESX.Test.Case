using ESX.Test.Case.Shared.Entities;

namespace ESX.Test.Case.Infra.Repositories
{
	public interface IEntityRepository<in TEntity> where TEntity : Entity
	{
		void Save(TEntity entity);
	}
}
