namespace Curso.ComercioElectronico.Domain;

public interface ICarritoRepository:IRepository<Carrito,Guid>
{
    Task<bool> ExisteCarritoId(Guid idCarrito);

    Task<Carrito>GetTipoCliente(string tipoCliente);

    Task<Carrito> GetByClienteId(Guid clienteid);
    
    

}
