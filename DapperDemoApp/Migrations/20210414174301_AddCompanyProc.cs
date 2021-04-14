using Microsoft.EntityFrameworkCore.Migrations;

namespace DapperDemoApp.Migrations
{
    public partial class AddCompanyProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC USP_ADD_COMPANY 
                                                           @Name NVARCHAR(MAX),
                                                           @Address NVARCHAR(MAX),
                                                           @City NVARCHAR(MAX),
                                                           @State NVARCHAR(MAX),
                                                           @PostCode NVARCHAR(MAX),
                                                           @CompanyId INT OUTPUT 
                                                      AS 
                                                      BEGIN 
                                                         INSERT INTO Companies(Name,Address,City,State,PostCode) VALUES(@Name,@Address,@City,@State,@PostCode);
                                                         SELECT @CompanyId=SCOPE_IDENTITY() 
                                                       END
                                                      ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC USP_ADD_COMPANY");
        }
    }
}
