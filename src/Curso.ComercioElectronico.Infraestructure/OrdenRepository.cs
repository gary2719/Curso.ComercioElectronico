using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class OrdenRepository : EfRepository<Orden, Guid>, IOrdenRepository
{
    public OrdenRepository(ComercioElectronicoDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteOrdenId(Guid idOrden)
    {
        var resultado = await this._context.Set<Orden>()
                       .AnyAsync(x => x.Id == idOrden);

        return resultado;
    }

    public async Task<Orden> GetByClienteId(Guid clienteid)
    {
        return await this._context.Set<Orden>().Where(x=>x.Id==clienteid).SingleOrDefaultAsync();
    }

    public async Task<Orden> GetTipoCliente(string tipoCliente)
    {
        var cliente= await this._context.Set<Orden>().Where(x=>x.Cliente.TipoCliente==tipoCliente).SingleOrDefaultAsync();

        return cliente;
    }
}
