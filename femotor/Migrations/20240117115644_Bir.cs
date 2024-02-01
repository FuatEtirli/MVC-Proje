using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace femotor.Migrations
{
    public partial class Bir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    BodyTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.BodyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "GearTypes",
                columns: table => new
                {
                    GearTypeID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearTypes", x => x.GearTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    MotorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MotorModel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BodyTypeID = table.Column<int>(type: "int", nullable: false),
                    BodyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GearType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EngineVolume = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.MotorID);
                });

            migrationBuilder.CreateTable(
                name: "Rolees",
                columns: table => new
                {
                    RoleeID = table.Column<byte>(type: "tinyint", nullable: false),
                    RoleeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolees", x => x.RoleeID);
                });

            migrationBuilder.CreateTable(
                name: "Userrs",
                columns: table => new
                {
                    UserrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emaill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Passwordd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleeID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userrs", x => x.UserrID);
                    table.ForeignKey(
                        name: "FK_Userrs_Rolees_RoleeID",
                        column: x => x.RoleeID,
                        principalTable: "Rolees",
                        principalColumn: "RoleeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "BodyTypeID", "BodyTypeName" },
                values: new object[,]
                {
                    { 1, "SuperSport" },
                    { 2, "Naked" },
                    { 3, "Scooter" },
                    { 4, "Touring" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "BrandName" },
                values: new object[,]
                {
                    { (byte)1, "Yamaha" },
                    { (byte)2, "Kawasaki" },
                    { (byte)3, "BMW" },
                    { (byte)4, "Suzuki" },
                    { (byte)5, "Honda" },
                    { (byte)6, "Ducati" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "ColorName" },
                values: new object[,]
                {
                    { (byte)1, "Beyaz" },
                    { (byte)2, "Siyah" },
                    { (byte)3, "Gri" },
                    { (byte)4, "Mavi" },
                    { (byte)5, "Kırmızı" }
                });

            migrationBuilder.InsertData(
                table: "GearTypes",
                columns: new[] { "GearTypeID", "GearTypeName" },
                values: new object[,]
                {
                    { (byte)1, "Otomatik" },
                    { (byte)2, "Manuel" }
                });

            migrationBuilder.InsertData(
                table: "Motors",
                columns: new[] { "MotorID", "BodyType", "BodyTypeID", "BodyTypeName", "Brand", "Color", "EngineVolume", "GearType", "ModelYear", "MotorModel", "Price" },
                values: new object[,]
                {
                    { 1, "SuperSport", 1, "SuperSport", "Ducati", "Siyah", (short)600, "Otomatik", (short)2022, "V4S", 500000m },
                    { 2, "Naked", 2, "Naked", "BMW", "Siyah", (short)990, "Otamatik", (short)2022, "S1000RR", 5000000m },
                    { 3, "Turing", 4, "Turing", "BMW", "Siyah", (short)990, "Manuel", (short)2022, "GS1000", 5000000m },
                    { 4, "Scooter", 3, "Scooter", "Yamaha", "Gri", (short)1100, "Manuel", (short)2022, "R1", 450000m }
                });

            migrationBuilder.InsertData(
                table: "Rolees",
                columns: new[] { "RoleeID", "RoleeName" },
                values: new object[,]
                {
                    { (byte)1, "Aday" },
                    { (byte)2, "Uye" },
                    { (byte)3, "Admin" },
                    { (byte)4, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Userrs",
                columns: new[] { "UserrID", "Emaill", "Passwordd", "RoleeID" },
                values: new object[,]
                {
                    { 1, "aday@hotmail.com", "123456", (byte)1 },
                    { 2, "uye@hotmail.com", "123456", (byte)2 },
                    { 3, "admin@hotmail.com", "123456", (byte)3 },
                    { 4, "supervisor@hotmail.com", "123456", (byte)4 },
                    { 5, "uye2@hotmail.com", "123456", (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Userrs_RoleeID",
                table: "Userrs",
                column: "RoleeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "GearTypes");

            migrationBuilder.DropTable(
                name: "Motors");

            migrationBuilder.DropTable(
                name: "Userrs");

            migrationBuilder.DropTable(
                name: "Rolees");
        }
    }
}
