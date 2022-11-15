using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class EntregaDto
{
    public EntregaDto(Guid id, Guid clienteId, Guid ordenId, string nombreRepartidor, string ordenEstado, string direccionEntrega, string entregaEstado)
    {
        Id = id;
        ClienteId = clienteId;
        OrdenId = ordenId;
        NombreRepartidor = nombreRepartidor;
        OrdenEstado = ordenEstado;
        DireccionEntrega = direccionEntrega;
        EntregaEstado = entregaEstado;
    }

    public Guid Id { get; set; }

    [Required]

    public Guid ClienteId { get; set; }

    [Required]
    public Guid OrdenId { get; set; }

    public string NombreRepartidor { get; set; }
    public string OrdenEstado { get; set; }
    public string DireccionEntrega { get; set; }

    public string EntregaEstado { get; set; }
}
