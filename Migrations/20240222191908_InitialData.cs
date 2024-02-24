using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Desrcripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("60da01d0-5ca2-4be7-adac-758953ebcab2"), null, "Actidades Personales", 50 },
                    { new Guid("c57d0688-ee45-4013-ab26-01c93f60eb50"), null, "Actidades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Desrcripcion", "Fecha", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("c57d0688-ee45-4013-ab26-01c93f60eb10"), new Guid("c57d0688-ee45-4013-ab26-01c93f60eb50"), null, new DateTime(2021, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 22, 13, 19, 8, 346, DateTimeKind.Local).AddTicks(3241), 1, "Pago de servicios publicos" },
                    { new Guid("c57d0688-ee45-4013-ab26-01c93f60eb11"), new Guid("60da01d0-5ca2-4be7-adac-758953ebcab2"), null, new DateTime(2021, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 22, 13, 19, 8, 346, DateTimeKind.Local).AddTicks(3378), 0, "Estudiar C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c57d0688-ee45-4013-ab26-01c93f60eb10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c57d0688-ee45-4013-ab26-01c93f60eb11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("60da01d0-5ca2-4be7-adac-758953ebcab2"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("c57d0688-ee45-4013-ab26-01c93f60eb50"));

            migrationBuilder.AlterColumn<string>(
                name: "Desrcripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
