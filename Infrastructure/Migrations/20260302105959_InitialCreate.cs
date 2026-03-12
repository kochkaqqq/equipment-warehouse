using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false),
                    Code = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "device_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false),
                    Description = table.Column<string>(type: "varchar(511)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false),
                    Description = table.Column<string>(type: "varchar(511)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Caption = table.Column<string>(type: "varchar(200)", nullable: false),
                    DeviceTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(100)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nomenclatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nomenclatures_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nomenclatures_device_types_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "device_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nomenclatures_manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nomenclatures_CountryId",
                table: "nomenclatures",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_nomenclatures_DeviceTypeId",
                table: "nomenclatures",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_nomenclatures_ManufacturerId",
                table: "nomenclatures",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nomenclatures");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "device_types");

            migrationBuilder.DropTable(
                name: "manufacturers");
        }
    }
}
