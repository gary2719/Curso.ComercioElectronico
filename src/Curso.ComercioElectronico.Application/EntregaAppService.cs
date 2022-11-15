using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class EntregaAppService : IEntregaAppService
{
    private readonly IEntregaRepository repository;

    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<EntregaAppService> logger;

    public EntregaAppService(IEntregaRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<EntregaAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task CancelarEntrega(CancelarEntregaDto cancelarEntregaDto, Guid id)
    {
        var carrito = await repository.GetByIdAsync(id);
        if (carrito == null)
        {
            throw new ArgumentException($"El carrito con el el {id} no se encuentra registrado.");
        }

        carrito.EntregaEstado = cancelarEntregaDto.EstadoEntrega;
        await repository.UpdateAsync(carrito);
        await repository.UnitOfWork.SaveChangesAsync();
    }

    public async Task<EntregaDto> CreateAsync(EntregaCreateUpdateDto entregaCreateUpdateDto)
    {
        var cliente = mapper.Map<Entrega>(entregaCreateUpdateDto);

        cliente = await repository.AddAsync(cliente);
        await repository.UnitOfWork.SaveChangesAsync();

        var clienteDto = mapper.Map<EntregaDto>(cliente);

        return clienteDto;
    }

    public async Task<bool> DeleteAsync(Guid entregaId)
    {
        var cliente = await repository.GetByIdAsync(entregaId);
        if (cliente == null)
        {
            throw new ArgumentException($"La entrega con el codigo: {entregaId}, no existe");
        }

        repository.Delete(cliente);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<EntregaDto> GetAll()
    {
        var clienteList = repository.GetAll();

        var clienteListDto = from x in clienteList
                             select new EntregaDto(
                            x.Id,
                         x.ClienteId,
                         x.OrdenId,
                         x.NombreRepartidor,
                         x.OrdenEstado,
                         x.DireccionEntrega,
                         x.EntregaEstado
                             );

        return clienteListDto.ToList();
    }

    public async Task<EntregaDto> UpdateAsync(Guid entregaid, EntregaCreateUpdateDto entregaCreateUpdateDto)
    {
        var cliente = await repository.GetByIdAsync(entregaid);
        if (cliente == null)
        {
            throw new ArgumentException($"La entrega con el codigo: {entregaid}, no existe");
        }

        else

            cliente = mapper.Map<EntregaCreateUpdateDto, Entrega>(entregaCreateUpdateDto, cliente);

        await repository.UpdateAsync(cliente);

        await repository.UnitOfWork.SaveChangesAsync();

        var clienteDto = mapper.Map<EntregaDto>(cliente);

        return clienteDto;
    }
}
