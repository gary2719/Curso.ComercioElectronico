namespace Curso.ComercioElectronico.HttpApi.Controllers;

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
     private readonly ITipoProductoAppService tipoProductoAppService;

    public TipoProductoController(ITipoProductoAppService tipoProductoAppService)
    {
        this.tipoProductoAppService = tipoProductoAppService;
    }

    [HttpGet]
    public ICollection<TipoProductoDto> GetAll()
    {

        return tipoProductoAppService.GetAll();
    }

    [HttpPost]
    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {

        return await tipoProductoAppService.CreateAsync(tipoProductoCreateUpdateDto);

    }

    [HttpPut]
    public async Task<TipoProductoDto> UpdateAsync(Guid id, TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {

        return await tipoProductoAppService.UpdateAsync(id, tipoProductoCreateUpdateDto);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(Guid tipoProductoId)
    {

        return await tipoProductoAppService.DeleteAsync(tipoProductoId);

    }
}
