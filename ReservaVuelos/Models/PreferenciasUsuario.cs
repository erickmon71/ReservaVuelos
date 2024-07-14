using System;
using System.Collections.Generic;

namespace ReservaVuelos.Models;

public partial class PreferenciasUsuario
{
    public int PreferenciaId { get; set; }

    public int? UsuarioId { get; set; }

    public string Preferencia { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
