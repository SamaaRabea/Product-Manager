using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shope.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createDatabase‏ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNum = table.Column<int>(type: "int", nullable: false),
                    RevisionNum = table.Column<int>(type: "int", nullable: true),
                    VersionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextRevieweDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Product_Version",
                columns: table => new
                {
                    ProductVersionId = table.Column<long>(name: "Product_Version_Id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemNo = table.Column<int>(type: "int", nullable: false),
                    VersionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Version", x => x.ProductVersionId);
                    table.ForeignKey(
                        name: "FK_Product_Version_Product_Code",
                        column: x => x.Code,
                        principalTable: "Product",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Version_Code",
                table: "Product_Version",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Version");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
