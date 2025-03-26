using System;
using System.Collections.Generic;

namespace RescateEmocional.Models;

public partial class Organizacion
{
    public int IdOrganizacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Horario { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Peticion> Peticions { get; set; } = new List<Peticion>();

    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Etiquetum> IdEtiqueta { get; set; } = new List<Etiquetum>();
}
