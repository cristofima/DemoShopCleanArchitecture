using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Migrations.DemoShop
{
    public partial class InitialIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Productos");
        }
    }
}
