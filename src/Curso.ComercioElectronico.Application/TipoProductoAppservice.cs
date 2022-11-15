using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class TipoProductoAppservice : ITipoProductoAppService
{
    private readonly ITipoProductoRepository repository;
    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<TipoProductoAppservice> logger;

    public TipoProductoAppservice(ITipoProductoRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<TipoProductoAppservice> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        var existeNombreTipoProducto = await repository.ExisteNombre(tipoProductoCreateUpdateDto.NombreTipoProducto);
        if (existeNombreTipoProducto){
            throw new ArgumentException($"Ya existe un tipo de producto con el nombre {tipoProductoCreateUpdateDto.NombreTipoProducto}");
        
    }
         var tipoProducto = mapper.Map<TipoProducto>(tipoProductoCreateUpdateDto);

          tipoProducto = await repository.AddAsync(tipoProducto);
        await repository.UnitOfWork.SaveChangesAsync();

          var tipoProductoDto = mapper.Map<TipoProductoDto>(tipoProducto);

        return tipoProductoDto;
    }

    public async Task<bool> DeleteAsync(Guid tipoProductoId)
    {
       var tipoProducto = await repository.GetByIdAsync(tipoProductoId);
        if (tipoProducto == null){
            throw new ArgumentException($"El tipo de producto con el id: {tipoProductoId}, no existe");
        }

        repository.Delete(tipoProducto);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<TipoProductoDto> GetAll()
    {
       var tipoProductoList = repository.GetAll();

        var tipoProductoListDto =  from t in tipoProductoList
                            select new TipoProductoDto(
                             t.Id,
                             t.NombreTipoProducto,
                             t.DescripcionTipoProducto
                            );

        return tipoProductoListDto.ToList();
    }

    public async Task<TipoProductoDto> UpdateAsync(Guid id, TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
         var tipoProducto = await repository.GetByIdAsync(id);
        if (tipoProducto == null){
            throw new ArgumentException($"El tipo de producto con el: {id}, no existe");
        }
        else
         
        tipoProducto = mapper.Map<TipoProductoCreateUpdateDto,TipoProducto>(tipoProductoCreateUpdateDto, tipoProducto);

        await repository.UpdateAsync(tipoProducto);
        
        await repository.UnitOfWork.SaveChangesAsync();

         var tipoProductoDto = mapper.Map<TipoProductoDto>(tipoProducto);

        return tipoProductoDto;


    }
}
