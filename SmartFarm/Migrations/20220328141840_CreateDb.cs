using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FARM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true),
                    DiaDiem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FARM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STATISTICAL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThongKe = table.Column<string>(nullable: true),
                    LoaiThongKe = table.Column<string>(nullable: true),
                    MoTaThongKe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATISTICAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    Ho = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    SoHuuTrangTrai = table.Column<int>(nullable: false),
                    VaiTro = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_FARM_SoHuuTrangTrai",
                        column: x => x.SoHuuTrangTrai,
                        principalTable: "FARM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true),
                    Loai = table.Column<string>(nullable: true),
                    ThuocVeTrangTrai = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false),
                    ViTriDat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_FARM_ThuocVeTrangTrai",
                        column: x => x.ThuocVeTrangTrai,
                        principalTable: "FARM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INPUT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LoaiThietBi = table.Column<string>(nullable: false),
                    Max = table.Column<float>(nullable: false),
                    Min = table.Column<float>(nullable: false),
                    ThoiGianTruyXuat = table.Column<DateTime>(nullable: false),
                    FeedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INPUT", x => new { x.Id, x.LoaiThietBi });
                    table.ForeignKey(
                        name: "FK_INPUT_EQUIPMENT_Id",
                        column: x => x.Id,
                        principalTable: "EQUIPMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OUTPUT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TrangThaiHoatDong = table.Column<bool>(nullable: false),
                    FeedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUTPUT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OUTPUT_EQUIPMENT_Id",
                        column: x => x.Id,
                        principalTable: "EQUIPMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INPUTOUTPUT",
                columns: table => new
                {
                    IdInput = table.Column<int>(nullable: false),
                    IdOutput = table.Column<int>(nullable: false),
                    LoaiThietBiInput = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INPUTOUTPUT", x => new { x.IdInput, x.IdOutput, x.LoaiThietBiInput });
                    table.ForeignKey(
                        name: "FK_INPUTOUTPUT_OUTPUT_IdOutput",
                        column: x => x.IdOutput,
                        principalTable: "OUTPUT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_INPUTOUTPUT_INPUT_IdInput_LoaiThietBiInput",
                        columns: x => new { x.IdInput, x.LoaiThietBiInput },
                        principalTable: "INPUT",
                        principalColumns: new[] { "Id", "LoaiThietBi" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "CUSTOMER",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "CUSTOMER",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_SoHuuTrangTrai",
                table: "CUSTOMER",
                column: "SoHuuTrangTrai");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_ThuocVeTrangTrai",
                table: "EQUIPMENT",
                column: "ThuocVeTrangTrai");

            migrationBuilder.CreateIndex(
                name: "IX_INPUT_Id",
                table: "INPUT",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INPUTOUTPUT_IdOutput",
                table: "INPUTOUTPUT",
                column: "IdOutput");

            migrationBuilder.CreateIndex(
                name: "IX_INPUTOUTPUT_IdInput_LoaiThietBiInput",
                table: "INPUTOUTPUT",
                columns: new[] { "IdInput", "LoaiThietBiInput" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "INPUTOUTPUT");

            migrationBuilder.DropTable(
                name: "STATISTICAL");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "OUTPUT");

            migrationBuilder.DropTable(
                name: "INPUT");

            migrationBuilder.DropTable(
                name: "EQUIPMENT");

            migrationBuilder.DropTable(
                name: "FARM");
        }
    }
}
