using Microsoft.EntityFrameworkCore.Migrations;

namespace EMA.Migrations
{
    public partial class foo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plantProtection_Equipment_EquipmentId",
                table: "plantProtection");

            migrationBuilder.DropForeignKey(
                name: "FK_plantProtection_FarmerDetail_Farmerid",
                table: "plantProtection");

            migrationBuilder.DropForeignKey(
                name: "FK_plantProtection_Machine_MachineId",
                table: "plantProtection");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedBeeds_Equipment_EquipmentId",
                table: "SeedBeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedBeeds_FarmerDetail_Farmerid",
                table: "SeedBeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedBeeds_Machine_MachineId",
                table: "SeedBeeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plantProtection",
                table: "plantProtection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeedBeeds",
                table: "SeedBeeds");

            migrationBuilder.DropColumn(
                name: "LabourChargePDay",
                table: "Sowing");

            migrationBuilder.DropColumn(
                name: "TypeOperation",
                table: "Sowing");

            migrationBuilder.DropColumn(
                name: "LabourChargePDay",
                table: "plantProtection");

            migrationBuilder.DropColumn(
                name: "TypeOperation",
                table: "plantProtection");

            migrationBuilder.DropColumn(
                name: "TypeOperation",
                table: "Irrigation");

            migrationBuilder.DropColumn(
                name: "LabourChargePDay",
                table: "InterCulture");

            migrationBuilder.DropColumn(
                name: "LabourChargePDay",
                table: "Fertilizer");

            migrationBuilder.DropColumn(
                name: "LabourChargePDay",
                table: "SeedBeeds");

            migrationBuilder.RenameTable(
                name: "plantProtection",
                newName: "PlantProtection");

            migrationBuilder.RenameTable(
                name: "SeedBeeds",
                newName: "SeedBeed");

            migrationBuilder.RenameColumn(
                name: "TtlEnergyStrawMJPHa",
                table: "Production",
                newName: "TotalEnergyStrawMJPHa");

            migrationBuilder.RenameColumn(
                name: "TtlEnergyGrainMJPHa",
                table: "Production",
                newName: "TotalEnergyGrainMJPHa");

            migrationBuilder.RenameColumn(
                name: "TtlDirectEnergyMJPHa",
                table: "PlantProtection",
                newName: "TotalDirectEnergyMJPHa");

            migrationBuilder.RenameIndex(
                name: "IX_plantProtection_MachineId",
                table: "PlantProtection",
                newName: "IX_PlantProtection_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_plantProtection_Farmerid",
                table: "PlantProtection",
                newName: "IX_PlantProtection_Farmerid");

            migrationBuilder.RenameIndex(
                name: "IX_plantProtection_EquipmentId",
                table: "PlantProtection",
                newName: "IX_PlantProtection_EquipmentId");

            migrationBuilder.RenameColumn(
                name: "TtllDirectEnergyMJPHa",
                table: "Irrigation",
                newName: "TotalDirectEnergyMJPHa");

            migrationBuilder.RenameColumn(
                name: "LabourChargePDay",
                table: "Irrigation",
                newName: "TimeTaken");

            migrationBuilder.RenameColumn(
                name: "TtlDirectEnergyMJPHa",
                table: "InterCulture",
                newName: "TotalDirectEnergyMJPHa");

            migrationBuilder.RenameColumn(
                name: "TtlDirectEnergyMJPHa",
                table: "Fertilizer",
                newName: "TotalDirectEnergyMJPHa");

            migrationBuilder.RenameIndex(
                name: "IX_SeedBeeds_MachineId",
                table: "SeedBeed",
                newName: "IX_SeedBeed_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_SeedBeeds_Farmerid",
                table: "SeedBeed",
                newName: "IX_SeedBeed_Farmerid");

            migrationBuilder.RenameIndex(
                name: "IX_SeedBeeds_EquipmentId",
                table: "SeedBeed",
                newName: "IX_SeedBeed_EquipmentId");

            migrationBuilder.AlterColumn<double>(
                name: "Energy",
                table: "Machine",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantProtection",
                table: "PlantProtection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeedBeed",
                table: "SeedBeed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtection_Equipment_EquipmentId",
                table: "PlantProtection",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtection_FarmerDetail_Farmerid",
                table: "PlantProtection",
                column: "Farmerid",
                principalTable: "FarmerDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtection_Machine_MachineId",
                table: "PlantProtection",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedBeed_Equipment_EquipmentId",
                table: "SeedBeed",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedBeed_FarmerDetail_Farmerid",
                table: "SeedBeed",
                column: "Farmerid",
                principalTable: "FarmerDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedBeed_Machine_MachineId",
                table: "SeedBeed",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtection_Equipment_EquipmentId",
                table: "PlantProtection");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtection_FarmerDetail_Farmerid",
                table: "PlantProtection");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtection_Machine_MachineId",
                table: "PlantProtection");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedBeed_Equipment_EquipmentId",
                table: "SeedBeed");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedBeed_FarmerDetail_Farmerid",
                table: "SeedBeed");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedBeed_Machine_MachineId",
                table: "SeedBeed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantProtection",
                table: "PlantProtection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeedBeed",
                table: "SeedBeed");

            migrationBuilder.RenameTable(
                name: "PlantProtection",
                newName: "plantProtection");

            migrationBuilder.RenameTable(
                name: "SeedBeed",
                newName: "SeedBeeds");

            migrationBuilder.RenameColumn(
                name: "TotalEnergyStrawMJPHa",
                table: "Production",
                newName: "TtlEnergyStrawMJPHa");

            migrationBuilder.RenameColumn(
                name: "TotalEnergyGrainMJPHa",
                table: "Production",
                newName: "TtlEnergyGrainMJPHa");

            migrationBuilder.RenameColumn(
                name: "TotalDirectEnergyMJPHa",
                table: "plantProtection",
                newName: "TtlDirectEnergyMJPHa");

            migrationBuilder.RenameIndex(
                name: "IX_PlantProtection_MachineId",
                table: "plantProtection",
                newName: "IX_plantProtection_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantProtection_Farmerid",
                table: "plantProtection",
                newName: "IX_plantProtection_Farmerid");

            migrationBuilder.RenameIndex(
                name: "IX_PlantProtection_EquipmentId",
                table: "plantProtection",
                newName: "IX_plantProtection_EquipmentId");

            migrationBuilder.RenameColumn(
                name: "TotalDirectEnergyMJPHa",
                table: "Irrigation",
                newName: "TtllDirectEnergyMJPHa");

            migrationBuilder.RenameColumn(
                name: "TimeTaken",
                table: "Irrigation",
                newName: "LabourChargePDay");

            migrationBuilder.RenameColumn(
                name: "TotalDirectEnergyMJPHa",
                table: "InterCulture",
                newName: "TtlDirectEnergyMJPHa");

            migrationBuilder.RenameColumn(
                name: "TotalDirectEnergyMJPHa",
                table: "Fertilizer",
                newName: "TtlDirectEnergyMJPHa");

            migrationBuilder.RenameIndex(
                name: "IX_SeedBeed_MachineId",
                table: "SeedBeeds",
                newName: "IX_SeedBeeds_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_SeedBeed_Farmerid",
                table: "SeedBeeds",
                newName: "IX_SeedBeeds_Farmerid");

            migrationBuilder.RenameIndex(
                name: "IX_SeedBeed_EquipmentId",
                table: "SeedBeeds",
                newName: "IX_SeedBeeds_EquipmentId");

            migrationBuilder.AddColumn<double>(
                name: "LabourChargePDay",
                table: "Sowing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TypeOperation",
                table: "Sowing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LabourChargePDay",
                table: "plantProtection",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TypeOperation",
                table: "plantProtection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Energy",
                table: "Machine",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "TypeOperation",
                table: "Irrigation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LabourChargePDay",
                table: "InterCulture",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LabourChargePDay",
                table: "Fertilizer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Equipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LabourChargePDay",
                table: "SeedBeeds",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_plantProtection",
                table: "plantProtection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeedBeeds",
                table: "SeedBeeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plantProtection_Equipment_EquipmentId",
                table: "plantProtection",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_plantProtection_FarmerDetail_Farmerid",
                table: "plantProtection",
                column: "Farmerid",
                principalTable: "FarmerDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_plantProtection_Machine_MachineId",
                table: "plantProtection",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedBeeds_Equipment_EquipmentId",
                table: "SeedBeeds",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedBeeds_FarmerDetail_Farmerid",
                table: "SeedBeeds",
                column: "Farmerid",
                principalTable: "FarmerDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedBeeds_Machine_MachineId",
                table: "SeedBeeds",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
