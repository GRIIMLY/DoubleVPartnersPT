using System;
using System.Collections.Generic;

namespace DoubleVPartnersRepository.Models;

public partial class Usuario
{
    public int? Identificador { get; set; }

    public string? Usuario1 { get; set; }

    public string? Pass { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
