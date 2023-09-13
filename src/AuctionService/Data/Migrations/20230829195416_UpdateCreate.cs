using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Items",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "AuctioEnd",
                table: "Auctions",
                newName: "AuctionEnd");

            migrationBuilder.Sql("ALTER TABLE \"Items\" ADD COLUMN new_int_col INTEGER;");

            migrationBuilder.Sql("UPDATE \"Items\" SET new_int_col = CAST(\"Mileage\" as INTEGER) WHERE \"Mileage\" ~ E'^\\d+$';");

            migrationBuilder.Sql("ALTER TABLE \"Items\" DROP COLUMN \"Mileage\";");

            migrationBuilder.Sql("ALTER TABLE \"Items\" RENAME COLUMN new_int_col to \"Mileage\";");

            // migrationBuilder.AlterColumn<int>(
            //     name: "Mileage",
            //     table: "Items",
            //     type: "integer",
            //     nullable: false,
            //     defaultValue: 0,
            //     oldClrType: typeof(string),
            //     oldType: "text",
            //     oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Items",
                newName: "ImgUrl");

            migrationBuilder.RenameColumn(
                name: "AuctionEnd",
                table: "Auctions",
                newName: "AuctioEnd");

            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                table: "Items",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
