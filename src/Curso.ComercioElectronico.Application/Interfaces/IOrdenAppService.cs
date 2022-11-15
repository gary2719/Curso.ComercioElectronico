namespace Curso.ComercioElectronico.Application;

public interface IOrdenAppService
{
    ICollection<OrdenDto> GetAll();

    Task<OrdenDto> CreateAsync(OrdenCreateUpdateDto ordenCreateUpdateDto);

    Task<OrdenDto> UpdateAsync(OrdenCreateUpdateDto ordenCreateUpdateDto, Guid id);

    Task<bool> DeleteAsync(Guid idCliente);
}
