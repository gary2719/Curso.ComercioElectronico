namespace Curso.ComercioElectronico.Application;

public interface ITipoProductoAppService
{
    ICollection<TipoProductoDto> GetAll();

    Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto);

    Task<TipoProductoDto> UpdateAsync(Guid id, TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto);

    Task<bool> DeleteAsync(Guid tipoProductoId);

}
