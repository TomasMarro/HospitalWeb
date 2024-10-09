using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalModels.Modelos;

public partial class Ingreso
{
    public long Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public int NumeroSala { get; set; }

    [Required]
    public int NumeroCama { get; set; }

    [Required]
    public string Diagnostico { get; set; } = null!;

    public string? Observacion { get; set; }

    public bool Borrado { get; set; }

    [Required]
    public long MedicoId { get; set; }

    [Required]
    public long PacienteId { get; set; }

    public virtual ICollection<Egreso> Egresos { get; set; } = new List<Egreso>();

    public virtual Medico Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;
}
