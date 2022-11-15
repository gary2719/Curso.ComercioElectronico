namespace Curso.ComercioElectronico.Domain;

public interface ITipoProductoRepository: IRepository<TipoProducto,Guid>
{
    Task<bool> ExisteNombre(string nombre);

    Task<bool> ExisteNombre(string nombre, Guid idExcluir);

    
}
