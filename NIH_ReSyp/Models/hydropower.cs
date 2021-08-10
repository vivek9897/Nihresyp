using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class hydropower
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Starting Year")]
        public int Startingyear { get; set; }
        [DisplayName("Starting Month(M)")]
        public int startingmonth { get; set; }
        [DisplayName("Number of Months For Analysis")]
        public int numberofmonthsforanalysis { get; set; }
        [DisplayName("Maximum Possible Power Gen.(kW)")]
        public int Reliability3 { get; set; }
        [DisplayName("select Analysis Option")]
        public string Reliability4 { get; set; }
        [DisplayName("Power Demand")]
        public int Reliability5 { get; set; }
        [DisplayName("Capacity at MDDL(MCM)'")]
        public decimal Reliability6 { get; set; }
        [DisplayName("Capacity at FRL(MCM)")]
        public decimal Reliability7 { get; set; }
        [DisplayName("Initial Reservoir Capacity")]
        public decimal Reliability8 { get; set; }
        [DisplayName("Tail Water Level(m)")]
        public decimal Reliability9 { get; set; }
        [DisplayName("Power Plant Efficiency(o-1)")]
        public decimal Reliabilit { get; set; }
        [DisplayName("No. of Data Points in E-A-C Table")]
        public int numberofdatapoints { get; set; }
        [DisplayName("Factor for Converting Inflows to 'Cu.m'")]
        public decimal Reliaba { get; set; }
        [DisplayName("Factor for Converting Evaporation to 'm'")]
        public decimal Reliabw { get; set; }
        [DisplayName("Factor for Converting Elevation to 'm'")]
        public decimal Reliabq { get; set; }
        [DisplayName("Factor for Converting Area to 'Sq.m'")]
        public decimal Reliabc { get; set; }
        [DisplayName("Factor for Converting Capacity to 'Cu.m'")]
        public decimal Reliabd { get; set; }

        public List<EACtable> eACtables { get; set; }

        public List<MonthInflow> monthInflows { get; set; }
    }
    public class EACtable
    {
        public int elevation { get; set; }
        public int area { get; set; }
        public int capacity { get; set; }
    }
    public class MonthInflow
    {
        public string monthyear { get; set; }
        public int inflow { get; set; }
    }

    public class Evaporationdepths
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