using System;
using System.Collections.Generic;

namespace ReservaVuelos.Models;

public partial class Reservacione
{
    public int ReservaId { get; set; }

    public int? UsuarioId { get; set; }

    public int? VueloId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public int Pasajeros { get; set; }

    public decimal PrecioTotal { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual Vuelo? Vuelo { get; set; }
}
