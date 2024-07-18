using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartnersRepository.DTOs
{
    public class PersonaDTO
    {
        public int? Identificador { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? NumeroIdentificacion { get; set; }

        public string? Email { get; set; }

        public string? TipoIdentificacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? NumeroIdentificacionConcatenado { get; set; }

        public string? NombresApellidosConcatenados { get; set; }

        public int? UsuarioId { get; set; }
    }
}
