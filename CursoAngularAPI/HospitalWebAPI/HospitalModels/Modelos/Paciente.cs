using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalModels.Modelos;

public partial class Paciente
{
    public long Id { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "DNI")]
    public string Cedula { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    [Required]
    [StringLength(500)]
    public string Direccion { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string Celular { get; set; } = null!;

    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string CorreoElectronico { get; set; } = null!;

    public bool Borrado { get; set; }

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}
