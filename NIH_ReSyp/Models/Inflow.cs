using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class Inflow
    {
        [DisplayName("Title Of the Problem")]
        public string Titleofprob { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("No. of levels in E-A-C Table")]
        public int Numbersoflevelsineac { get; set; }
        [DisplayName("Time Step")]
        public string timestep { get; set; }
        [DisplayName("Option for Negative Flow Correction")]
        public string negativeflowcorrection { get; set; }
        [DisplayName("Option for INflow Estimation Location")]
        public decimal optionforinflow { get; set; }
        [DisplayName("Number of Data Sets")]
        public int numberofdataset { get; set; }
        [DisplayName("factor for Converting Elevation to 'm")]
        public decimal convertingelevation { get; set; }
        [DisplayName("factor for Converting Area to 'Sq.m'")]
        public decimal factorareaconverting { get; set; }
        [DisplayName("factor for Converting Capacity to 'Cu.m'")]
        public decimal areaconverting { get; set; }
        [DisplayName("factor for Converting seepage Rate to")]
        public decimal seepagerate { get; set; }
        [DisplayName("factor for Converting Reservoir Level to ")]
        public decimal reservoirlevel { get; set; }
        [DisplayName("factor for Converting Release to 'Cu.m'")]
        public decimal releasetocum { get; set; }
        [DisplayName("factor for Converting Spill to 'Cu.m'")]
        public decimal convertingspill { get; set; }
        [DisplayName("factor for Converting Evaporation Depth to 'm'")]
        public decimal evaporationdepth { get; set; }
        [DisplayName("factor for Converting Rainfall Depth to 'm'")]
        public decimal rainfalldepth { get; set; }

        public List<EACStable> eACStables { get; set; }
        public List<Reservoirdata> reservoirdatas { get; set; }
    }
    public class EACStable
    {
        public int elevation { get; set; }
        public int area { get; set; }
        public int capacity { get; set; }
        public int seepage_rate { get; set; }
    }
    public class Reservoirdata
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int Res_level { get; set; }
        public int Release { get; set; }
        public int spill { get; set; }
        public int eva_depth { get; set; }
        public int Rf_depth { get; set; }
    }
    public class Inflow2
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Initial Elevation(m)")]
        public decimal Numbersofyears { get; set; }
        [DisplayName("Incremental Elevation(m)")]
        public decimal Reliability1 { get; set; }
        [DisplayName("Initial Rate Of Rise(m/hr)")]
        public decimal Reliability2 { get; set; }
        [DisplayName("Incremental Of Rise(m/hr)")]
        public decimal Reliability3 { get; set; }
        [DisplayName("Release From The Reservoir")]
        public decimal Reliability4 { get; set; }
        [DisplayName("No. of data points in E-A-C Table")]
        public int numberofdatapointsintable { get; set; }
        [DisplayName("Factor for Converting Elevation to 'm'")]
        public decimal Reliability6 { get; set; }
        [DisplayName("Factor for Converting Area to 'Sq.m'")]
        public decimal Reliabili6 { get; set; }
        [DisplayName("Factor for Converting Capacity to 'Cu.m'")]
        public decimal Reliabil { get; set; }

        public List<EACtablevalues> eACtablevalues { get; set; }
        
    }
    public class EACtablevalues
    {
        public int elevation { get; set; }
        public int area { get; set; }
        public int capacity { get; set; }
       
    }
}