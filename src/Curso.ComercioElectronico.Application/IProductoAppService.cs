namespace Curso.ComercioElectronico.Application;

public interface IProductoAppService
{
    ICollection<ProductoDto> GetAll();

    Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoCreateUpdateDto);

    Task<ProductoDto> UpdateAsync(string codigoProducto, ProductoCreateUpdateDto productoCreateUpdateDto);

    Task<bool> DeleteAsync(string codigoProducto);

    IQueryable<ProductoDto> GetByNombre(int limit = 10, int offset = 0, string searchString = "");
    IQueryable<ProductoDto> GetByTipoProductoId(Guid productoId, int limit = 10, int offset = 0);
    IQueryable<ProductoDto> GetByMarcaId(Guid marcaId, int limit = 10, int offset = 0);


}
