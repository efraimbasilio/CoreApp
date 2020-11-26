using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spGetById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spGetById @Id int
                                as
                                BEGIN
	                                SELECT * FROM Products
	                                WHERE Id = @Id
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spGetById";
            migrationBuilder.Sql(procedure);
        }
    }
}
