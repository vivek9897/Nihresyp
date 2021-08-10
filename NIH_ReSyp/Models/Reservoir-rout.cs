using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class Reservoir_rout
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("No. of data Points in Elev-cap-Rel cap Table")]
        public int Numbersofyears { get; set; }
        [DisplayName("Number of Periods for Analysis")]
        public int Reliability1 { get; set; }
        [DisplayName("Computational Time Steps(Hrs)")]
        public decimal Reliability2 { get; set; }
        [DisplayName("Specify the Method of Reservoir Routing")]
        public string Reliability3 { get; set; }
        [DisplayName("Initial Elevation of Reservoir")]
        public decimal Reliability4 { get; set; }
        [DisplayName("Specify Coefficient for Coefficient Method")]
        public decimal Reliability5 { get; set; }
        [DisplayName("factor for Converting Inflows to 'Cu.m'")]
        public decimal Reliability6 { get; set; }
        [DisplayName("factor for Converting Elevation  to 'm'")]
        public decimal Reliability7 { get; set; }
        [DisplayName("factor for Converting Capacity to 'Cu.m'")]
        public decimal Reliability8 { get; set; }
        [DisplayName("factor for Converting Rel Capacity to 'Cumec'")]
        public decimal Reliability9 { get; set; }

        public List<Ecrctable> ecrctables { get; set; }

        public List<InflowTable> inflowTables { get; set; }
    }
    public class Ecrctable
    {
        public int Elevation { get; set; }
        public int Capacity { get; set; }
        public int RelCapacity { get; set; }
    }
    public class InflowTable
    {
        public int Sequence { get; set; }
        public int Inflow { get; set; }
        
    }
}