using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Conversacion
{
    public int IdConversacion { get; set; }

    public DateTime FechaInicio { get; set; }

    public string? Mensaje { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
}
