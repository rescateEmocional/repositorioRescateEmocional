using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Telefono
{
    public int IdTelefono { get; set; }

    public string Estado { get; set; } = null!;

    public string TipoDeNumero { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public int? IdOrganizacion { get; set; }

    public virtual Organizacion? IdOrganizacionNavigation { get; set; }
}
