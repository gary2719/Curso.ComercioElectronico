using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class CarritoRepository : EfRepository<Carrito, Guid>, ICarritoRepository
{
    public CarritoRepository(ComercioElectronicoDbContext context) : base(context)
    {
    }

    public async Task<Carrito> GetTipoCliente(string tipoCliente)
    {
    var cliente= await this._context.Set<Carrito>().Where(x=>x.Cliente.TipoCliente==tipoCliente).SingleOrDefaultAsync();

        return cliente;
    }

    public async Task<bool> ExisteCarritoId(Guid idCarrito)
    {
        var resultado = await this._context.Set<Carrito>()
                       .AnyAsync(x => x.Id == idCarrito);

        return resultado;
    }

    public async Task<Carrito> GetByClienteId(Guid clienteid)
    {
         return await this._context.Set<Carrito>().Where(x=>x.Id==clienteid).SingleOrDefaultAsync();
    }
}
