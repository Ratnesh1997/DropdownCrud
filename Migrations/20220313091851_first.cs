using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudR.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "c_Id",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "s_Id",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "newcountries",
                columns: table => new
                {
                    c_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newcountries", x => x.c_Id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    s_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryc_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.s_Id);
                    table.ForeignKey(
                        name: "FK_states_newcountries_countryc_Id",
                        column: x => x.countryc_Id,
                        principalTable: "newcountries",
                        principalColumn: "c_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_c_Id",
                table: "Customers",
                column: "c_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_s_Id",
                table: "Customers",
                column: "s_Id");

            migrationBuilder.CreateIndex(
                name: "IX_states_countryc_Id",
                table: "states",
                column: "countryc_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_newcountries_c_Id",
                table: "Customers",
                column: "c_Id",
                principalTable: "newcountries",
                principalColumn: "c_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_states_s_Id",
                table: "Customers",
                column: "s_Id",
                principalTable: "states",
                principalColumn: "s_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_newcountries_c_Id",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_states_s_Id",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "newcountries");

            migrationBuilder.DropIndex(
                name: "IX_Customers_c_Id",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_s_Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "c_Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "s_Id",
                table: "Customers");
        }
    }
}
