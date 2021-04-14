using Microsoft.EntityFrameworkCore.Migrations;

namespace DapperDemoApp.Migrations
{
    public partial class FindCompanyProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC GET_COMPANY_BY_ID @CompanyId INT AS 
                                    BEGIN 
                                        SELECT * FROM Companies Where CompanyId=@CompanyId
                                    END 
                                 ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC GET_COMPANY_BY_ID");
        }
    }
}
