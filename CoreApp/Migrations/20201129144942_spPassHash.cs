using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spPassHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spPassHash 
                                @Username nvarchar(MAX),
                                @Password nvarchar(MAX)

                                as
                                BEGIN
	                                SELECT Password FROM Users
	                                WHERE Username = @Username AND Password=@Password
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spPassHash";
            migrationBuilder.Sql(procedure);
        }
    }
}
