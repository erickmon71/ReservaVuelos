using System;
using System.Collections.Generic;

namespace ReservaVuelos.Models;

public partial class Vuelo
{
    public int VueloId { get; set; }

    public string Aerolinea { get; set; } = null!;

    public string CiudadSalida { get; set; } = null!;

    public string CiudadLlegada { get; set; } = null!;

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();
}
