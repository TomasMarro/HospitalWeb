using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalModels.Modelos;

public partial class Medico
{
    public long Id { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "DNI")]
    public string Cedula { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Apellido { get; set; } = null!;

    [Required]
    public bool EsEspecialista { get; set; }

    [Required]
    public bool Habilitado { get; set; }


    public bool Borrado { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Egreso> Egresos { get; set; } = new List<Egreso>();

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}
