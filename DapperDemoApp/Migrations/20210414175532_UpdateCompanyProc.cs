using Microsoft.EntityFrameworkCore.Migrations;

namespace DapperDemoApp.Migrations
{
    public partial class UpdateCompanyProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC USP_UPDATE_COMPANY 
                                                           @Name NVARCHAR(MAX),
                                                           @Address NVARCHAR(MAX),
                                                           @City NVARCHAR(MAX),
                                                           @State NVARCHAR(MAX),
                                                           @PostCode NVARCHAR(MAX),
                                                           @CompanyId INT
                                                      AS 
                                                      BEGIN 
                                                         UPDATE Companies SET Name=@Name,Address=@Address,City=@City,State=@State,PostCode=@PostCode WHERE CompanyId=@CompanyId
                                                       END
                                                      ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC USP_UPDATE_COMPANY");
        }
    }
}
