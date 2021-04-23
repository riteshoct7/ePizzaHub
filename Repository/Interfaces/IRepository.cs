using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        #region "Methods"

        IEnumerable<TEntity> GetAll();

        TEntity GetById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Delete(object id);

        int SaveChanges(); 

        #endregion
    }
}
