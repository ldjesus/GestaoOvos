using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoOvos.Migrations
{
    public partial class SegundaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Vendas",
                newName: "Qtd");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Vendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeId",
                table: "Vendas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quantidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Qtd = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantidade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_QuantidadeId",
                table: "Vendas",
                column: "QuantidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Quantidade_QuantidadeId",
                table: "Vendas",
                column: "QuantidadeId",
                principalTable: "Quantidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Quantidade_QuantidadeId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Quantidade");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_QuantidadeId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "QuantidadeId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "Qtd",
                table: "Vendas",
                newName: "Quantidade");
        }
    }
}
