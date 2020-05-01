using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farm.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    BuyerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.BuyerId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    EmergencyPhone = table.Column<string>(nullable: true),
                    LegalDescription = table.Column<string>(nullable: true),
                    Acreage = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "Relocations",
                columns: table => new
                {
                    RelocationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationId = table.Column<int>(nullable: false),
                    RelocationDateTime = table.Column<DateTime>(nullable: false),
                    PossessionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relocations", x => x.RelocationId);
                    table.ForeignKey(
                        name: "FK_Relocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: true),
                    Unit = table.Column<int>(nullable: true),
                    BuyerId = table.Column<int>(nullable: true),
                    PossessionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    VaccinationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VaccinationDateTime = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Symptoms = table.Column<string>(nullable: true),
                    Vaccine = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Unit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.VaccinationId);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: true),
                    Unit = table.Column<int>(nullable: true),
                    SellerId = table.Column<int>(nullable: true),
                    PossessionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Badge = table.Column<string>(nullable: true),
                    AnimalType = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    SexType = table.Column<int>(nullable: false),
                    DamId = table.Column<int>(nullable: false),
                    SireId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    PurchaseId = table.Column<int>(nullable: true),
                    SaleId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RelocationsRelocationId = table.Column<int>(nullable: true),
                    VaccinationsVaccinationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Relocations_RelocationsRelocationId",
                        column: x => x.RelocationsRelocationId,
                        principalTable: "Relocations",
                        principalColumn: "RelocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Vaccinations_VaccinationsVaccinationId",
                        column: x => x.VaccinationsVaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machinery",
                columns: table => new
                {
                    MachineryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identification = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    PurchasesPurchaseId = table.Column<int>(nullable: true),
                    RelocationsRelocationId = table.Column<int>(nullable: true),
                    SalesSaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machinery", x => x.MachineryId);
                    table.ForeignKey(
                        name: "FK_Machinery_Purchases_PurchasesPurchaseId",
                        column: x => x.PurchasesPurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machinery_Relocations_RelocationsRelocationId",
                        column: x => x.RelocationsRelocationId,
                        principalTable: "Relocations",
                        principalColumn: "RelocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machinery_Sales_SalesSaleId",
                        column: x => x.SalesSaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LocationId",
                table: "Animals",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_PurchaseId",
                table: "Animals",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_RelocationsRelocationId",
                table: "Animals",
                column: "RelocationsRelocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SaleId",
                table: "Animals",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_VaccinationsVaccinationId",
                table: "Animals",
                column: "VaccinationsVaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Machinery_PurchasesPurchaseId",
                table: "Machinery",
                column: "PurchasesPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Machinery_RelocationsRelocationId",
                table: "Machinery",
                column: "RelocationsRelocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Machinery_SalesSaleId",
                table: "Machinery",
                column: "SalesSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_LocationId",
                table: "Purchases",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SellerId",
                table: "Purchases",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Relocations_LocationId",
                table: "Relocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerId",
                table: "Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_LocationId",
                table: "Sales",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_LocationId",
                table: "Vaccinations",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Machinery");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Relocations");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
