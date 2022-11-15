namespace Curso.ComercioElectronico.HttpApi.Controllers;

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
     private readonly IClienteAppService clienteAppService;

    public ClienteController(IClienteAppService clienteAppService)
    {
        this.clienteAppService = clienteAppService;
    }

    [HttpGet]
    public ICollection<ClienteDto> GetAll()
    {

        return clienteAppService.GetAll();
    }

    [HttpPost]
    public async Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteCreateUpdateDto)
    {

        return await clienteAppService.CreateAsync(clienteCreateUpdateDto);

    }

    [HttpPut]
    public async Task<ClienteDto> UpdateAsync(string cedulaCliente, ClienteCreateUpdateDto clienteCreateUpdateDto)
    {

        return await clienteAppService.UpdateAsync(cedulaCliente, clienteCreateUpdateDto);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(string cedulaCliente)
    {

        return await clienteAppService.DeleteAsync(cedulaCliente);

    }

    [HttpGet("buscar_por_nombre")]
    public ICollection<ClienteDto> GetByNombre(string searchString, int limit = 10, int offset = 0)
    {
        return clienteAppService.GetByNombre(searchString);
    }

    
    [HttpGet("buscar_por_Cedula")]
    public ICollection<ClienteDto> GetByCedula(string searchString, int limit = 10, int offset = 0)
    {
        return clienteAppService.GetByCedula(searchString);
    }
}
