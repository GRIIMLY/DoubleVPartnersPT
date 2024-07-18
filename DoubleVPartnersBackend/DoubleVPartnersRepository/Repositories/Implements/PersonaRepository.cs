
using Repositories.Repositories;
using DoubleVPartnersRepository.Models;
using DoubleVPartnersRepository.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using DoubleVPartnersRepository.DTOs;

namespace DoubleVPartnersRepository.Repositories.Implements
{
    internal class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public readonly DoubleVPartnersDB _db;

        public PersonaRepository(DoubleVPartnersDB _db) : base(_db)
        {
            this._db = _db;
        }

        public async Task<Persona> GetPersonaPorIdUsuario(int IdUsuario)
        {
            return await this._db.Personas.Where(persona => persona.UsuarioId == IdUsuario).FirstOrDefaultAsync();
        }
        public async Task<List<PersonaDTO>> GetPersonasSP()
        {
            var results = new List<PersonaDTO>();

            using (var command = this._db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_ConsultarPersonas";
                command.CommandType = CommandType.StoredProcedure;
                await this._db.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = new PersonaDTO
                        {
                            Identificador = reader.GetInt32(reader.GetOrdinal("Identificador")),
                            Nombres = reader.GetString(reader.GetOrdinal("Nombres")),
                            Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
                            NumeroIdentificacion = reader.GetString(reader.GetOrdinal("NumeroIdentificacion")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            TipoIdentificacion = reader.GetString(reader.GetOrdinal("TipoIdentificacion")),
                            FechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion")),
                            NumeroIdentificacionConcatenado = reader.GetString(reader.GetOrdinal("NumeroIdentificacionConcatenado")),
                            NombresApellidosConcatenados = reader.GetString(reader.GetOrdinal("NombresApellidosConcatenados")),
                            UsuarioId = reader.GetInt32(reader.GetOrdinal("UsuarioId")),

                            // Otros campos devueltos por tu procedimiento almacenado
                        };
                        results.Add(result);
                    }
                }
            }

            return results;
        }

    }

}
