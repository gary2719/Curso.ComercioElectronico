using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class CancelarCarritoDto
{
    [Required]
    public string EstadoCarrito { get; set; }
}
