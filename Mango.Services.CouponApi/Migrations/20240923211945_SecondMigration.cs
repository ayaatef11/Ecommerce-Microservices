using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.CouponApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Coupones",
                type: "Decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Coupones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiscountAmount",
                value: 6.6m);

            migrationBuilder.UpdateData(
                table: "Coupones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiscountAmount",
                value: 8.6m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DiscountAmount",
                table: "Coupones",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(5,2)");

            migrationBuilder.UpdateData(
                table: "Coupones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiscountAmount",
                value: 6.5999999999999996);

            migrationBuilder.UpdateData(
                table: "Coupones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiscountAmount",
                value: 8.5999999999999996);
        }
    }
}
