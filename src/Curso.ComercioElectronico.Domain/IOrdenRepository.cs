namespace Curso.ComercioElectronico.Domain;

public interface IOrdenRepository
{
  Task<bool> ExisteOrdenId(Guid idOrden);

    Task<Orden>GetTipoCliente(string tipoCliente);

    Task<Orden> GetByClienteId(Guid clienteid);

}
