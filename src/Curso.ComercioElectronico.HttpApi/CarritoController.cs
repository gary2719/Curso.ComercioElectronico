namespace Curso.ComercioElectronico.HttpApi;

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
         private readonly ICarritoAppService carritoAppService;

    public CarritoController(ICarritoAppService carritoAppService)
    {
        this.carritoAppService = carritoAppService;
    }

    [HttpPost]
    public async Task<CarritoDto> CreateAsync(CarritoCreateUpdateDto carritoCreateUpdateDto)
    {

        return await carritoAppService.CreateAsync(carritoCreateUpdateDto);

    }

    [HttpPut]
    public async Task<CarritoDto> UpdateAsync(CarritoCreateUpdateDto carritoCreateUpdateDto,Guid id)
    {

        return await carritoAppService.UpdateAsync(carritoCreateUpdateDto,id);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(Guid idCliente)
    {

        return await carritoAppService.DeleteAsync(idCliente);

    }

    [HttpPost("Cancelar_CarritoCompras")]

    public async Task CancelarCarrito(CancelarCarritoDto cancelarCarritoDto, Guid id){
       
       await carritoAppService.CancelarCarrito(cancelarCarritoDto,id);
    }
}

