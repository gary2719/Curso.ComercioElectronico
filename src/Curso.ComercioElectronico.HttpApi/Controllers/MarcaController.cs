namespace Curso.ComercioElectronico.HttpApi.Controllers;

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
    public class MarcaController : ControllerBase
    {
     private readonly IMarcaAppService marcaAppService;

    public MarcaController(IMarcaAppService marcaAppService)
    {
        this.marcaAppService = marcaAppService;
    }

    [HttpGet]
    public ICollection<MarcaDto> GetAll()
    {

        return marcaAppService.GetAll();
    }

    [HttpPost]
    public async Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marcaCreateUpdateDto)
    {

        return await marcaAppService.CreateAsync(marcaCreateUpdateDto);

    }

    [HttpPut]
    public async Task<MarcaDto> UpdateAsync(Guid id, MarcaCreateUpdateDto marcaCreateUpdateDto)
    {

        return await marcaAppService.UpdateAsync(id, marcaCreateUpdateDto);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(Guid marcaId)
    {

        return await marcaAppService.DeleteAsync(marcaId);

    }

    }
