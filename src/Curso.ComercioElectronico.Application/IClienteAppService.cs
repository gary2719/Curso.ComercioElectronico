namespace Curso.ComercioElectronico.Application;

public interface IClienteAppService
{
    ICollection<ClienteDto> GetAll();

    Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteCreateUpdateDto);

    Task<ClienteDto> UpdateAsync(string cedulaCliente, ClienteCreateUpdateDto clienteCreateUpdateDto);

    Task<bool> DeleteAsync(string cedulaCliente);
    ICollection<ClienteDto> GetByCedula(string searchString, int limit = 10, int offset = 0);

    ICollection<ClienteDto> GetByNombre(string searchString, int limit = 10, int offset = 0);

}
