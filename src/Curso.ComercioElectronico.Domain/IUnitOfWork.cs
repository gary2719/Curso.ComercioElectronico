namespace Curso.ComercioElectronico.Domain;

public interface IUnitOfWork: IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
