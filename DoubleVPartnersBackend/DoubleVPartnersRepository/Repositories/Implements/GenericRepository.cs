
using Microsoft.EntityFrameworkCore;
using DoubleVPartnersRepository.ContextDB;
using System.Linq.Expressions;

namespace DoubleVPartnersRepository.Repositories
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DoubleVPartnersDB _db;
        public GenericRepository(DoubleVPartnersDB _db)
        {
            this._db = _db;
        }
        public async Task delete(int id)
        {
            var entity = await getById(id);
            if (entity == null)
            {
                throw new Exception("La entidad es null");
            }
            this._db.Set<TEntity>().Remove(entity);
            await this._db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> getAll()
        {
            return await this._db.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> getAll(Expression<Func<TEntity, bool>> expression)
        {
            return await this._db.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> getById(int id)
        {
            return await this._db.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> insert(TEntity entity)
        {
            this._db.Set<TEntity>().Add(entity);
            await this._db.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> insertAll(List<TEntity> entities)
        {
            this._db.Set<TEntity>().AddRange(entities);
            await this._db.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> update(TEntity entity)
        {
            this._db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._db.SaveChangesAsync();
            return entity;
        }
    }
}
