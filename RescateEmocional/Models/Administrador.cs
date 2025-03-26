using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Administrador
{
    public int IdAdmin { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Peticion> Peticions { get; set; } = new List<Peticion>();
}
