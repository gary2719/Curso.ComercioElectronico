namespace Curso.ComercioElectronico.Domain;

public interface IClienteRepository: IRepository<Cliente,Guid>
{
     Task<bool> ExisteCedula(string cedulaCliente);

     Task<Cliente> GetByIdCedulaAsync(string cedulaCliente);

    
}
