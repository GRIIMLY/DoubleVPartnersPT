using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoubleVPartnersBI.BI
{   
    /// <summary>
    /// Finalidad: declarar todos los metodos genericos de transaccion para aplicar la logica de negocio que se requiera
    /// </summary>
    /// <typeparam name="TEntity">Entidad o modelo a la que se aplicarán los metodos</typeparam>
    public interface IGenericBI<TEntity> where TEntity : class
    {
        /// <summary>
        /// Finalidad: logica de negocio requerida para obtener todos los registros de una entidad
        /// </summary>
        /// <returns>retorna los registros encontrados</returns>
        Task<IEnumerable<TEntity>> getAll();

        /// <summary>
        /// Finalidad: logica de negocio requerida para la busqueda de una entidad por id
        /// </summary>
        /// <param name="id">id para filtrar la busqueda de a entidad</param>
        /// <returns>la entidad encontrada</returns>
        Task<TEntity> getById(int id);

        /// <summary>
        /// Finalidad: logica de negocio requerida para insertar una entidad
        /// </summary>
        /// <param name="entity">entidad a insertar a la base de datos</param>
        /// <returns>entidad insertada</returns>
        Task<TEntity> insert(TEntity entity);

        /// <summary>
        /// Finalidad: logica de negocio requerida para la actualizacion de una entidad 
        /// </summary>
        /// <param name="entity">entidad a actualizar</param>
        /// <returns>entidad actualizada</returns>
        Task<TEntity> update(TEntity entity);

        /// <summary>
        /// Finalidad: logica de negocio requerida para la eliminacion de un registro de la base de datos
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
