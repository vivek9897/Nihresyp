using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class EACTableLinear
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Initial Reservoir Level(m)")]
        public decimal Numbersofyears { get; set; }
        [DisplayName("Intermental Level(m)")]
        public decimal Reliability1 { get; set; }
        [DisplayName("No. of data points inE-A-C Table")]
        public int numberofdatapointsineac { get; set; }
        [DisplayName("factor for Converting Elevation to'm'")]
        public decimal Reliability3 { get; set; }
        [DisplayName("factor for Converting Capacity to'Cu.m'")]
        public decimal Reliability4 { get; set; }
        [DisplayName("factor for Converting Area to 'Sq.m'")]
        public decimal Reliability5 { get; set; }

        public List<Eactbldata> eactbldatas { get; set; }
       
    }
    public class Eactbldata
    {
        public int elevation { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
    }

    public class EACTableApprox
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("River bed Level(m)")]
        public decimal Numbersofyears { get; set; }
        [DisplayName("Full Reservoir Level(m)")]
        public decimal Reliability1 { get; set; }
        [DisplayName("Area at FRL(Sq.Km)")]
        public decimal Reliability2 { get; set; }
        [DisplayName("Capacity at FRL(MCM)")]
        public decimal Reliability3 { get; set; }
        [DisplayName("Initial Elevation Of EAC Table(m)")]
        public decimal Reliability4 { get; set; }
        [DisplayName("Incremental Elevation(m)")]
        public decimal Reliability5 { get; set; }

    }
}