using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class Cliente
{
    public Cliente()
    {

    }

    [Required]
    public Guid Id { get; set; }
    [Required]
    [StringLength(DominioConstantes.MAXIMO_CEDULA)]
    public string CedulaCliente { get; set; }
    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string NombreCliente { get; set; }

    public string TipoCliente { get; set; }

    public string Direccion { get; set; }


}
