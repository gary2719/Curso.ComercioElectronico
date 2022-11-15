using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public interface IMarcaAppService
{
    ICollection<MarcaDto> GetAll();

    Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marcaCreateUpdateDto);

    Task<MarcaDto> UpdateAsync(Guid id, MarcaCreateUpdateDto marcaCreateUpdateDto);

    Task<bool> DeleteAsync(Guid marcaId);



}
