using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class CancelarEntregaDto
{
    [Required]
    public string EstadoEntrega { get; set; }
}
