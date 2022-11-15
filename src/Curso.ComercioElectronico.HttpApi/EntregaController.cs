namespace Curso.ComercioElectronico.HttpApi;

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
       private readonly IEntregaAppService entregaAppService;

    public EntregaController(IEntregaAppService entregaAppService)
    {
        this.entregaAppService = entregaAppService;
    }
    [HttpPost]
    public async Task<EntregaDto> CreateAsync(EntregaCreateUpdateDto entregaCreateUpdateDto)
    {

        return await entregaAppService.CreateAsync(entregaCreateUpdateDto);

    }

    [HttpPut]
    public async Task<EntregaDto> UpdateAsync(Guid id, EntregaCreateUpdateDto entregaCreateUpdateDto)
    {

        return await entregaAppService.UpdateAsync(id, entregaCreateUpdateDto);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(Guid entregaId)
    {

        return await entregaAppService.DeleteAsync(entregaId);

    }

    [HttpPost("cancelar_entrega")]

    public async Task CancelarCarrito(CancelarEntregaDto cancelarEntregaDto, Guid id){
       
       await entregaAppService.CancelarEntrega(cancelarEntregaDto,id);
    }
}
