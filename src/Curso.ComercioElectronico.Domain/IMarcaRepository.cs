namespace Curso.ComercioElectronico.Domain;

public interface IMarcaRepository:IRepository<Marca,Guid>
{
    Task<bool> ExisteNombre(string nombre);

    Task<bool> ExisteNombre(string nombre, Guid idExcluir);
}
