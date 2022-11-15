using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class TipoProducto
{
    public TipoProducto()
    {
    }
[Required]
public Guid Id {get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]    
public string NombreTipoProducto{get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string DescripcionTipoProducto {get;set;}

}
