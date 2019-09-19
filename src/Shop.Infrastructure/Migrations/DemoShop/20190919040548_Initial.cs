using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Migrations.DemoShop
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    header = table.Column<string>(unicode: false, nullable: false),
                    method = table.Column<string>(unicode: false, nullable: false),
                    path = table.Column<string>(unicode: false, nullable: false),
                    queryString = table.Column<string>(unicode: false, nullable: false),
                    RequestBody = table.Column<string>(unicode: false, nullable: true),
                    host = table.Column<string>(unicode: false, nullable: false),
                    clientIp = table.Column<string>(unicode: false, nullable: false),
                    statusCode = table.Column<int>(unicode: false, nullable: false),
                    transactionDate = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    unidades = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    stock = table.Column<int>(nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    tipo = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    marca = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__40F9A2077F076D42", x => x.codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
