using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class MarcaDto
{
    public MarcaDto(Guid id, string nombreMarca, string descripcion)
    {
        Id = id;
        NombreMarca = nombreMarca;
        Descripcion = descripcion;
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string NombreMarca { get; set; }

    [Required]
    [StringLength(DominioConstantes.MAXIMO_NOMBRE)]
    public string Descripcion { get; set; }

}
