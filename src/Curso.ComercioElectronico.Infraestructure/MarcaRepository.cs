using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class MarcaRepository : EfRepository<Marca,Guid>, IMarcaRepository
{
    public MarcaRepository(ComercioElectronicoDbContext context) : base(context)
    {
    }

   public async Task<bool> ExisteNombre(string nombre) {

        var resultado = await this._context.Set<Marca>()
                       .AnyAsync(x => x.NombreMarca.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, Guid idExcluir)
    {
        var query =  this._context.Set<Marca>()
                       .Where(x => x.Id != idExcluir)
                       .Where(x => x.NombreMarca.ToUpper() == nombre.ToUpper())
                       ;

        var resultado = await query.AnyAsync();

        return resultado;
    }
}
