
using System.Linq.Expressions;

namespace DoubleVPartnersRepository.Repositories
{
    /// <summary>
    /// Finalidad: definir todos los metodos genericos correspondientes a base de datos
    /// </summary>
    /// <typeparam name="TEntity">Entidad o modelo de base de datos a la cual se le aplicarán los metodos</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Finalidad Obtener todos los registros de una entidad
        /// </summary>
        /// <returns>Retorna los registros correspondientes</returns>
        Task<IEnumerable<TEntity>> getAll();

        /// <summary>
        /// Finalidad Obtener todos los registros de una entidad
        /// </summary>
        /// <returns>Retorna los registros correspondientes</returns>
        Task<IEnumerable<TEntity>> getAll(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Finalidad: obtener una entidad por id 
        /// </summary>
        /// <param name="id">Es requerido para poder filtrar</param>
        /// <returns>retorna la entidad filtrada por id</returns>
        Task<TEntity> getById(int id);

        /// <summary>
        /// Finalidad: insertar una entidad a la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> insert(TEntity entity);

        /// <summary>
        /// Finalidad: actualizar una entidad
        /// </summary>
        /// <param name="entity">entidad a actualizar</param>
        /// <returns>retorna la entidad actualizada</returns>
        Task<TEntity> update(TEntity entity);

        /// <summary>
        /// Finalidad : eliminar un registro 
        /// </summary>
        /// <param name="id">identificador del registro</param>
        /// <returns></returns>
        Task delete(int id);

        /// <summary>
        /// Finalidad : agregar varios registros
        /// </summary>
        /// <param name="id">identificador del registro</param>
        /// <returns></returns>
        Task<List<TEntity>> insertAll(List<TEntity> entities);


    }
}
