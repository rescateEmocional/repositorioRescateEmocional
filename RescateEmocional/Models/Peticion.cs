using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Peticion
{
    public int IdPeticion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public string? Comentarios { get; set; }

    public int? IdOrganizacion { get; set; }

    public int? IdAdmin { get; set; }

    public virtual Administrador? IdAdminNavigation { get; set; }

    public virtual Organizacion? IdOrganizacionNavigation { get; set; }
}
