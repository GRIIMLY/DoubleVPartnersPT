using DoubleVPartnersRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoubleVPartnersBI.BI.Implements
{
    public class GenericBI<TEntity> : IGenericBI<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> genericRepository;

        public GenericBI(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task delete(int id)
        {
            await genericRepository.delete(id);
        }

        public async Task<IEnumerable<TEntity>> getAll()
        {
            return await genericRepository.getAll();
        }

        public async Task<TEntity> getById(int id)
        {
            return await genericRepository.getById(id);
        }

        public async Task<TEntity> insert(TEntity entity)
        {
            return await genericRepository.insert(entity);
        }

        public async Task<TEntity> update(TEntity entity)
        {
            return await genericRepository.update(entity);
        }

        public async Task<List<TEntity>> insertAll(List<TEntity> entities)
        {
            return await genericRepository.insertAll(entities);
        }

    }
}
