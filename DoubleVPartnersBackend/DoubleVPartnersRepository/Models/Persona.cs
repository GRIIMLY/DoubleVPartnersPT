using System;
using System.Collections.Generic;

namespace DoubleVPartnersRepository.Models;

public partial class Persona
{
    public int Identificador { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? NumeroIdentificacion { get; set; }

    public string? Email { get; set; }

    public string? TipoIdentificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? NumeroIdentificacionConcatenado { get; set; }

    public string? NombresApellidosConcatenados { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
