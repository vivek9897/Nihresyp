using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class ProbableFlowEstimation
    {
        [DisplayName("Title Of the Problem")]
        public string Titlem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string NmeofReservoir { get; set; }
        [DisplayName("Number Of Years Of Inflows")]
        public int Numbersofyears{ get; set; }
        [DisplayName("Reliability Level-1")]
        public decimal Reliability1 { get; set; }
        [DisplayName("Reliability Level-2")]
        public decimal Reliability2 { get; set; }
        [DisplayName("Reliability Level-3")]
        public decimal Reliability3 { get; set; }
        [DisplayName("Reliability Level-4")]
        public decimal Reliability4 { get; set; }
        [DisplayName("Reliability Level-5")]
        public decimal Reliability5 { get; set; }
        [DisplayName("Reliability Level-6")]
        public decimal Reliability6 { get; set; }

        public List<Numberofinflows> numberofinflows { get; set; }
    }
    public class Numberofinflows
    {
        public int year { get; set; }
        public int Inflow { get; set; }
    }
    public class InitialRuleCurveDerivation
    {
        [DisplayName("Title Of the Problem")]
        public string Titleproblemreservoir { get; set; }
        [DisplayName("Name Of Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Method Of Supply Through Power Plant")]
        public string Starting_year { get; set; }
        [DisplayName("Minimum Drawdown Level(m)")]
        public decimal Starting_Month { get; set; }
        [DisplayName("Full Reservoir Level(m)")]
        public decimal No_of_months_for_analysis { get; set; }
        [DisplayName("Number Of Data Points in E-A-C Table")]
        public int Dead_storage_capacity { get; set; }
        [DisplayName("Factor For Converting Inflows to 'Cu.M'")]
        public decimal InitialReserVoirStorage { get; set; }
        [DisplayName("Factor For Converting Irr. Demands to 'Cu.M'")]
        public decimal Converting_Demands_to_CuM { get; set; }
        [DisplayName("Factor For Converting Power Demad to 'Kw.h'")]
        public decimal Specicyanualyield { get; set; }
        [DisplayName("Factor For Converting Evaporation to 'm'")]
        public decimal SpecicyStorage { get; set; }
        [DisplayName("Factor For Converting Elevation to 'm'")]
        public decimal No_of_data_in_EAC_table { get; set; }
        [DisplayName("Factor For Converting Area to 'Sq.m'")]
        public decimal areaconvertingtosqm { get; set; }
        [DisplayName("Factor For Converting Capacity to 'Cu.m'")]
        public decimal Evaaccuracy { get; set; }
        [DisplayName("Maximan Capacity Of the Power Plant(MW)")]
        public decimal Eoverallaccuracy { get; set; }
        [DisplayName("Tail Water Level(m)")]
        public decimal Converting_Inflows_to_CuM { get; set; }
        [DisplayName("Minimum Reservoir For Power Plant(m)")]
        public decimal ConvertingInflowsto_CuM { get; set; }
        [DisplayName("Efficiency Of Power Plant")]
        public decimal ConvertingInflowstoCuM { get; set; }
        [DisplayName("High Priorty To")]
        public string areaconverttothem { get; set; }
 
        public List<Numberofeactable> numberofeactables { get; set; }
    }
 public class Numberofeactable
    {
        public int Area { get; set; }
        public int Elevation { get; set; }
        public int Capacity { get; set; }
    }
    public class ConservationOperation
    {
        [DisplayName("Title Of the Problem")]
        public string Titleof_problem { get; set; }
        [DisplayName("Number Of Structures In The System")]
        public decimal numberof{ get; set; }
        [DisplayName("Starting Year Of Simulation")]
        public decimal staringyear{ get; set; }
        [DisplayName("Starting Month Of Simulation")]
        public decimal staringmonth{ get; set; }
        [DisplayName("Time Step (1-Monthly,3-Ten Daily)")]
        public decimal timestep{ get; set; }
        [DisplayName("Number Of Periods Of Simulation")]
        public decimal numberofperiod{ get; set; }
        [DisplayName("Id Of Structure Whose Data Is Entered")]
        public decimal Idofstructure{ get; set; }
    }
    public class ConservationOperation2
    {
        [DisplayName("Name Of Structure(Alphabetic)")]
        public string Title_of_problem { get; set; }
        [DisplayName("Number Of Immediately U/S structures")]
        public decimal Name_of_Reservoir { get; set; }
        [DisplayName("IDs Of Immediately U/S Structures(Space-Seprated)")]
        public decimal Starting_year { get; set; }
        [DisplayName("Gross Capacity at FRL 'MCM'")]
        public decimal Starting_Month { get; set; }
        [DisplayName("Gross Capacity at MDDL 'MCM'")]
        public decimal No_of_months_for_analysis { get; set; }
        [DisplayName("Initial Capacity at Start of Simulation 'MCM'")]
        public decimal Dead_storage_capacity { get; set; }
        [DisplayName("Method Of Hydropower Supply")]
        public string Deadstoragecapacity { get; set; }
        [DisplayName("Reduction Factor For Irrigation In Scarcity(0 to 1)")]
        public decimal Dead_storagecapacity { get; set; }
        [DisplayName("Reduction Factor For Irrigation In Scarcity(0 to 1)")]
        public decimal Dead_storagepacity { get; set; }
        [DisplayName("Factor Defining Critical Supply Conditions(0 to 1)")]
        public decimal Deadstoragepacity { get; set; }
        [DisplayName("Factor For Converting Inflows to 'Cu.M'")]
        public decimal InitialReserVoirStorage { get; set; }
        [DisplayName("Factor For Converting Power Demad to 'Kw.h'")]
        public decimal Specicyanualyield { get; set; }
        [DisplayName("Factor For Converting Irrigation Demands to 'Cu.M'")]
        public decimal Converting_Demands_to_CuM { get; set; }
        [DisplayName("Factor For Converting Domestic Demands to 'Cu.M'")]
        public decimal Converting_Demand_CuM { get; set; }
        [DisplayName("Factor For Converting Min_Flow Demands to 'Cu.M'")]
        public decimal Converting_Deman_CuM { get; set; }
        [DisplayName("Factor For Converting Transfer Demands to 'Cu.M'")]
        public decimal Converting_Demands_uM { get; set; }
        [DisplayName("Factor For Converting Elevation In E-A-C Table to 'm'")]
        public decimal SpecicyStorage { get; set; }
        [DisplayName("Factor For Converting Evaporation Depths to 'm'")]
        public decimal No_of_data_in_EAC_table { get; set; }
        [DisplayName("Factor For Converting Area IN E-A-C Table to 'Sq.m'")]
        public decimal RequiredReliability { get; set; }
        [DisplayName("Factor For Converting Cap. In E-A-C Table to 'Cu.m'")]
        public decimal Evaaccuracy { get; set; }
       
    }
    public class ConservationOperation3
    {
       
        [DisplayName("Installed Capacity Of Power Plants 'MW'")]
        public decimal Dead_storagecapacity { get; set; }
        [DisplayName("Tail Water Elevation 'm'")]
        public decimal Dead_storagepacity { get; set; }
        [DisplayName("Minimum Reservoir Level For Power Generation 'm'")]
        public decimal Deadstoragepacity { get; set; }
        [DisplayName("Efficiency Of Power Plants(%)")]
        public decimal InitialReserVoirStorage { get; set; }
        [DisplayName("Number of Data Points in E-A-C Table")]
        public int Numberofpointsineactable { get; set; }
        [DisplayName("Details of Results Required(0-Not Required,1-Yearly,2-Periodwise)")]
        public decimal Converting_Demands_to_CuM { get; set; }
        [DisplayName("ID of D/S Structure Whose Demands are to be Satisfied From Current Structure")]
        public decimal Converting_Demand_CuM { get; set; }
        [DisplayName("Return Flow From Irrigation Release(%)")]
        public decimal Converting_Deman_CuM { get; set; }
        [DisplayName("Does This Structure Transfer Water To Other Structure/Basin")]
        public decimal Converting_Demands_uM { get; set; }
        [DisplayName("ID of Structure From Which Water is Recieved")]
        public decimal SpecicyStorage { get; set; }
        [DisplayName("Enroute Diversion/Conveyanee Loss(%)")]
        public decimal No_of_data_in_EAC_table { get; set; }
        [DisplayName("Inflow Data Available(1)/Computed(2)")]
        public decimal RequiredReliability { get; set; }
        [DisplayName("Specify Structure ID For Computing Inflows For Inflow Modifying Factor")]
        public decimal Evaaccuracy { get; set; }
        [DisplayName("Inflow Modifying Factor")]
        public decimal Evaacracy { get; set; }

        public List<Specifyeactable> specifyeactables { get; set; }

    }
    public class Specifyeactable
    {
        public int Point { get; set; }
        public int Elevation { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
    }
    public class EvaporationDepth
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
    public class INFLOWDATA
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