using System.Linq;
using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class ClienteRepository : EfRepository<Cliente,Guid>, IClienteRepository
{
    public ClienteRepository(ComercioElectronicoDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteCedula(string cedulaCliente)
    {
         var resultado = await this._context.Set<Cliente>()
                       .AnyAsync(x => x.CedulaCliente.ToUpper() == cedulaCliente.ToUpper());

        return resultado;
    }

    public async Task<Cliente> GetByIdCedulaAsync(string cedulaCliente)
    {
         return await this._context.Set<Cliente>().Where(x=>x.CedulaCliente==cedulaCliente).SingleOrDefaultAsync();
    }
}
