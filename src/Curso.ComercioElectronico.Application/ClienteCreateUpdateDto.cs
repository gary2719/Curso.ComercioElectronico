using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class ClienteCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.MAXIMO_CEDULA)]
    public string CedulaCliente { get; set; }
    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string NombreCliente { get; set; }
}
