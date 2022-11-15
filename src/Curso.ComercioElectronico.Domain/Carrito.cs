using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class Carrito
{
    public Carrito()
    { }

    [Required]
    public Guid Id {get;set; }
 
    public virtual Cliente Cliente {get;set;}

   [Required]
    public Guid ClienteId {get;set;}

    public virtual ICollection<CarritoItem> Items {get;set;} = new List<CarritoItem>();

    [Required]
    public DateTime Fecha {get;set;}

    public DateTime? FechaAnulacion {get;set;}
    

    [Required]
    public decimal Total {get;set;}

    public string? Observaciones { get;set;}

    [Required]
    public string EstadoCarrito {get;set;}

    public void AgregarItem(CarritoItem item){
       
        item.Carrito = this;
        Items.Add(item); 
    }
}

public class CarritoItem {

    public CarritoItem(){
    }

    [Required]
    public Guid Id {get;set; }

    [Required]
    public Guid ProductoId {get; set;}

    public virtual Producto Producto { get; set; }

    [Required]
    public Guid CarritoId {get; set;}

    public virtual Carrito Carrito { get; set; }

    [Required]
    public long Cantidad {get;set;}

    public decimal Precio {get;set;}

    public string? Observaciones { get;set;}
}

