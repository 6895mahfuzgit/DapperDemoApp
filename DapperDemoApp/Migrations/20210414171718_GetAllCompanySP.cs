using Microsoft.EntityFrameworkCore.Migrations;

namespace DapperDemoApp.Migrations
{
    public partial class GetAllCompanySP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC USP_GET_ALL_COMPANY AS 
               BEGIN
                 SELECT * FROM Companies
               END
             ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP  PROC USP_GET_ALL_COMPANY");
        }
    }
}
