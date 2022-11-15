using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class OrdenDto
{
    public OrdenDto(Guid id, Guid clienteId, ICollection<OrdenItemDto> items, DateTime fecha, DateTime? fechaAnulacion, decimal total, string? observaciones, string estadoCarrito)
    {
        Id = id;
        ClienteId = clienteId;
        Items = items;
        Fecha = fecha;
        FechaAnulacion = fechaAnulacion;
        Total = total;
        Observaciones = observaciones;
        EstadoCarrito = estadoCarrito;
    }

    [Required]
    public Guid Id {get;set; }
 
   [Required]
    public Guid ClienteId {get;set;}

    public virtual ICollection<OrdenItemDto> Items {get;set;} = new List<OrdenItemDto>();

    [Required]
    public DateTime Fecha {get;set;}

    public DateTime? FechaAnulacion {get;set;}
    

    [Required]
    public decimal Total {get;set;}

    public string? Observaciones { get;set;}

    [Required]
    public string EstadoCarrito {get;set;}

   
}

public class OrdenItemDto {

    public OrdenItemDto(){
    }

    public OrdenItemDto(Guid id, Guid productoId, Guid carritoId, long cantidad, decimal precio, string? observaciones)
    {
        Id = id;
        ProductoId = productoId;
        CarritoId = carritoId;
        Cantidad = cantidad;
        Precio = precio;
        Observaciones = observaciones;
    }

    [Required]
    public Guid Id {get;set; }

    [Required]
    public Guid ProductoId {get; set;}

    [Required]
    public Guid CarritoId {get; set;}

    [Required]
    public long Cantidad {get;set;}

    public decimal Precio {get;set;}

    public string? Observaciones { get;set;}
    
}
