using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class ProductoCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string NombreProducto { get; set; }

    [Required]
    public decimal PrecioProducto { get; set; }

    [Required]
    [StringLength(DominioConstantes.MAXIMO_COD_PRODUCTO)]
    public string CodigoProducto { get; set; }

    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string DescripcionProducto { get; set; }

    [Required]
    public Guid MarcaId { get; set; }

    [Required]
    public Guid TipoProductoId { get; set; }

}
