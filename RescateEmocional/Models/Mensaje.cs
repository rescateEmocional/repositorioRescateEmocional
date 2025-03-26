using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Mensaje
{
    public int IdMensaje { get; set; }

    public string? Contenido { get; set; }

    public DateTime FechaHora { get; set; }

    public int? IdConversacion { get; set; }

    public virtual Conversacion? IdConversacionNavigation { get; set; }
}
