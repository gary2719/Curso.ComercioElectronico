using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class ClienteDto
{
    public ClienteDto(Guid id, string cedulaCliente, string nombreCliente)
    {
        Id = id;
        CedulaCliente = cedulaCliente;
        NombreCliente = nombreCliente;
    }

    [Required]
    public Guid Id { get; set; }
    [Required]
    [StringLength(DominioConstantes.MAXIMO_CEDULA)]
    public string CedulaCliente { get; set; }
    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string NombreCliente { get; set; }
    public string Direccion { get; set; }

}
