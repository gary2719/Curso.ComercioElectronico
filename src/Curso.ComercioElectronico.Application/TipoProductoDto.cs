using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class TipoProductoDto
{
    public TipoProductoDto(Guid id, string nombreTipoProducto, string descripcionTipoProducto)
    {
        Id = id;
        NombreTipoProducto = nombreTipoProducto;
        DescripcionTipoProducto = descripcionTipoProducto;
    }

    [Required]
public Guid Id {get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string NombreTipoProducto{get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string DescripcionTipoProducto{get;set;}
}
