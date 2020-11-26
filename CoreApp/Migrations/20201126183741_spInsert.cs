using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class spInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spInsert 
                                    @PCode nvarchar(50),
                                    @Description nvarchar(MAX),
                                    @Category nvarchar(MAX)
                                as
                                BEGIN
                                    INSERT INTO Products(PCode, Description, Category)	                                
	                                VALUES (@PCode, @Description, @Category)	
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure spInsert";
            migrationBuilder.Sql(procedure);
        }
    }
}
