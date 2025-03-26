using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Etiquetum
{
    public int IdEtiqueta { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Organizacion> IdOrganizacions { get; set; } = new List<Organizacion>();
}
