using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class TipoProductoCreateUpdateDto

{
    
[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string NombreTipoProducto{get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string DescripcionTipoProducto{get;set;} 
}
