using System;
using System.Collections.Generic;

namespace ReservaVuelos.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<PreferenciasUsuario> PreferenciasUsuarios { get; set; } = new List<PreferenciasUsuario>();

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();
}
