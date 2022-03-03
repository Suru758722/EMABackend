﻿// <auto-generated />
using System;
using EMA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220223045408_foo3")]
    partial class foo3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMA.EntityModels.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("Energy")
                        .HasColumnType("float");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LifeHr")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WeightKG")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("EMA.EntityModels.FarmerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LandHolding")
                        .HasColumnType("float");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FarmerDetail");
                });

            modelBuilder.Entity("EMA.EntityModels.Fertilizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int>("Labourer")
                        .HasColumnType("int");

                    b.Property<string>("Material1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<double>("QtyKgPHa1")
                        .HasColumnType("float");

                    b.Property<double>("QtyKgPHa2")
                        .HasColumnType("float");

                    b.Property<double>("QtyKgPHa3")
                        .HasColumnType("float");

                    b.Property<double>("QtyKgPHa4")
                        .HasColumnType("float");

                    b.Property<double>("TotalDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<double>("TotalEnergy")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Farmerid");

                    b.ToTable("Fertilizer");
                });

            modelBuilder.Entity("EMA.EntityModels.Harvesting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DieselLPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int>("DriverLabour")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("FuelEnergy")
                        .HasColumnType("float");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<double>("LabourChargePDay")
                        .HasColumnType("float");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<string>("OwnHired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("TotalEnergy")
                        .HasColumnType("float");

                    b.Property<string>("TypeOperation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("Farmerid");

                    b.HasIndex("MachineId");

                    b.ToTable("Harvesting");
                });

            modelBuilder.Entity("EMA.EntityModels.InterCulture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DieselLPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int>("DriverLabour")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("FuelEnergy")
                        .HasColumnType("float");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<string>("OwnHired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QtyKgPHa")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("TotalDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("Farmerid");

                    b.HasIndex("MachineId");

                    b.ToTable("InterCulture");
                });

            modelBuilder.Entity("EMA.EntityModels.Irrigation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<double>("ElecEnergy")
                        .HasColumnType("float");

                    b.Property<double>("EleckWh")
                        .HasColumnType("float");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<int>("OperatorLabour")
                        .HasColumnType("int");

                    b.Property<string>("OwnHired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TimeTaken")
                        .HasColumnType("float");

                    b.Property<double>("TotalDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("Farmerid");

                    b.HasIndex("MachineId");

                    b.ToTable("Irrigation");
                });

            modelBuilder.Entity("EMA.EntityModels.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("Energy")
                        .HasColumnType("float");

                    b.Property<double>("HP")
                        .HasColumnType("float");

                    b.Property<double>("LifeHr")
                        .HasColumnType("float");

                    b.Property<string>("MachineType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WeightKg")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("EMA.EntityModels.PlantProtection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DieselLPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int>("DriverLabour")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("FuelEnergy")
                        .HasColumnType("float");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<string>("OwnHired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QtyKgPHa")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("TotalDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("Farmerid");

                    b.HasIndex("MachineId");

                    b.ToTable("PlantProtection");
                });

            modelBuilder.Entity("EMA.EntityModels.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("GrainProduction")
                        .HasColumnType("float");

                    b.Property<double>("GrainStrawRatio")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("StrawProduction")
                        .HasColumnType("float");

                    b.Property<double>("TotalEnergyGrainMJPHa")
                        .HasColumnType("float");

                    b.Property<double>("TotalEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<double>("TotalEnergyStrawMJPHa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Farmerid");

                    b.ToTable("Production");
                });

            modelBuilder.Entity("EMA.EntityModels.SeedBeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DieselLPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int>("DriverLabour")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("FuelEnergy")
                        .HasColumnType("float");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<string>("OwnHired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("TotalDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<double>("TotalInDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<string>("TypeOperation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("Farmerid");

                    b.HasIndex("MachineId");

                    b.ToTable("SeedBeed");
                });

            modelBuilder.Entity("EMA.EntityModels.Sowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("DieselLPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPH")
                        .HasColumnType("float");

                    b.Property<double>("DirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int>("DriverLabour")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Farmerid")
                        .HasColumnType("int");

                    b.Property<double>("FuelEnergy")
                        .HasColumnType("float");

                    b.Property<double>("HumanEnergy")
                        .HasColumnType("float");

                    b.Property<double>("InDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfPass")
                        .HasColumnType("int");

                    b.Property<double>("OperationalEnergy")
                        .HasColumnType("float");

                    b.Property<string>("OwnHired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QtyKgPHa")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("TotalDirectEnergyMJPHa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("Farmerid");

                    b.HasIndex("MachineId");

                    b.ToTable("Sowing");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EMA.EntityModels.Fertilizer", b =>
                {
                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.Navigation("FarmerDetail");
                });

            modelBuilder.Entity("EMA.EntityModels.Harvesting", b =>
                {
                    b.HasOne("EMA.EntityModels.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.HasOne("EMA.EntityModels.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");

                    b.Navigation("Equipment");

                    b.Navigation("FarmerDetail");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("EMA.EntityModels.InterCulture", b =>
                {
                    b.HasOne("EMA.EntityModels.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.HasOne("EMA.EntityModels.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");

                    b.Navigation("Equipment");

                    b.Navigation("FarmerDetail");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("EMA.EntityModels.Irrigation", b =>
                {
                    b.HasOne("EMA.EntityModels.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.HasOne("EMA.EntityModels.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");

                    b.Navigation("Equipment");

                    b.Navigation("FarmerDetail");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("EMA.EntityModels.PlantProtection", b =>
                {
                    b.HasOne("EMA.EntityModels.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.HasOne("EMA.EntityModels.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");

                    b.Navigation("Equipment");

                    b.Navigation("FarmerDetail");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("EMA.EntityModels.Production", b =>
                {
                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.Navigation("FarmerDetail");
                });

            modelBuilder.Entity("EMA.EntityModels.SeedBeed", b =>
                {
                    b.HasOne("EMA.EntityModels.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.HasOne("EMA.EntityModels.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");

                    b.Navigation("Equipment");

                    b.Navigation("FarmerDetail");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("EMA.EntityModels.Sowing", b =>
                {
                    b.HasOne("EMA.EntityModels.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EMA.EntityModels.FarmerDetail", "FarmerDetail")
                        .WithMany()
                        .HasForeignKey("Farmerid");

                    b.HasOne("EMA.EntityModels.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");

                    b.Navigation("Equipment");

                    b.Navigation("FarmerDetail");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
