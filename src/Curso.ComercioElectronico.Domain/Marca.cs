using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class Marca
{
    public Marca()
    {
    }

    [Required]
public Guid Id {get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string NombreMarca{get;set;}

[Required]
[StringLength(DominioConstantes.MAXIMO_NOMBRE)]
public string Descripcion{get;set;}


}
