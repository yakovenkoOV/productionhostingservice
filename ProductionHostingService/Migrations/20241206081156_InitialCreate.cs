using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductionHostingService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessEquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessEquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StandardArea = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPlacementContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionFacilityId = table.Column<int>(type: "int", nullable: false),
                    ProcessEquipmentTypeId = table.Column<int>(type: "int", nullable: false),
                    EquipmentQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPlacementContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContracts_ProcessEquipmentTypes_ProcessEquipmentTypeId",
                        column: x => x.ProcessEquipmentTypeId,
                        principalTable: "ProcessEquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContracts_ProductionFacilities_ProductionFacilityId",
                        column: x => x.ProductionFacilityId,
                        principalTable: "ProductionFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Id", "Area", "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 50, "PET001", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 1", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 75, "PET002", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 2", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 60, "PET003", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 3", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 80, "PET004", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 4", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 100, "PET005", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 5", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 45, "PET006", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 6", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 110, "PET007", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 7", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 65, "PET008", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 8", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 90, "PET009", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 9", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 120, "PET010", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Обладнання 10", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "StandardArea", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "PF001", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 1", 1000, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "PF002", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 2", 1200, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "PF003", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 3", 1500, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "PF004", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 4", 2000, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "PF005", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 5", 1800, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "PF006", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 6", 2200, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "PF007", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 7", 2500, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, "PF008", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 8", 3000, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "PF009", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 9", 3500, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, "PF010", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Фабрика 10", 4000, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContracts_ProcessEquipmentTypeId",
                table: "EquipmentPlacementContracts",
                column: "ProcessEquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContracts_ProductionFacilityId",
                table: "EquipmentPlacementContracts",
                column: "ProductionFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessEquipmentType_Code",
                table: "ProcessEquipmentTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionFacility_Code",
                table: "ProductionFacilities",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPlacementContracts");

            migrationBuilder.DropTable(
                name: "ProcessEquipmentTypes");

            migrationBuilder.DropTable(
                name: "ProductionFacilities");
        }
    }
}
