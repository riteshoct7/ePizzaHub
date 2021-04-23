using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Properties

        protected DbContext db;

        #endregion

        #region Constructors
        public Repository(DbContext _db)
        {
            db = _db;
        }
        #endregion

        #region Methods

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
            TEntity obj = db.Set<TEntity>().Find(id);
            if (obj != null)
            {
                db.Set<TEntity>().Remove(obj);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(object id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        } 

        #endregion
    }
}
