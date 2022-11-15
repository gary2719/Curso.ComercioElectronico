using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class EntregaCreateUpdateDto
{
    [Required]

    public Guid ClienteId { get; set; }

    [Required]
    public Guid OrdenId { get; set; }

    public string NombreRepartidor { get; set; }
    public string OrdenEstado { get; set; }
    public string DireccionEntrega { get; set; }

    public string EntregaEstado { get; set; }
}





