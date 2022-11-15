using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class ProductoRepository : EfRepository<Producto,Guid>, IProductoRepository
{
    public ProductoRepository(ComercioElectronicoDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteProducto(string codigoProducto)
    {
        var resultado = await this._context.Set<Producto>()
                       .AnyAsync(x => x.CodigoProducto.ToUpper() == codigoProducto.ToUpper());

        return resultado;
    }

    public async Task<Producto> GetByCodigo(string codigoProducto)
    {
         return await this._context.Set<Producto>().Where(x=>x.CodigoProducto.ToUpper()==codigoProducto.ToUpper()).SingleOrDefaultAsync();
    }

}