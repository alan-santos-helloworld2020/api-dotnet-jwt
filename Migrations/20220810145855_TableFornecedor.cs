using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    public partial class TableFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Cnpj = table.Column<string>(type: "TEXT", nullable: false),
                    Empresa = table.Column<string>(type: "TEXT", nullable: false),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: false),
                    LojaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fornecedores_lojas_LojaId",
                        column: x => x.LojaId,
                        principalTable: "lojas",
                        principalColumn: "LojaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fornecedores_LojaId",
                table: "fornecedores",
                column: "LojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fornecedores");
        }
    }
}
