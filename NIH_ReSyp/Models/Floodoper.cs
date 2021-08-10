using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class Floodoper
    {
        [DisplayName("Title Of the Problem")]
        public string Titleof_problem { get; set; }
        [DisplayName("Number Of Structures In The System")]
        public decimal numberofstructure{ get; set; }
        [DisplayName("Starting Hour Of Simulation")]
        public decimal staringyear { get; set; }
        [DisplayName("Starting Day Of Simulation")]
        public decimal staringmnth { get; set; }
        [DisplayName("Starting Month Of Simulation")]
        public decimal staringmonth { get; set; }
        [DisplayName("Time Step(Hrs)")]
        public decimal timestep { get; set; }
        [DisplayName("Number Of Periods Of Simulation")]
        public decimal numberofperiod { get; set; }
        [DisplayName("Id Of Structure Whose Data Is Entered")]
        public decimal Idofstructure { get; set; }
    }
    public class Floodoper2
    {
        [DisplayName("Name Of Structure(Alphabetic)")]
        public string Title_of_problem { get; set; }
        [DisplayName("Number Of Immediately U/S structures")]
        public decimal Name_of_Reservoir { get; set; }
        [DisplayName("IDs Of Immediately U/S Structures(Space-Seprated)")]
        public decimal Starting_year { get; set; }
        [DisplayName("Maximum Storage Capacity 'MCM'")]
        public decimal Starting_Month { get; set; }
        [DisplayName("Dead Storage Capacity'MCM'")]
        public decimal No_of_months_for_analysis { get; set; }
        [DisplayName("Initial Capacity at Start of Simulation 'MCM'")]
        public decimal Dead_storage_capacity { get; set; }
        [DisplayName("Gate Factor(0.1 to 1-Storage Dam, 2-ungated Dam, 3-Diversion)")]
        public decimal Deadsoragecapacity { get; set; }
        [DisplayName("Full Reservoir Level(m)")]
        public decimal Deadstoragecapacity { get; set; }
        [DisplayName("Safe Capacity od D/S Channel 'Cumec'")]
        public decimal Deadstogecapacity { get; set; }
        [DisplayName("Reservoir Critical Level(m)")]
        public decimal Deadstoragecacity { get; set; }
        [DisplayName("Critical Inflow(cumec)")]
        public decimal Dead_storagecapacity { get; set; }
        [DisplayName("Max. Permissible Change in Release in Consecutive Periods")]
        public decimal Dead_storagepacity { get; set; }
        [DisplayName("Factor For Converting Elevation In E-A-C-R Table to 'm'")]
        public decimal SpecicyStorage { get; set; }
        [DisplayName("Factor For Converting Evaporation Depths to 'm'")]
        public decimal No_of_data_in_EAC_table { get; set; }
        [DisplayName("Factor For Converting Area IN E-A-C-R Table to 'Sq.m'")]
        public decimal RequiredReliability { get; set; }
        [DisplayName("Factor For Converting Cap. In E-A-C-R Table to 'Cu.m'")]
        public decimal Evaaccuracy { get; set; }
        [DisplayName("Factor For Converting Rel. Capacity In E-A-C-R Table to 'Cu.m'")]
        public decimal Evaaccury { get; set; }
       
    }
    public class Floodoper3
    {
        [DisplayName("Minimum Release To be Made 'cumec'")]
        public decimal Titleof_problem { get; set; }
        [DisplayName("Number Of Data Points in E-A-C-R Table")]
        public int numberofstructure { get; set; }
        [DisplayName("Whether Routing in Downstream Channel to be Carried out")]
        public string staringyear { get; set; }
        [DisplayName("Muskingum parameters 'k'")]
        public decimal staringmnth { get; set; }
        [DisplayName("Inflow Data Availabe(1)/Computed(2)")]
        public decimal staringmonth { get; set; }
        [DisplayName("Inflow Modifying Factor")]
        public decimal timestep { get; set; }
        [DisplayName("Structure ID. for Computing Inflows for Present Structure")]
        public decimal numberofperiod { get; set; }
        [DisplayName("For Detail Results Entere : 1 ")]
        public decimal Idofstructure { get; set; }

        public List<Specifyeacrtable> specifyeacrtables { get; set; }
    }
    public class Specifyeacrtable
    {
        public int Elevation { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
        public int RelCapacity { get; set; }
    }
}