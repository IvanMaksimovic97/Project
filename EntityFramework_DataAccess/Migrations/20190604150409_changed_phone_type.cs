using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework_DataAccess.Migrations
{
    public partial class changed_phone_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Cinemas",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Cinemas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
