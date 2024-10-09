using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalModels.Modelos;

public partial class Egreso
{
    public long Id { get; set; }

    public DateTime Fecha { get; set; }

    public string? Tratamiento { get; set; }

    [Required]
    [Range(0, 999999999999999999.99)]
    public decimal Monto { get; set; }

    public bool Borrado { get; set; }

    [Required]
    public long MedicoId { get; set; }

    [Required]
    public long IngresoId { get; set; }

    public virtual Ingreso Ingreso { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;
}
