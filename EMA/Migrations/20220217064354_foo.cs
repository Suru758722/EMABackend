using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMA.Migrations
{
    public partial class foo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    WeightKG = table.Column<double>(type: "float", nullable: false),
                    LifeHr = table.Column<double>(type: "float", nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    Energy = table.Column<double>(type: "float", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmerDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandHolding = table.Column<double>(type: "float", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HP = table.Column<double>(type: "float", nullable: false),
                    WeightKg = table.Column<double>(type: "float", nullable: false),
                    Energy = table.Column<int>(type: "int", nullable: false),
                    LifeHr = table.Column<double>(type: "float", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fertilizer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Labourer = table.Column<int>(type: "int", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    TtlDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    Material1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa1 = table.Column<double>(type: "float", nullable: false),
                    Material2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa2 = table.Column<double>(type: "float", nullable: false),
                    Material3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa3 = table.Column<double>(type: "float", nullable: false),
                    Material4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa4 = table.Column<double>(type: "float", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    TotalEnergy = table.Column<double>(type: "float", nullable: false),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fertilizer_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    GrainProduction = table.Column<double>(type: "float", nullable: false),
                    StrawProduction = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TotalEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    GrainStrawRatio = table.Column<double>(type: "float", nullable: false),
                    TtlEnergyGrainMJPHa = table.Column<double>(type: "float", nullable: false),
                    TtlEnergyStrawMJPHa = table.Column<double>(type: "float", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Production_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Harvesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnHired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    DieselLPH = table.Column<double>(type: "float", nullable: false),
                    FuelEnergy = table.Column<double>(type: "float", nullable: false),
                    DriverLabour = table.Column<int>(type: "int", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    InDirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    TotalEnergy = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvesting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvesting_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harvesting_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harvesting_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterCulture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    OwnHired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    DieselLPH = table.Column<double>(type: "float", nullable: false),
                    FuelEnergy = table.Column<double>(type: "float", nullable: false),
                    DriverLabour = table.Column<int>(type: "int", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    TtlDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa = table.Column<double>(type: "float", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterCulture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterCulture_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterCulture_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterCulture_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Irrigation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnHired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EleckWh = table.Column<double>(type: "float", nullable: false),
                    ElecEnergy = table.Column<double>(type: "float", nullable: false),
                    OperatorLabour = table.Column<int>(type: "int", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    TtllDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Irrigation_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Irrigation_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Irrigation_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "plantProtection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnHired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    DieselLPH = table.Column<double>(type: "float", nullable: false),
                    FuelEnergy = table.Column<double>(type: "float", nullable: false),
                    DriverLabour = table.Column<int>(type: "int", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    TtlDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa = table.Column<double>(type: "float", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantProtection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plantProtection_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plantProtection_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plantProtection_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeedBeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnHired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    DieselLPH = table.Column<double>(type: "float", nullable: false),
                    FuelEnergy = table.Column<double>(type: "float", nullable: false),
                    DriverLabour = table.Column<int>(type: "int", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    InDirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    TotalDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    TotalInDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedBeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeedBeeds_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeedBeeds_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeedBeeds_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sowing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmerid = table.Column<int>(type: "int", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnHired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    DieselLPH = table.Column<double>(type: "float", nullable: false),
                    FuelEnergy = table.Column<double>(type: "float", nullable: false),
                    DriverLabour = table.Column<int>(type: "int", nullable: false),
                    LabourChargePDay = table.Column<double>(type: "float", nullable: false),
                    HumanEnergy = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPH = table.Column<double>(type: "float", nullable: false),
                    DirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    NoOfPass = table.Column<int>(type: "int", nullable: false),
                    TotalDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyKgPHa = table.Column<double>(type: "float", nullable: false),
                    InDirectEnergyMJPHa = table.Column<double>(type: "float", nullable: false),
                    OperationalEnergy = table.Column<double>(type: "float", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sowing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sowing_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sowing_FarmerDetail_Farmerid",
                        column: x => x.Farmerid,
                        principalTable: "FarmerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sowing_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizer_Farmerid",
                table: "Fertilizer",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_Harvesting_EquipmentId",
                table: "Harvesting",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvesting_Farmerid",
                table: "Harvesting",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_Harvesting_MachineId",
                table: "Harvesting",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_InterCulture_EquipmentId",
                table: "InterCulture",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InterCulture_Farmerid",
                table: "InterCulture",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_InterCulture_MachineId",
                table: "InterCulture",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_EquipmentId",
                table: "Irrigation",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Farmerid",
                table: "Irrigation",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_MachineId",
                table: "Irrigation",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_plantProtection_EquipmentId",
                table: "plantProtection",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_plantProtection_Farmerid",
                table: "plantProtection",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_plantProtection_MachineId",
                table: "plantProtection",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_Farmerid",
                table: "Production",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_SeedBeeds_EquipmentId",
                table: "SeedBeeds",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedBeeds_Farmerid",
                table: "SeedBeeds",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_SeedBeeds_MachineId",
                table: "SeedBeeds",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowing_EquipmentId",
                table: "Sowing",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowing_Farmerid",
                table: "Sowing",
                column: "Farmerid");

            migrationBuilder.CreateIndex(
                name: "IX_Sowing_MachineId",
                table: "Sowing",
                column: "MachineId");
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
                name: "Fertilizer");

            migrationBuilder.DropTable(
                name: "Harvesting");

            migrationBuilder.DropTable(
                name: "InterCulture");

            migrationBuilder.DropTable(
                name: "Irrigation");

            migrationBuilder.DropTable(
                name: "plantProtection");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "SeedBeeds");

            migrationBuilder.DropTable(
                name: "Sowing");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "FarmerDetail");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
