using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class Entrega
{
    public Entrega()
    {
    }
    public Guid Id{get;set;}

    public virtual Cliente Cliente{get;set;}

    [Required]

    public Guid ClienteId{get;set;}

    public virtual Orden Orden {get;set;}

    [Required]
    public Guid OrdenId{get;set;}

    public string NombreRepartidor{get;set;}
    public string OrdenEstado {get;set;}
    public string DireccionEntrega {get; set;}

    public string EntregaEstado {get;set;}
}

