using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{

    public class capcompform1
    {
       
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Starting Year")]
        public int Starting_year { get; set; }
        [DisplayName("Starting Month")]
        public int Starting_Month { get; set; }
        [DisplayName("Number Of Months For Analysis")]
        public int No_of_month_for_analysis { get; set; }
        [DisplayName("Demand Vary Each Year")]
        public string Demand_each_year { get; set; }
        [DisplayName("Factor For Converting Inflows to 'Cu.M'")]
        public decimal Converting_Inflows_to_CuM { get; set; }
        [DisplayName("Factor For Converting Demand to 'Cu.M")]
        public decimal Converting_Demands_to_CuM { get; set; }
        
        public List<Inflowdemand> monthNamelist { get; set; }
        

    }
    public class capcompform2
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Starting Year")]
        public int Starting_year { get; set; }
        [DisplayName("Starting Month")]
        public int Starting_Month { get; set; }
        [DisplayName("Number Of Months For Analysis")]
        public int No_of_months_for_analysis { get; set; }
        [DisplayName("Dead Storage Capacity (MCM)")]
        public decimal Dead_storage_capacity { get; set; }
        [DisplayName("Initial ReserVoir Storage")]
        public decimal InitialReserVoirStorage { get; set; }
        [DisplayName("Yield Knownd and Storage Calculated")]
        public string Converting_Demands_to_CuM { get; set; }
        [DisplayName("Specify Annual Yield (MCM)")]
        public decimal Specicyanualyieldeded { get; set; }
        [DisplayName("Specify Storage (MCM)")]
        public decimal SpecicyStorage { get; set; }
        [DisplayName("Number Of Points In E-A-C Table")]
        public int No_of_data_in_EAC_table { get; set; }
        [DisplayName("Required Reliability (0-1)")]
        public decimal RequiredReliability { get; set; }
        [DisplayName("Evaporation Accuracy (0.00001-0.1)")]
        public decimal Evaaccuracy { get; set; }
        [DisplayName("Overall Accuracy (0.00001-0.1)")]
        public decimal Eoverallaccuracy { get; set; }
        [DisplayName("Factor For Converting Inflows to 'Cu.M'")]
        public decimal Converting_Inflows_to_CuM { get; set; }
        [DisplayName("Factor For Converting Evaporation to m")]
        public decimal ConvertingInflowsto_CuM { get; set; }
        [DisplayName("Factor For Converting Elevation to m")]
        public decimal ConvertingInflowstoCuM { get; set; }
        [DisplayName("Factor For Converting Area to 'sq.m'")]
        public decimal areaconverttothem { get; set; }
        [DisplayName("Factor For Converting Capacity to 'Cu.M'")]
        public decimal Converting_capacity_to_CuM { get; set; }

        public List<Inflowdemand2> monthnamelist { get; set; }

        public List<Eactable> noofeactable { get; set; }

    }

    public class Inflowdemand
    {
        public string monthyear { get; set; }
        public int Inflow { get; set; }
        public int Demand { get; set; }
    }

    public class Inflowdemand2
    {
        public string monthyear { get; set; }
        public int Inflow { get; set; }
        
    }
    public class Eactable
    {
        public int elevation { get; set; }
        public int area { get; set; }
        public int capacity { get; set; }
    }
    public class MonthlyYieldFactor
    {
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
    }

    public class EvaporationDepths
    {
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
    }
}