using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spUserGetById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spUserGetById @Id int
                                as
                                BEGIN
	                                SELECT * FROM Users
	                                WHERE Id = @Id
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spUserGetById";
            migrationBuilder.Sql(procedure);
        }
    }
}
