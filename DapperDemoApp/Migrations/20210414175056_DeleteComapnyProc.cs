using Microsoft.EntityFrameworkCore.Migrations;

namespace DapperDemoApp.Migrations
{
    public partial class DeleteComapnyProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC USP_DELETE_COMPANY @Id INT AS
                                    BEGIN
                                     DELETE Companies WHERE CompanyId=@Id
                                    END
                                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
