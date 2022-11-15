using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class ClienteAppService : IClienteAppService
{
    private readonly IClienteRepository repository;

    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<ClienteAppService> logger;

    public ClienteAppService(IClienteRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<ClienteAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteCreateUpdateDto)
    {

        var existeCedulaCliente = await repository.ExisteCedula(clienteCreateUpdateDto.CedulaCliente);
        if (existeCedulaCliente)
        {
            throw new ArgumentException($"Ya hay un cliente registrado con la siguiente cedula {clienteCreateUpdateDto.CedulaCliente}");

        }
        var cliente = mapper.Map<Cliente>(clienteCreateUpdateDto);

        cliente = await repository.AddAsync(cliente);
        await repository.UnitOfWork.SaveChangesAsync();

        var clienteDto = mapper.Map<ClienteDto>(cliente);

        return clienteDto;
    }

    public async Task<bool> DeleteAsync(string cedulaCliente)
    {
        var cliente = await repository.GetByIdCedulaAsync(cedulaCliente);
        if (cliente == null)
        {
            throw new ArgumentException($"El cliente con la cedula: {cedulaCliente} no esta regiatrado");
        }

        repository.Delete(cliente);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ClienteDto> GetAll()
    {
        var clienteList = repository.GetAll();

        var clienteListDto = from c in clienteList
                             select new ClienteDto(
                             c.Id,
                             c.CedulaCliente,
                             c.NombreCliente
                             );

        return clienteListDto.ToList();
    }

    public async Task<ClienteDto> UpdateAsync(string cedulaCliente, ClienteCreateUpdateDto clienteCreateUpdateDto)
    {
        var cliente = await repository.GetByIdCedulaAsync(cedulaCliente);
        if (cliente == null)
        {
            throw new ArgumentException($"El cliente con la cedula: {cedulaCliente} no se encuentra registrado");
        }

        else

            cliente = mapper.Map<ClienteCreateUpdateDto, Cliente>(clienteCreateUpdateDto, cliente);

        await repository.UpdateAsync(cliente);

        await repository.UnitOfWork.SaveChangesAsync();

        var clienteDto = mapper.Map<ClienteDto>(cliente);

        return clienteDto;
    }

    public ICollection<ClienteDto> GetByNombre(string searchString, int limit = 10, int offset = 0)
    {
        var clienteList = repository.GetAll();

        var clienteListDto = from c in clienteList
                             where (c.NombreCliente.ToUpper().Contains(searchString.ToUpper()))
                             select new ClienteDto(
                             c.Id,
                             c.CedulaCliente,
                             c.NombreCliente
                             );

        return clienteListDto.Skip(offset)
                                .Take(limit).ToList();
    }

    public ICollection<ClienteDto> GetByCedula(string searchString, int limit = 10, int offset = 0)
    {
        var clienteList = repository.GetAll();

        var clienteListDto = from c in clienteList
                             where (c.CedulaCliente.ToUpper().Contains(searchString.ToUpper()))
                             select new ClienteDto(
                             c.Id,
                             c.CedulaCliente,
                             c.NombreCliente
                             );

        return clienteListDto.Skip(offset)
                                .Take(limit).ToList();
    }


}
