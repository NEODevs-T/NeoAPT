using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeoAPTB.NeoModels;

public partial class Personal
{
    public int IdPersonal { get; set; }

    [Required(ErrorMessage = "El campo Nombre es requerido")]
    public string? PeNombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es requerido")]
    public string? PeApellido { get; set; }

    [Required(ErrorMessage = "El campo Ficha es requerido")]
    public string? PeFicha { get; set; }

    [Required(ErrorMessage = "El campo Estado es requerido")]
    public bool? PeEstado { get; set; }

    [Required(ErrorMessage = "El campo Grupo es requerido")]
    public string? PeGrupo { get; set; }

    public virtual ICollection<Plantilla> Plantillas { get; set; } = new List<Plantilla>();

    public virtual ICollection<Resuman> Resumen { get; set; } = new List<Resuman>();
}
