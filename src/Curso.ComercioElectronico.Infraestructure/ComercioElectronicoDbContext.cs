using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class ComercioElectronicoDbContext:DbContext,IUnitOfWork
{
    public DbSet<Marca> Marcas {get;set;}
    public DbSet<Producto> Productos {get;set;}
    public DbSet<TipoProducto> TipoProductos{get;set;}
    public DbSet<Cliente> Clientes{get;set;}
    public DbSet<Carrito> Carritos{get;set;}
    public DbSet<Orden> Ordenes{get;set;}
    public DbSet<Entrega> Entregas{get;set;}
    public DbSet<OrdenItem> OrdenItems{get;set;}
    public DbSet<CarritoItem> CarritoItems{get;set;}

    public string DbPath { get; set; }
    


    public ComercioElectronicoDbContext()

    {

        var folder = Environment.SpecialFolder.LocalApplicationData;

        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(Directory.GetCurrentDirectory(), "../Curso.ComercioElectronico.HttpApi/baseComercioElectronico.sqlite");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)

        => options.UseSqlite($"Data Source={DbPath}");
}
