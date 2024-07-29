using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Gate.Migrations
{
    /// <inheritdoc />
    public partial class UserManyCompanySupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Storages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "SalableObject",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Nomenclatures",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CashRegisters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Emails = table.Column<string[]>(type: "text[]", nullable: false),
                    Instagram = table.Column<string>(type: "text", nullable: false),
                    WebSite = table.Column<string>(type: "text", nullable: false),
                    LinkedIn = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    RequisitesId = table.Column<int>(type: "integer", nullable: false),
                    ContactsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_Requisites_RequisitesId",
                        column: x => x.RequisitesId,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    ContactsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyClient",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClient", x => new { x.CompanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CompanyClient_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyClient_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStaff",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStaff", x => new { x.CompanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CompanyStaff_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyStaff_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CompanyId",
                table: "Suppliers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_CompanyId",
                table: "Storages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalableObject_CompanyId",
                table: "SalableObject",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CompanyId",
                table: "Payments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomenclatures_CompanyId",
                table: "Nomenclatures",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_CompanyId",
                table: "CashRegisters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ContactsId",
                table: "Company",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_RequisitesId",
                table: "Company",
                column: "RequisitesId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClient_UserId",
                table: "CompanyClient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStaff_UserId",
                table: "CompanyStaff",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_ContactsId",
                table: "PhoneNumber",
                column: "ContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisters_Company_CompanyId",
                table: "CashRegisters",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nomenclatures_Company_CompanyId",
                table: "Nomenclatures",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Company_CompanyId",
                table: "Payments",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalableObject_Company_CompanyId",
                table: "SalableObject",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Company_CompanyId",
                table: "Storages",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Company_CompanyId",
                table: "Suppliers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisters_Company_CompanyId",
                table: "CashRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_Nomenclatures_Company_CompanyId",
                table: "Nomenclatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Company_CompanyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_SalableObject_Company_CompanyId",
                table: "SalableObject");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Company_CompanyId",
                table: "Storages");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Company_CompanyId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "CompanyClient");

            migrationBuilder.DropTable(
                name: "CompanyStaff");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CompanyId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Storages_CompanyId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_SalableObject_CompanyId",
                table: "SalableObject");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CompanyId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Nomenclatures_CompanyId",
                table: "Nomenclatures");

            migrationBuilder.DropIndex(
                name: "IX_CashRegisters_CompanyId",
                table: "CashRegisters");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "SalableObject");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Nomenclatures");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CashRegisters");
        }
    }
}
