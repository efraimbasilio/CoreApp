using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spUpdate 
                                    @PCode nvarchar(50),
                                    @Description nvarchar(MAX),
                                    @Category nvarchar(MAX),
                                    @Id int
                                    as
                                  BEGIN
                                    UPDATE Products
                                    SET PCode = @PCode, Description= @Description, Category= @Category     
                                    WHERE Id = @Id	
                                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spUpdate";
            migrationBuilder.Sql(procedure);
        }
    }
}
