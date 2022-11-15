using System.Linq.Expressions;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Infraestructure;

public class EntregaRepository : EfRepository<Entrega, Guid>, IEntregaRepository
{
    public EntregaRepository(ComercioElectronicoDbContext context) : base(context)
    {
    }

}
