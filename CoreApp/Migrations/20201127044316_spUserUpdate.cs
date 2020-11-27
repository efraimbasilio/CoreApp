using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spUserUpdate 
                                    @Username nvarchar(MAX),
                                    @Password nvarchar(MAX),
                                    @Email nvarchar(MAX),
                                    @Id int
                                    as
                                  BEGIN
                                    UPDATE Users
                                    SET Username = @Username, Password= @Password, Email= @Email     
                                    WHERE Id = @Id	
                                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spUserUpdate";
            migrationBuilder.Sql(procedure);
        }
    }
}
