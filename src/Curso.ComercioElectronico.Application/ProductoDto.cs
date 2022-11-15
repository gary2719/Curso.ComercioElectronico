using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class ProductoDto
{
    public ProductoDto(Guid id, string nombreProducto, decimal precioProducto, string codigoProducto, string descripcionProducto, Guid marcaId, Guid tipoProductoId)
    {
        Id = id;
        NombreProducto = nombreProducto;
        PrecioProducto = precioProducto;
        CodigoProducto = codigoProducto;
        DescripcionProducto = descripcionProducto;
        MarcaId = marcaId;
        TipoProductoId = tipoProductoId;
    }

    [Required]
    public Guid Id { get; set; }

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
