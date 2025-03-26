using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int? IdOrganizacion { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<Conversacion> Conversacions { get; set; } = new List<Conversacion>();

    public virtual ICollection<Diario> Diarios { get; set; } = new List<Diario>();

    public virtual Organizacion? IdOrganizacionNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
