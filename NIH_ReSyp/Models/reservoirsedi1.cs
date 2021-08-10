using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NIH_ReSyp.Models
{
    public class Reservoirsedi1
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Number of Levels in E-A-C Table")]
        public int Numbersoflevelsineacctbl { get; set; }
        [DisplayName("Type of Reservoir")]
        public string Reliability1 { get; set; }
        [DisplayName("factor for Converting Elevation  to 'Sq.m'")]
        public decimal Reliability2 { get; set; }
        [DisplayName("factor for Converting Elevation  to 'm'")]
        public decimal Reliability3 { get; set; }
        [DisplayName("factor for Converting Capacity to'Cu.m'")]
        public decimal Reliability4 { get; set; }
        [DisplayName("Sediment Volume to be Distributed 'Cu.m'")]
        public decimal Reliability5 { get; set; }
        [DisplayName("River Bed Level at Dam Site 'M'")]
        public decimal Reliability6 { get; set; }
        [DisplayName("Full Reservoir Level 'M'")]
        public decimal Reliability7 { get; set; }

        public List<NewzeroEacTbl> newzeroEacTbls { get; set; }
       
    }
    public class NewzeroEacTbl
    {
        public int Elevation { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
    }
    public class Reservoirsedi2
    {
        [DisplayName("Title Of the Problem")]
        public string Title_of_problem { get; set; }
        [DisplayName("Name Of The Reservoir")]
        public string Name_of_Reservoir { get; set; }
        [DisplayName("Number of Levels in E-A-C Table")]
        public int NumbersofLevelsineac { get; set; }
        [DisplayName("Type of Reservoir")]
        public string Reliability1 { get; set; }
        [DisplayName("factor for Converting Elevation  to 'Sq.m'")]
        public decimal Reliability2 { get; set; }
        [DisplayName("factor for Converting Elevation  to 'm'")]
        public decimal Reliability3 { get; set; }
        [DisplayName("factor for Converting Capacity to'Cu.m'")]
        public decimal Reliability4 { get; set; }
        [DisplayName("Sediment Volume to be Distributed 'Cu.m'")]
        public decimal Reliability5 { get; set; }
        [DisplayName("River Bed Level at Dam Site 'M'")]
        public decimal Reliability6 { get; set; }
        [DisplayName("Full Reservoir Level 'M'")]
        public decimal Reliability7 { get; set; }
        [DisplayName(" New-zero Elevation 'm'")]
        public decimal newzero { get; set; }


        public List<SedimentprofileEacTbl> sedimentprofileEacTbls { get; set; }
    }
    public class SedimentprofileEacTbl
    {
        public int Elevation { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
    }
}