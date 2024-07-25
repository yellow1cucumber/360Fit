using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Gate.Migrations
{
    /// <inheritdoc />
    public partial class ModelsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "SalableObject",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NomenclatureId",
                table: "SalableObject",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Service_CategoryId",
                table: "SalableObject",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomenclatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationType = table.Column<int>(type: "integer", nullable: false),
                    NameKZ = table.Column<string>(type: "text", nullable: false),
                    NameRU = table.Column<string>(type: "text", nullable: false),
                    NameEN = table.Column<string>(type: "text", nullable: true),
                    DirectorId = table.Column<int>(type: "integer", nullable: true),
                    BIN = table.Column<string>(type: "text", nullable: true),
                    KBE = table.Column<string>(type: "text", nullable: true),
                    LegalAddress = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisites_Users_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankRequisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IIK = table.Column<string>(type: "text", nullable: false),
                    BIK = table.Column<string>(type: "text", nullable: false),
                    RequisitesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankRequisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankRequisites_Requisites_RequisitesId",
                        column: x => x.RequisitesId,
                        principalTable: "Requisites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequisitesId = table.Column<int>(type: "integer", nullable: false),
                    NomenclatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Nomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Requisites_RequisitesId",
                        column: x => x.RequisitesId,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoragedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    StorageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoragedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoragedProducts_SalableObject_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SalableObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoragedProducts_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalableObject_NomenclatureId",
                table: "SalableObject",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SalableObject_Service_CategoryId",
                table: "SalableObject",
                column: "Service_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankRequisites_RequisitesId",
                table: "BankRequisites",
                column: "RequisitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_DirectorId",
                table: "Requisites",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_StoragedProducts_ProductId",
                table: "StoragedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoragedProducts_StorageId",
                table: "StoragedProducts",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_NomenclatureId",
                table: "Suppliers",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_RequisitesId",
                table: "Suppliers",
                column: "RequisitesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalableObject_Nomenclatures_NomenclatureId",
                table: "SalableObject",
                column: "NomenclatureId",
                principalTable: "Nomenclatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalableObject_ServiceCategories_Service_CategoryId",
                table: "SalableObject",
                column: "Service_CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalableObject_Nomenclatures_NomenclatureId",
                table: "SalableObject");

            migrationBuilder.DropForeignKey(
                name: "FK_SalableObject_ServiceCategories_Service_CategoryId",
                table: "SalableObject");

            migrationBuilder.DropTable(
                name: "BankRequisites");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "StoragedProducts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Nomenclatures");

            migrationBuilder.DropTable(
                name: "Requisites");

            migrationBuilder.DropIndex(
                name: "IX_SalableObject_NomenclatureId",
                table: "SalableObject");

            migrationBuilder.DropIndex(
                name: "IX_SalableObject_Service_CategoryId",
                table: "SalableObject");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "SalableObject");

            migrationBuilder.DropColumn(
                name: "NomenclatureId",
                table: "SalableObject");

            migrationBuilder.DropColumn(
                name: "Service_CategoryId",
                table: "SalableObject");
        }
    }
}
