using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace app.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qarku",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Qarku = table.Column<string>(unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qarku", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Values = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bashkia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bashkia = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    IdQarku = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bashkia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bashkia_Qarku",
                        column: x => x.IdQarku,
                        principalTable: "Qarku",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Njesia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdBashkia = table.Column<int>(nullable: true),
                    Njesia = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Njesia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Njesia_Bashkia",
                        column: x => x.IdBashkia,
                        principalTable: "Bashkia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Idnja = table.Column<int>(nullable: false),
                    Qv = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QV_Njesia",
                        column: x => x.Idnja,
                        principalTable: "Njesia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atesi = table.Column<string>(nullable: true),
                    Datelindja = table.Column<DateTime>(nullable: false, defaultValueSql: "('0001-01-01T00:00:00.000')"),
                    Email = table.Column<string>(nullable: true),
                    Emer = table.Column<string>(nullable: true),
                    Gjinia = table.Column<string>(nullable: true),
                    IdBashkia = table.Column<int>(nullable: true),
                    idNjesia = table.Column<int>(nullable: true),
                    IdQarku = table.Column<int>(nullable: true),
                    idQv = table.Column<int>(nullable: true),
                    Interests = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    LastActive = table.Column<DateTime>(nullable: false, defaultValueSql: "('0001-01-01T00:00:00.000')"),
                    Mbiemer = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Bashkia",
                        column: x => x.IdBashkia,
                        principalTable: "Bashkia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Njesia",
                        column: x => x.idNjesia,
                        principalTable: "Njesia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Qarku",
                        column: x => x.IdQarku,
                        principalTable: "Qarku",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_QV",
                        column: x => x.idQv,
                        principalTable: "QV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bashkia_IdQarku",
                table: "Bashkia",
                column: "IdQarku");

            migrationBuilder.CreateIndex(
                name: "IX_Njesia_IdBashkia",
                table: "Njesia",
                column: "IdBashkia");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QV_Idnja",
                table: "QV",
                column: "Idnja");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdBashkia",
                table: "Users",
                column: "IdBashkia");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idNjesia",
                table: "Users",
                column: "idNjesia");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdQarku",
                table: "Users",
                column: "IdQarku");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idQv",
                table: "Users",
                column: "idQv");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "QV");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Njesia");

            migrationBuilder.DropTable(
                name: "Bashkia");

            migrationBuilder.DropTable(
                name: "Qarku");
        }
    }
}
