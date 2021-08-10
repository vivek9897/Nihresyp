using NIH_ReSyp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIH_ReSyp.Controllers
{
    public class InflowestimationController : Controller
    {


        public ActionResult Inflow_Estimation_form()
        {
            
            var list = new List<string>() {"Daily","Ten Daily","Monthly"};
            ViewBag.list = list;
            var list2 = new List<string>() { "0-No Correction", "1-Negative Flow Adjustment in Whole Year Depending on Magnitude", "2-Negative Flow Adjustment in Adjecent Values Depending on Magnitude" };
            ViewBag.list2 = list2;
            return View();
        }

        [HttpPost]
        public ActionResult Inflow_Estimation_form(Inflow inf)
        {
            var list = new List<string>() { "Daily", "Ten Daily", "Monthly" };
            ViewBag.list = list;
            var list2 = new List<string>() { "0-No Correction", "1-Negative Flow Adjustment in Whole Year Depending on Magnitude", "2-Negative Flow Adjustment in Adjecent Values Depending on Magnitude" };
            ViewBag.list2 = list2;         
            string path = @"E:\MYData\Textfile.txt";
            var ReseVOIRDATA = TempData["Reservoirrout"] as IEnumerable<Reservoirdata>;
            var ReseVOIRDATAa = TempData["Reservoirroutinflow"] as IEnumerable<EACStable>;
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(inf.Titleofprob.PadLeft(11) + "\n"
                    + inf.Name_of_Reservoir + "\n"
                   + inf.Numbersoflevelsineac.ToString().PadLeft(9)
                    + inf.timestep.PadLeft(9)
                     + inf.negativeflowcorrection.PadLeft(9)
                     + inf.optionforinflow.ToString().PadLeft(9)
                     + inf.numberofdataset.ToString().PadLeft(9)
                    + inf.convertingelevation.ToString().PadLeft(5)
                    + inf.factorareaconverting.ToString().PadLeft(9)
                     + inf.areaconverting.ToString().PadLeft(9)
                   + inf.seepagerate.ToString().PadLeft(9)
                     + inf.reservoirlevel.ToString().PadLeft(9)
                     + inf.releasetocum.ToString().PadLeft(9)
                     + inf.convertingspill.ToString().PadLeft(9)
                     + inf.evaporationdepth.ToString().PadLeft(9)
                     + inf.rainfalldepth.ToString().PadLeft(9)
                    );

                foreach (var a in ReseVOIRDATA)
                {
                    int year = a.year;
                    int month = a.month;
                    int day = a.day;
                    int reslevel = a.Res_level;
                    int release = a.Release;
                    int spill = a.spill;
                    int evadepth = a.eva_depth;
                    int rfdepth = a.Rf_depth;
                    
                    sw.WriteLine
                   (
                        year.ToString().PadLeft(5)
                        + month.ToString().PadLeft(5)
                        + day.ToString().PadLeft(3)
                        + reslevel.ToString().PadLeft(5)
                        + release.ToString().PadLeft(3)
                        + spill.ToString().PadLeft(5)
                        + evadepth.ToString().PadLeft(3)
                        + rfdepth.ToString().PadLeft(5)+"\n"

                    );
                }

                foreach (var a in ReseVOIRDATAa)
                {
                    int elev = a.elevation;
                    int area = a.area;
                    int cap = a.capacity;
                    int seepage = a.seepage_rate;
                   

                    sw.WriteLine
                   (
                        elev.ToString().PadLeft(5)
                        + area.ToString().PadLeft(5)
                        + cap.ToString().PadLeft(3)
                        + seepage.ToString().PadLeft(5)
                        

                    );
                }
            }
            return File(path, "text/plain", "InflowEstimationform.spi");
        }

        [HttpPost]
        public JsonResult GetInflowEstimationFun(Inflow inf)
        {
            List<Reservoirdata> newlistreservoir = new List<Reservoirdata>();
            Reservoirdata obje;
            for (int a = 1; a <= inf.numberofdataset; a++)
            {
                obje = new Reservoirdata();
                obje.year = 0;
                obje.month = 0;
                obje.day = 0;
                obje.Res_level = 0;
                obje.Release = 0;
                obje.spill = 0;
                obje.eva_depth = 0;
                obje.Rf_depth = 0;
                newlistreservoir.Add(obje);
            }
            return Json(newlistreservoir, JsonRequestBehavior.AllowGet);         
        }

        public ActionResult Reservoirresult(List<Reservoirdata> reservoirdatas)
        {
            TempData["Reservoirrout"] = reservoirdatas;
            return RedirectToAction("Inflow_Estimation_form");
        }


        [HttpPost]
        public JsonResult GetInflowEstimation(Inflow inf)
        {  
            List<EACStable> newlistdata = new List<EACStable>();
            EACStable obj;
          

            for (int i = 1; i <= inf.Numbersoflevelsineac; i++)
            {
                obj = new EACStable();
                obj.elevation = 0;
                obj.area = 0;
                obj.capacity = 0;
                obj.seepage_rate = 0;
                newlistdata.Add(obj);
            }          
            //return File(path, "text/plain", "InflowEstimationform.spi");
            return Json(newlistdata,JsonRequestBehavior.AllowGet);
        }

        public ActionResult InflowResult(List<EACStable> eACStables)
        {
            TempData["Reservoirroutinflow"] = eACStables;
            return RedirectToAction("Inflow_Estimation_form");
        }

        public ActionResult Inflow_Estimation_form2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inflow_Estimation_form2(Inflow2 inf2)
        {
           
            string path = @"E:\MYData\Textfile.txt";
            var Eactablebldata = TempData["EACTABLEdata"] as IEnumerable<EACtablevalues>;

            using (StreamWriter swr = System.IO.File.CreateText(path))
            {
                swr.WriteLine(inf2.Title_of_problem + "\n"
                    + inf2.Name_of_Reservoir + "\n"
                   + inf2.Numbersofyears.ToString().PadLeft(9)
                    + inf2.Reliability1.ToString().PadLeft(9)
                     + inf2.Reliability2.ToString().PadLeft(9)
                     + inf2.Reliability3.ToString().PadLeft(9)
                     + inf2.Reliability4.ToString().PadLeft(9)
                    + inf2.numberofdatapointsintable.ToString().PadLeft(5)
                    + inf2.Reliability6.ToString().PadLeft(9)
                     + inf2.Reliabili6.ToString().PadLeft(9)
                   + inf2.Reliabil.ToString().PadLeft(9)
                    );

                foreach (var a in Eactablebldata)
                {
                    int elevation = a.elevation;
                    int area = a.area;
                    int capacity = a.capacity;
                    swr.WriteLine
                   (
                        elevation.ToString().PadLeft(5)
                        + area.ToString().PadLeft(5)
                        + capacity.ToString().PadLeft(3) + "\n"

                    );
                }
            }
            return File(path, "text/plain", "InflowEstimationform2.spi");
        }
        [HttpPost]
        public JsonResult InflowEstimationform(Inflow2 inf2)
        {          
            List<EACtablevalues> newlisttblvalue = new List<EACtablevalues>();
            EACtablevalues obj;
            for (int n = 1; n <= inf2.numberofdatapointsintable; n++)
            {
                obj = new EACtablevalues();
                obj.elevation = 0;
                obj.area = 0;
                obj.capacity = 0;
                newlisttblvalue.Add(obj);
            }            
            return Json(newlisttblvalue,JsonRequestBehavior.AllowGet);
            //return File(path, "text/plain", "InflowEstimationform2.spi");
        }

        public ActionResult InflowEstimationformreturn(List<EACtablevalues> eACtablevalues)
        {
            TempData["EACTABLEdata"] = eACtablevalues;
            return RedirectToAction("Inflow_Estimation_form2");
        }
    }
}