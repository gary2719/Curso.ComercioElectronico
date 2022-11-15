using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class CarritoDto

{
    private ICollection<CarritoItem> items;


    public CarritoDto(Guid id, Guid clienteId, ICollection<CarritoItem> items, DateTime fecha, DateTime? fechaAnulacion, decimal total, string? observaciones, string estadoCarrito)
    {
        Id = id;
        ClienteId = clienteId;
        this.items = items;
        Fecha = fecha;
        FechaAnulacion = fechaAnulacion;
        Total = total;
        Observaciones = observaciones;
        EstadoCarrito = estadoCarrito;
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid ClienteId { get; set; }

    public virtual ICollection<CarritoItemDto> Items { get; set; } = new List<CarritoItemDto>();

    [Required]
    public DateTime Fecha { get; set; }

    public DateTime? FechaAnulacion { get; set; }


    [Required]
    public decimal Total { get; set; }

    public string? Observaciones { get; set; }

    [Required]
    public string EstadoCarrito { get; set; }


}

public class CarritoItemDto
{

    public CarritoItemDto()
    {
    }

    public CarritoItemDto(Guid id, Guid productoId, Guid carritoId, long cantidad, decimal precio, string? observaciones)
    {
        Id = id;
        ProductoId = productoId;
        CarritoId = carritoId;
        Cantidad = cantidad;
        Precio = precio;
        Observaciones = observaciones;
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid ProductoId { get; set; }

    [Required]
    public Guid CarritoId { get; set; }

    [Required]
    public long Cantidad { get; set; }

    public decimal Precio { get; set; }

    public string? Observaciones { get; set; }


}

