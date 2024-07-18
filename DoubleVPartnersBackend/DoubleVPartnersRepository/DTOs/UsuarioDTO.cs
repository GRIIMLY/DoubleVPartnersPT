using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartnersRepository.DTOs
{
    public class UsuarioDTO
    {
        public int? Identificador { get; set; }

        public string? Usuario1 { get; set; }

        public string? Pass { get; set; }

        public DateTime? FechaCreacion { get; set; }

    }
}
