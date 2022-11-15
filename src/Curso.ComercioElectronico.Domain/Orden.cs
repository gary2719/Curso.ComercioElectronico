using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class Orden
{
    public Orden(){
    }

    [Required]
    public Guid Id {get;set; }

    [Required]
    public Guid ClienteId {get;set;}
   
    public virtual Cliente Cliente {get;set;}

    [Required]
    public Guid CarritoId {get;set;} 

    public virtual Carrito Carrito{get;set;} 

    [Required]
    public string EstadoCarrito {get;set;}  

    public virtual ICollection<OrdenItem> Items {get;set;} = new List<OrdenItem>();

    [Required]
    public DateTime Fecha {get;set;}

    public DateTime? FechaAnulacion {get;set;}
    

    [Required]
    public decimal TotalOrden {get;set;}

    public string? ObservacionesOrden { get;set;}

    [Required]
    public string EstadoOrden {get;set;}

    public void AgregarItem(OrdenItem item){
       
        item.Orden = this;
        Items.Add(item); 
    }
}

public class OrdenItem {

    public OrdenItem(){
    }

    [Required]
    public Guid Id {get;set; }

    [Required]
    public Guid ProductoId {get; set;}

    public virtual Producto Producto { get; set; }

    [Required]
    public Guid OrdenId {get; set;}

    public virtual Orden Orden { get; set; }

    [Required]
    public long CantidadOrdenItems {get;set;}

    public decimal PrecioOrdenItems {get;set;}

    public string? ObservacionesOrdenItems { get;set;}
}


