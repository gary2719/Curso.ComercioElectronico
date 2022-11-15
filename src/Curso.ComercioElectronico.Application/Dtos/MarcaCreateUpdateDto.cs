using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class MarcaCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string NombreMarca { get; set; }

    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string Descripcion { get; set; }
}
