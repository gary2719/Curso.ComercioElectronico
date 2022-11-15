using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class Producto
{
    public Producto()
    {

    }

    [Required]
 public Guid Id {get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
 public string NombreProducto{get;set;}

[Required]
 public decimal PrecioProducto{get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_COD_PRODUCTO)]
public string CodigoProducto{get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
 public string DescripcionProducto{get;set;}

[Required]
public Guid MarcaId{get;set;}

public Marca Marca {get;set;}

[Required]
public Guid TipoProductoId{get;set;}

public TipoProducto TipoProducto{get;set;}
}
