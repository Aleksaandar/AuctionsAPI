using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerForBids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    CREATE TRIGGER trg_UpdateBrojLicitacija
        ON Bids
        AFTER INSERT
        AS
        BEGIN
            UPDATE Auctions
            SET Broj_licitacija = Broj_licitacija + 1
            FROM Auctions A
            INNER JOIN inserted I ON A.Id = I.AuctionId;
        END;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateBrojLicitacija;");
            

        }
    }
}
