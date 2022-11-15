using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.ComercioElectronico.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CedulaCliente = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    TipoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroTelefonico = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NombreMarca = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProductos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NombreTipoProducto = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    DescripcionTipoProducto = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaAnulacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoCarrito = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NombreProducto = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    PrecioProducto = table.Column<decimal>(type: "TEXT", nullable: false),
                    CodigoProducto = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DescripcionProducto = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    MarcaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoProductoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_TipoProductos_TipoProductoId",
                        column: x => x.TipoProductoId,
                        principalTable: "TipoProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarritoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EstadoCarrito = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaAnulacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TotalOrden = table.Column<decimal>(type: "TEXT", nullable: false),
                    ObservacionesOrden = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoOrden = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarritoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<long>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarritoItems_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoItems_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrdenId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NombreRepartidor = table.Column<string>(type: "TEXT", nullable: false),
                    OrdenEstado = table.Column<string>(type: "TEXT", nullable: false),
                    DireccionEntrega = table.Column<string>(type: "TEXT", nullable: false),
                    EntregaEstado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entregas_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrdenId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CantidadOrdenItems = table.Column<long>(type: "INTEGER", nullable: false),
                    PrecioOrdenItems = table.Column<decimal>(type: "TEXT", nullable: false),
                    ObservacionesOrdenItems = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenItems_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenItems_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItems_CarritoId",
                table: "CarritoItems",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItems_ProductoId",
                table: "CarritoItems",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ClienteId",
                table: "Carritos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_ClienteId",
                table: "Entregas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_OrdenId",
                table: "Entregas",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_CarritoId",
                table: "Ordenes",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_OrdenId",
                table: "OrdenItems",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_ProductoId",
                table: "OrdenItems",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoItems");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "OrdenItems");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "TipoProductos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
