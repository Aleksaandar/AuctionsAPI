using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: "https://spacenetgameshop.net/image/cache/data/001%20PS4%20Cover/assassins-creed-black-flag-546x840.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: "https://www.kancelarijskimaterijal-bg.rs/images/products/big/398.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "https://trendcoo.rs/wp-content/uploads/2023/08/77-101z-1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Items");
        }
    }
}
