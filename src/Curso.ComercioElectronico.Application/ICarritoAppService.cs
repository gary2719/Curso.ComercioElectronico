namespace Curso.ComercioElectronico.Application;

public interface ICarritoAppService
{
    ICollection<CarritoDto> GetAll();

    Task<CarritoDto> CreateAsync(CarritoCreateUpdateDto carritoCreateUpdateDto);

    Task<CarritoDto> UpdateAsync(CarritoCreateUpdateDto carritoCreateUpdateDto, Guid id);

    Task<bool> DeleteAsync(Guid idCliente);


    Task CancelarCarrito(CancelarCarritoDto cancelarCarritoDto, Guid id);
}
