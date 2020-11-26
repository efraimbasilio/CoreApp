using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spDelete @Id int
                                as
                                BEGIN
	                                DELETE FROM Products
	                                WHERE Id = @Id
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spDelete";

            migrationBuilder.Sql(procedure);
        }
    }
}
