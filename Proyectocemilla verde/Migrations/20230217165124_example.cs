using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyectocemillaverde.Migrations
{
    /// <inheritdoc />
    public partial class example : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empledos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKpuesto = table.Column<int>(type: "int", nullable: true),
                    FKdepartamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empledos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empledos_Departamento_FKdepartamento",
                        column: x => x.FKdepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empledos_Puesto_FKpuesto",
                        column: x => x.FKpuesto,
                        principalTable: "Puesto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empledos_FKdepartamento",
                table: "Empledos",
                column: "FKdepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Empledos_FKpuesto",
                table: "Empledos",
                column: "FKpuesto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empledos");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Puesto");
        }
    }
}
