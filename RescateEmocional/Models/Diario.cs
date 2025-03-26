using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Diario
{
    public int IdDiario { get; set; }

    public int? IdUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
