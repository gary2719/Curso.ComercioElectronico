using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class CarritoCreateUpdateDto
{
    [Required]
    public Guid ClienteId { get; set; }

    public virtual ICollection<CarritoItemCreateUpdateDto> Items { get; set; } = new List<CarritoItemCreateUpdateDto>();

    [Required]
    public DateTime Fecha { get; set; }

    public DateTime? FechaAnulacion { get; set; }


    [Required]
    public decimal Total { get; set; }

    public string? Observaciones { get; set; }

    [Required]
    public string EstadoCarrito { get; set; }


}

public class CarritoItemCreateUpdateDto
{

    public CarritoItemCreateUpdateDto()
    {
    }

    [Required]
    public Guid ProductoId { get; set; }

    [Required]
    public Guid CarritoId { get; set; }

    [Required]
    public long Cantidad { get; set; }

    public decimal Precio { get; set; }

    public string? Observaciones { get; set; }
}

