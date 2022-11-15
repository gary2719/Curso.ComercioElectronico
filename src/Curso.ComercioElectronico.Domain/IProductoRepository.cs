namespace Curso.ComercioElectronico.Domain;

public interface IProductoRepository: IRepository<Producto,Guid>
{
     Task<bool> ExisteProducto(string codigoProducto);

     Task<Producto> GetByCodigo(string codigoProducto);

     
}
