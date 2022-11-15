using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class OrdenAppService:IOrdenAppService
{   
    private readonly IOrdenRepository repository;

    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<OrdenAppService> logger;

    public OrdenAppService(IOrdenRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrdenAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public Task<OrdenDto> CreateAsync(OrdenCreateUpdateDto ordenCreateUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid idCliente)
    {
        throw new NotImplementedException();
    }

    public ICollection<OrdenDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<OrdenDto> UpdateAsync(OrdenCreateUpdateDto ordenCreateUpdateDto, Guid id)
    {
        throw new NotImplementedException();
    }
}
