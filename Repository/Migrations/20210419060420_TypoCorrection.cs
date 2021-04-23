using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class TypoCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayemntId",
                table: "Order",
                newName: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Order",
                newName: "PayemntId");
        }
    }
}
