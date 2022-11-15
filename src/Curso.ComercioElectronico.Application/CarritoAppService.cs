using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class CarritoAppService : ICarritoAppService
{
    private readonly ICarritoRepository repository;

    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<ProductoAppService> logger;

    public CarritoAppService(ICarritoRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductoAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task CancelarCarrito(CancelarCarritoDto cancelarCarritoDto, Guid id)
    {
        var carrito = await repository.GetByIdAsync(id);
        if (carrito == null)
        {
            throw new ArgumentException($"El carrito con el {id} no esta registrado.");
        }

        carrito.EstadoCarrito = cancelarCarritoDto.EstadoCarrito;
        await repository.UpdateAsync(carrito);
        await repository.UnitOfWork.SaveChangesAsync();


        return;


    }

    public async Task<CarritoDto> CreateAsync(CarritoCreateUpdateDto carritoCreateUpdateDto)
    {
        var carrito = mapper.Map<Carrito>(carritoCreateUpdateDto);

        carrito = await repository.AddAsync(carrito);
        await repository.UnitOfWork.SaveChangesAsync();

        var carritoDto = mapper.Map<CarritoDto>(carrito);

        return carritoDto;
    }

    public async Task<bool> DeleteAsync(Guid idCliente)
    {
        var carrito = await repository.GetByClienteId(idCliente);
        if (carrito == null)
        {
            throw new ArgumentException($"El cliente no tiene carritos.");
        }

        repository.Delete(carrito);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<CarritoDto> GetAll()
    {
        var carritoList = repository.GetAll();


        var carritoDto = mapper.Map<ICollection<CarritoDto>>(carritoList);


        return carritoDto.ToList();


    }

    public async Task<CarritoDto> UpdateAsync(CarritoCreateUpdateDto carritoCreateUpdateDto, Guid id)
    {
        var carrito = await repository.GetByIdAsync(id);
        if (carrito == null)
        {
            throw new ArgumentException($"El carrito con el {id} no esta registrado.");
        }
        else

            carrito = mapper.Map<CarritoCreateUpdateDto, Carrito>(carritoCreateUpdateDto, carrito);

        await repository.UpdateAsync(carrito);

        await repository.UnitOfWork.SaveChangesAsync();

        var carritoDto = mapper.Map<CarritoDto>(carrito);

        return carritoDto;
    }

}
