using EMA.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class ExcelDownloadModel
    {
        public List<SeedBeedDownloadMode> SeedBeed { get; set; }
        public List<SowingDownloadMode> Sowing { get; set; }
        public List<FertilizerDownloadMode> Fertilizer { get; set; }
        public List<InterCultureDownloadMode> InterCulture { get; set; }
        public List<IrrigationDownloadMode> Irrigation { get; set; }
        public List<PlantProtectionDownloadMode> PlantProtection { get; set; }
        public List<HarvestingDownloadMode> Harvesting { get; set; }
        public List<ProductionDownloadMode> Production { get; set; }
    }

    public class SeedBeedDownloadMode {
        public string FarmerName { get; set; }      
        public string TypeOperation { get; set; }
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public double FuelEnergy { get; set; }
        public int DriverLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double InDirectEnergyMJPH { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public double TotalInDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public string Equipment { get; set; }        
        public string Machine { get; set; }
    }
    public class SowingDownloadMode {
        public string Farmer { get; set; }        
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public double FuelEnergy { get; set; }
        public int DriverLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public string Material { get; set; }
        public double QtyKgPHa { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public string Equipment { get; set; }       
        public string Machine { get; set; }

      
    }
    public class FertilizerDownloadMode {
        public int Labourer { get; set; }
        public double Capacity { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public string Material1 { get; set; }
        public double QtyKgPHa1 { get; set; }
        public string Material2 { get; set; }
        public double QtyKgPHa2 { get; set; }
        public string Material3 { get; set; }
        public double QtyKgPHa3 { get; set; }
        public string Material4 { get; set; }
        public double QtyKgPHa4 { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public double TotalEnergy { get; set; }
        public string Farmer { get; set; }
    }
    public class InterCultureDownloadMode {
        public string Farmer { get; set; }
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public double FuelEnergy { get; set; }
        public int DriverLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public string Material { get; set; }
        public double QtyKgPHa { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public string Equipment { get; set; }       
        public string Machine { get; set; }

       
    }
    public class IrrigationDownloadMode {
        public string Farmer { get; set; }      
        public string OwnHired { get; set; }
        public double EleckWh { get; set; }
        public double ElecEnergy { get; set; }
        public int OperatorLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double TimeTaken { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public string Equipment { get; set; }      
        public string Machine { get; set; }
       
    }
    public class PlantProtectionDownloadMode {
        public string Farmer { get; set; }
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public double FuelEnergy { get; set; }
        public int DriverLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public string Material { get; set; }
        public double QtyKgPHa { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public string Equipment { get; set; }
        public string Machine { get; set; }
    }
    public class HarvestingDownloadMode {
        public string Farmer { get; set; }
        public string TypeOperation { get; set; }
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public double FuelEnergy { get; set; }
        public int DriverLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double InDirectEnergyMJPH { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public double LabourChargePDay { get; set; }
        public double TotalEnergy { get; set; }
        public string Equipment { get; set; }
        public string Machine { get; set; }
    }
    public class ProductionDownloadMode {
        public string Farmer { get; set; }
        public double GrainProduction { get; set; }
        public double StrawProduction { get; set; }
        public double Price { get; set; }
        public double TotalEnergyMJPHa { get; set; }
        public double GrainStrawRatio { get; set; }
        public double TotalEnergyGrainMJPHa { get; set; }
        public double TotalEnergyStrawMJPHa { get; set; }
    }



    
}
