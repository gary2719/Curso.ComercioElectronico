using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class MarcaAppService : IMarcaAppService
{
    private readonly IMarcaRepository repository;

    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<MarcaAppService> logger;

    public MarcaAppService(IMarcaRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<MarcaAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marcaCreateUpdateDto)
    {
        var existeNombreMarca = await repository.ExisteNombre(marcaCreateUpdateDto.NombreMarca);
        if (existeNombreMarca)
        {
            throw new ArgumentException($"Ya existe una marca con el nombre {marcaCreateUpdateDto.NombreMarca}");

        }
        var marca = mapper.Map<Marca>(marcaCreateUpdateDto);

        marca = await repository.AddAsync(marca);
        await repository.UnitOfWork.SaveChangesAsync();

        var marcaDto = mapper.Map<MarcaDto>(marca);

        return marcaDto;
    }

    public async Task<bool> DeleteAsync(Guid marcaId)
    {
        var marca = await repository.GetByIdAsync(marcaId);
        if (marca == null)
        {
            throw new ArgumentException($"La marca con el id: {marcaId}, no existe");
        }

        repository.Delete(marca);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<MarcaDto> GetAll()
    {
        var marcaList = repository.GetAll();


        var marcaListDto = from m in marcaList
                           select new MarcaDto(
                           m.Id,
                           m.NombreMarca,
                           m.Descripcion
                           );

        return marcaListDto.ToList();
    }

    public async Task<MarcaDto> UpdateAsync(Guid id, MarcaCreateUpdateDto marcaCreateUpdateDto)
    {
        var marca = await repository.GetByIdAsync(id);
        if (marca == null)
        {
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }
        else

            marca = mapper.Map<MarcaCreateUpdateDto, Marca>(marcaCreateUpdateDto, marca);

        await repository.UpdateAsync(marca);

        await repository.UnitOfWork.SaveChangesAsync();

        var marcaDto = mapper.Map<MarcaDto>(marca);

        return marcaDto;
    }
}
