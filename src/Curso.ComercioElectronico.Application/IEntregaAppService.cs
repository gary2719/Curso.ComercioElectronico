namespace Curso.ComercioElectronico.Application;

public interface IEntregaAppService
{
    ICollection<EntregaDto> GetAll();

    Task<EntregaDto> CreateAsync(EntregaCreateUpdateDto entregaCreateUpdateDto);

    Task<EntregaDto> UpdateAsync(Guid entregaid, EntregaCreateUpdateDto entregaCreateUpdateDto);

    Task<bool> DeleteAsync(Guid entregaId);

    Task CancelarEntrega(CancelarEntregaDto cancelarEntregaDto, Guid id);

}
