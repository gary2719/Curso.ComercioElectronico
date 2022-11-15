using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class OrdenCreateUpdateDto
{
    public OrdenCreateUpdateDto(Guid clienteId, ICollection<CarritoItemCreateUpdateDto> items, DateTime fecha, DateTime? fechaAnulacion, decimal total, string? observaciones, string estado)
    {
        ClienteId = clienteId;
        Items = items;
        Fecha = fecha;
        FechaAnulacion = fechaAnulacion;
        Total = total;
        Observaciones = observaciones;
        Estado = estado;
    }

    [Required]
    public Guid ClienteId {get;set;}

    public virtual ICollection<CarritoItemCreateUpdateDto> Items {get;set;} = new List<CarritoItemCreateUpdateDto>();

    [Required]
    public DateTime Fecha {get;set;}

    public DateTime? FechaAnulacion {get;set;}
    

    [Required]
    public decimal Total {get;set;}

    public string? Observaciones { get;set;}

    [Required]
    public string Estado {get;set;}

   
}

public class OrdeItemCreateUpdateDto {
    public OrdeItemCreateUpdateDto(Guid productoId, Guid carritoId, long cantidad, decimal precio, string? observaciones)
    {
        ProductoId = productoId;
        CarritoId = carritoId;
        Cantidad = cantidad;
        Precio = precio;
        Observaciones = observaciones;
    }

    [Required]
    public Guid ProductoId {get; set;}

    [Required]
    public Guid CarritoId {get; set;}

    [Required]
    public long Cantidad {get;set;}

    public decimal Precio {get;set;}

    public string? Observaciones { get;set;}
}
