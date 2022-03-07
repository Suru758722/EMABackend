using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMA.Migrations
{
    public partial class foo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "FarmerDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetail_CropId",
                table: "FarmerDetail",
                column: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerDetail_Crop_CropId",
                table: "FarmerDetail",
                column: "CropId",
                principalTable: "Crop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerDetail_Crop_CropId",
                table: "FarmerDetail");

            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropIndex(
                name: "IX_FarmerDetail_CropId",
                table: "FarmerDetail");

            migrationBuilder.DropColumn(
                name: "CropId",
                table: "FarmerDetail");
        }
    }
}
