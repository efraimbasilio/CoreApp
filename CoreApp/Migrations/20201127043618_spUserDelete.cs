using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spUserDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spUserDelete @Id int
                                as
                                BEGIN
	                                DELETE FROM Users
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
