using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spUserInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spUserInsert 
                                    @Username nvarchar(MAX),
                                    @Password nvarchar(MAX),
                                    @Email nvarchar(MAX)
                                as
                                BEGIN
                                    INSERT INTO Products(Username, Passwprd, Email)	                                
	                                VALUES (@Username, @Password, @Email)	
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spUserInsert";
            migrationBuilder.Sql(procedure);
        }
    }
}
