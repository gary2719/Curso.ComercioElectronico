using AutoMapper;
using Curso.ComercioElectronico.Domain;
using Microsoft.Extensions.Logging;

namespace Curso.ComercioElectronico.Application;

public class ProductoAppService : IProductoAppService
{

    private readonly IProductoRepository repository;

    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;
    private readonly ILogger<ProductoAppService> logger;

    public ProductoAppService(IProductoRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductoAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoCreateUpdateDto)
    {
        var existeCodigoProducto = await repository.ExisteProducto(productoCreateUpdateDto.CodigoProducto);
        if (existeCodigoProducto){
            throw new ArgumentException($"Ya existe un producto con el código {productoCreateUpdateDto.CodigoProducto}");
        
    }
          var producto = mapper.Map<Producto>(productoCreateUpdateDto);

            producto = await repository.AddAsync(producto);
        await repository.UnitOfWork.SaveChangesAsync();

          var productoDto = mapper.Map<ProductoDto>(producto);

        return productoDto;
    }

    public async Task<bool> DeleteAsync(string codigoProducto)
    {
        var producto = await repository.GetByCodigo(codigoProducto);
        if (producto == null){
            throw new ArgumentException($"El producto con el código: {codigoProducto}, no existe");
        }

        repository.Delete(producto);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ProductoDto> GetAll()
    {
         var productoList = repository.GetAll();

        var productoListDto =  from p in productoList
                            select new ProductoDto(
                            p.Id,
                            p.NombreProducto,
                            p.PrecioProducto,
                            p.CodigoProducto,
                            p.DescripcionProducto,
                            p.MarcaId,
                            p.TipoProductoId    
                            );

        return productoListDto.ToList();
    }

    public IQueryable<ProductoDto> GetByMarcaId(Guid marcaId, int limit = 10, int offset = 0)
    {
            var clienteList = repository.GetAll();

        var clienteListDto =  from p in clienteList
                                where(p.MarcaId==marcaId)
                            select new ProductoDto(
                            p.Id,
                            p.NombreProducto,
                            p.PrecioProducto,
                            p.CodigoProducto,
                            p.DescripcionProducto,
                            p.MarcaId,
                            p.TipoProductoId   
                            );

        return clienteListDto.Skip(offset)
                                .Take(limit).ToList().AsQueryable();
    }
    

    public IQueryable<ProductoDto> GetByNombre(int limit = 10, int offset = 0, string searchString = "")
    {
          var clienteList = repository.GetAll();

        var clienteListDto =  from p in clienteList
                                where(p.NombreProducto.ToUpper().Contains(searchString.ToUpper()))
                            select new ProductoDto(
                            p.Id,
                            p.NombreProducto,
                            p.PrecioProducto,
                            p.CodigoProducto,
                            p.DescripcionProducto,
                            p.MarcaId,
                            p.TipoProductoId   
                            );

        return clienteListDto.Skip(offset)
                                .Take(limit).ToList().AsQueryable();
    }

    public IQueryable<ProductoDto> GetByTipoProductoId(Guid productoId, int limit = 10, int offset = 0)
    {
          var clienteList = repository.GetAll();

        var clienteListDto =  from p in clienteList
                                where(p.MarcaId==productoId)
                            select new ProductoDto(
                            p.Id,
                            p.NombreProducto,
                            p.PrecioProducto,
                            p.CodigoProducto,
                            p.DescripcionProducto,
                            p.MarcaId,
                            p.TipoProductoId   
                            );

        return clienteListDto.Skip(offset)
                                .Take(limit).ToList().AsQueryable();
    }

    public async Task<ProductoDto> UpdateAsync(string codigoProducto, ProductoCreateUpdateDto productoCreateUpdateDto)
    {
        
         var producto = await repository.GetByCodigo(codigoProducto);
        if (producto == null){
            throw new ArgumentException($"El producto con el código: {codigoProducto}, no existe");
        }

        
    else
         
        producto = mapper.Map<ProductoCreateUpdateDto,Producto>(productoCreateUpdateDto, producto);

        await repository.UpdateAsync(producto);
        
        await repository.UnitOfWork.SaveChangesAsync();

         var productoDto = mapper.Map<ProductoDto>(producto);

        return productoDto;
    }
    }

