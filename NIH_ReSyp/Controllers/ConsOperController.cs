using NIH_ReSyp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace NIH_ReSyp.Controllers
{
    public class ConsOperController : Controller
    {
       
        // GET: ConsOper
        public ActionResult Probable_Flow_Estimation()
        {
            ProbableFlowEstimation newflow = new ProbableFlowEstimation();
            return View(newflow);
        }

        public void Output_file_Probableflow()
        {
            string workingDir = @"C:\nih_resyp\";
            string inputpath = @"D:\Sequent_Peak_Analysis (43).spi";

            string outputpath = @"D:\outFile_Probableflow.spi";

            string filepath = Path.Combine(workingDir, "s4.bat");   //not found bat file
            string file = Path.Combine(outputpath, "ouput.spi");

            string mmmFilePath = Path.Combine(workingDir, "mmm.bat");
            // create mmm file
            string[] lines =
        {
            inputpath, outputpath
        };

            System.IO.File.WriteAllLines(mmmFilePath, lines);

            Process p = new Process();
            p.StartInfo.FileName = filepath;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(workingDir);
            p.StartInfo.UseShellExecute = true;

            // Run the process and wait for it to complete
            p.Start();
            p.WaitForExit();


        }
        [HttpPost]
        public ActionResult Probable_Flow_Estimation(ProbableFlowEstimation flowEstimation)
        {    
            string path = @"E:\BossWebtech\Mydata\Textfile.spi"; 
            var enumerable = TempData["name"] as IEnumerable<Numberofinflows>;

            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(flowEstimation.Titlem + "\n"
                      + flowEstimation.NmeofReservoir + "\n"
                      + flowEstimation.Numbersofyears.ToString().PadLeft(0)
                      + flowEstimation.Reliability1.ToString().PadLeft(4)
                      + flowEstimation.Reliability2.ToString().PadLeft(3)
                      + flowEstimation.Reliability3.ToString().PadLeft(3)
                      + flowEstimation.Reliability4.ToString().PadLeft(3)
                      + flowEstimation.Reliability5.ToString().PadLeft(3)
                      + flowEstimation.Reliability6.ToString().PadLeft(3)
                      );
                foreach (var data in enumerable)
                {
                    int inflow = data.Inflow;
                    int year = data.year;
                    sw.WriteLine
                   (
                       inflow.ToString().PadLeft(1)
                       + year.ToString().PadLeft(10)
                   );
                }
            }
             return File(path, "text/plain", "Probable Flow Estimatio.spi");
            //return View();
        }

        


        [HttpPost]
        public JsonResult GetFlowEstimation(ProbableFlowEstimation flowEstimation)
        {
            List<Numberofinflows> numberofinflows = new List<Numberofinflows>();
            Numberofinflows obj;
            for (int a = 1; a <= flowEstimation.Numbersofyears; a++)
            {
                obj = new Numberofinflows();
                obj.year = 0;
                obj.Inflow = 0;
                numberofinflows.Add(obj);
            }

            return Json(numberofinflows, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetInflowResult(List<Numberofinflows> numberofinflowsnew)
        {
            TempData["name"] = numberofinflowsnew;
            TempData.Keep();
            return RedirectToAction("Probable_Flow_Estimation");
        }


        public ActionResult Initial_Rule_Curve_Derivation()
        {
            
            var list1 = new List<string>() { "No Power Plant", "All Rel Pass Through Plant", "WS Rel Pass Through Plant", "Irr Rel Pass Through Plant", "All Rel Bypass the Plant" };
            ViewBag.list = list1;
            var list2 = new List<string>() { "0-Irrigation", "1-Power" };
            ViewBag.list2 = list2;
            return View();
        }

        [HttpPost]
        public ActionResult Initial_Rule_Curve_Derivation(InitialRuleCurveDerivation initialRuleCurve )
        {
            var list1 = new List<string>() { "No Power Plant", "All Rel Pass Through Plant", "WS Rel Pass Through Plant", "Irr Rel Pass Through Plant", "All Rel Bypass the Plant" };
            ViewBag.list = list1;
            var list2 = new List<string>() { "0-Irrigation", "1-Power" };
            ViewBag.list2 = list2;
            string path = @"E:\MYData\Textfile.txt";
            var enumerable = TempData["InitialRule"] as IEnumerable<Numberofeactable>;
            var Evaporationdepth = TempData["EVAPOR"] as EvaporationDepth;
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(initialRuleCurve.Titleproblemreservoir + "\n"
                    + initialRuleCurve.Name_of_Reservoir + "\n"
                     + initialRuleCurve.No_of_months_for_analysis.ToString().PadLeft(0)
                   + initialRuleCurve.Starting_year.ToString().PadLeft(18)
                    + initialRuleCurve.Starting_Month.ToString().PadLeft(9)
                    + initialRuleCurve.InitialReserVoirStorage.ToString().PadLeft(7)
                    + initialRuleCurve.Converting_Demands_to_CuM.ToString().PadLeft(7)
                    + initialRuleCurve.Specicyanualyield.ToString().PadLeft(7)
                    + initialRuleCurve.SpecicyStorage.ToString().PadLeft(2) + "\n"
                     + initialRuleCurve.Dead_storage_capacity.ToString().PadLeft(9)  
                   + initialRuleCurve.No_of_data_in_EAC_table.ToString().PadLeft(2)
                     + initialRuleCurve.areaconvertingtosqm.ToString().PadLeft(2)
                     + initialRuleCurve.Evaaccuracy.ToString().PadLeft(2)
                     + initialRuleCurve.Eoverallaccuracy.ToString().PadLeft(9)
                     + initialRuleCurve.Converting_Inflows_to_CuM.ToString().PadLeft(9)
                     + initialRuleCurve.ConvertingInflowsto_CuM.ToString().PadLeft(9)
                     + initialRuleCurve.ConvertingInflowstoCuM.ToString().PadLeft(9)
                     + initialRuleCurve.areaconverttothem.ToString().PadLeft(9)+ "\n"
                     + Evaporationdepth.January.ToString().PadLeft(2)
                     + Evaporationdepth.February.ToString().PadLeft(14)
                     + Evaporationdepth.March.ToString().PadLeft(14)
                     + Evaporationdepth.April.ToString().PadLeft(14)
                     + Evaporationdepth.May.ToString().PadLeft(14)
                     + Evaporationdepth.June.ToString().PadLeft(14)
                     + Evaporationdepth.July.ToString().PadLeft(14)
                     + Evaporationdepth.August.ToString().PadLeft(14)
                     + Evaporationdepth.September.ToString().PadLeft(14)
                     + Evaporationdepth.October.ToString().PadLeft(14)
                     + Evaporationdepth.November.ToString().PadLeft(14)
                     + Evaporationdepth.December.ToString().PadLeft(14)

                    );
                foreach(var a in enumerable)
                {
                    int area = a.Area;
                    int elevation = a.Elevation;
                    int capacity = a.Capacity;
             
                sw.WriteLine
                (
                  area.ToString().PadLeft(2)
                + elevation.ToString().PadLeft(3)
                + capacity.ToString().PadLeft(4)
                );
                
            }
        }

             return File(path, "text/plain", "Initial Rule Curve Derivation.spi");       
        }


        public void Output_file_initialrule()
        {
            string workingDir = @"C:\nih_resyp\";
            string inputpath = @"D:\Sequent_Peak_Analysis (43).spi";

            string outputpath = @"D:\outFile_Probableflow.spi";

            string filepath = Path.Combine(workingDir, "s7.bat");   //not found bat file
            string file = Path.Combine(outputpath, "ouput.spi"); 

            string mmmFilePath = Path.Combine(workingDir, "mmm.bat");
            // create mmm file
            string[] lines =
        {
            inputpath, outputpath
        };

            System.IO.File.WriteAllLines(mmmFilePath, lines);

            Process p = new Process();
            p.StartInfo.FileName = filepath;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(workingDir);
            p.StartInfo.UseShellExecute = true;

            // Run the process and wait for it to complete
            p.Start();
            p.WaitForExit();


        }
        [HttpPost]
        public JsonResult GetInitialRule(InitialRuleCurveDerivation initialRuleCurve, List<Numberofeactable> newlistofeac)
        {
            List<Numberofeactable> newnumberlist = new List<Numberofeactable>();
            Numberofeactable objec;   
            for (int i = 1; i <= initialRuleCurve.Dead_storage_capacity; i++)
            {
                objec = new Numberofeactable();
                objec.Elevation = 0;
                objec.Area = 0;
                objec.Capacity = 0;
                newnumberlist.Add(objec);
            }
            // return File(path, "text/plain", "Initial Rule Curve Derivation.spi");
            return Json(newnumberlist,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetInitialRuleResult(List<Numberofeactable> newlistofeac)
        
        {
            TempData["InitialRule"] = newlistofeac;
            TempData.Keep();
            return RedirectToAction("Initial_Rule_Curve_Derivation");
        }
        public ActionResult Evaporation(EvaporationDepth evaporationDepth)
        {
            TempData["EVAPOR"] = evaporationDepth;
            TempData.Keep();
            return RedirectToAction("Initial_Rule_Curve_Derivation");
        }

        public ActionResult InflowData(INFLOWDATA iNFLOWDATA)
        {
            TempData["Inflow"] = iNFLOWDATA;
            TempData.Keep();
            return RedirectToAction("Initial_Rule_Curve_Derivation");
        }


        public ActionResult Conservation_Operation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Conservation_Operation(ConservationOperation conservation_)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(conservation_.Titleof_problem.PadLeft(0)
                    + "\n" + conservation_.numberof.ToString().PadLeft(0)
                    + "\n" + conservation_.staringyear.ToString().PadLeft(9)
                    + conservation_.staringmonth.ToString().PadLeft(9)
                    + conservation_.timestep.ToString().PadLeft(9)
                    + conservation_.numberofperiod.ToString().PadLeft(9)
                    + conservation_.Idofstructure.ToString().PadLeft(9));        
            }
            return File(path, "text/plain", "Conservation Operation.spi");
           
        }
        public ActionResult Conservation_Operation2()
        {
            var list4 = new List<string>() { "No Power Plant", "All Rel Pass Through Plant", "WS Rel Pass Through Plant", "Irr Rel Pass Through Plant", "All Rel Bypass the Plant" };
            ViewBag.list4 = list4;
            return View();
        }

        public void Output_file_Conservation()
        {
            string workingDir = @"C:\nih_resyp\";
            string inputpath = @"D:\Sequent_Peak_Analysis (43).spi";

            string outputpath = @"D:\outFile_Probableflow.spi";

            string filepath = Path.Combine(workingDir, "s7.bat");
            string file = Path.Combine(outputpath, "ouput.spi");

            string mmmFilePath = Path.Combine(workingDir, "mmm.bat");
            // create mmm file
            string[] lines =
        {
            inputpath, outputpath
        };

            System.IO.File.WriteAllLines(mmmFilePath, lines);

            Process p = new Process();
            p.StartInfo.FileName = filepath;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(workingDir);
            p.StartInfo.UseShellExecute = true;

            // Run the process and wait for it to complete
            p.Start();
            p.WaitForExit();


        }
        [HttpPost]
        public ActionResult Conservation_Operation2(ConservationOperation2 operation2)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(operation2.Title_of_problem.PadLeft(0) + "\n"
                    + operation2.Name_of_Reservoir.ToString().PadLeft(0) + "\n"
                   + operation2.Starting_year.ToString().PadLeft(9)
                    + operation2.Starting_Month.ToString().PadLeft(9)
                     + operation2.No_of_months_for_analysis.ToString().PadLeft(9)
                     + operation2.Dead_storage_capacity.ToString().PadLeft(9)
                     + operation2.Deadstoragecapacity.ToString().PadLeft(9)
                    + operation2.Dead_storagecapacity.ToString().PadLeft(5)
                    + operation2.Dead_storagepacity.ToString().PadLeft(9)
                     + operation2.Deadstoragepacity.ToString().PadLeft(9)
                   + operation2.InitialReserVoirStorage.ToString().PadLeft(9)
                     + operation2.Specicyanualyield.ToString().PadLeft(9)
                     + operation2.Converting_Demands_to_CuM.ToString().PadLeft(9)
                     + operation2.Converting_Demand_CuM.ToString().PadLeft(9)
                     + operation2.Converting_Deman_CuM.ToString().PadLeft(9)
                     + operation2.Converting_Demands_uM.ToString().PadLeft(9)
                     + operation2.SpecicyStorage.ToString().PadLeft(9)
                     + operation2.No_of_data_in_EAC_table.ToString().PadLeft(9)
                      + operation2.RequiredReliability.ToString().PadLeft(9)
                     + operation2.Evaaccuracy.ToString().PadLeft(9)

                    );
            }

            return File(path, "text/plain", "Conservation operation2.spi");
        }



        public ActionResult Conservation_Operation3()
        {
            ConservationOperation3 newmodellist = new ConservationOperation3();
            var list5 = new List<string>() { "Yes", "No" };
            ViewBag.list5 = list5;
            return View(newmodellist);
        }

        [HttpPost]
        public ActionResult Conservation_Operation3(ConservationOperation3 operation3)
        {
            var list5 = new List<string>() { "Yes", "No" };
            ViewBag.list5 = list5;
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            List<Specifyeactable> specifytbl = new List<Specifyeactable>();
            Specifyeactable obj;
            ConservationOperation3 newmodellist = new ConservationOperation3();
            for (int points=1;points <= operation3.Numberofpointsineactable;points++)
            {
                obj = new Specifyeactable();
                obj.Point = points;
                obj.Elevation = 0;
                obj.Area = 0;
                obj.Capacity = 0;
                specifytbl.Add(obj);
            }
            newmodellist.specifyeactables = specifytbl;

            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(operation3.Dead_storagecapacity.ToString().PadLeft(0) + "\n"
                    + operation3.Dead_storagepacity.ToString().PadLeft(0) + "\n"
                   + operation3.Deadstoragepacity.ToString().PadLeft(9)
                    + operation3.InitialReserVoirStorage.ToString().PadLeft(9)
                     + operation3.Numberofpointsineactable.ToString().PadLeft(9)
                     + operation3.Converting_Demands_to_CuM.ToString().PadLeft(9)
                     + operation3.Converting_Demand_CuM.ToString().PadLeft(9)
                    + operation3.Converting_Deman_CuM.ToString().PadLeft(5)
                    + operation3.Converting_Demands_uM.ToString().PadLeft(9)
                     + operation3.SpecicyStorage.ToString().PadLeft(9)
                   + operation3.No_of_data_in_EAC_table.ToString().PadLeft(9)
                     + operation3.RequiredReliability.ToString().PadLeft(9)
                     + operation3.Evaaccuracy.ToString().PadLeft(9)
                     + operation3.Evaacracy.ToString().PadLeft(9)
                     );
            }
            //return File(path, "text/plain", "Conservation operation3.spi");
            return View(newmodellist);

        }
        [HttpPost]
        public ActionResult GetConservationOperation(ConservationOperation3 operation3, List<Specifyeactable> specifyeactablesnew)
        {
            
            List<Specifyeactable> specifytbl = new List<Specifyeactable>();
            Specifyeactable obj;
            ConservationOperation3 newmodellist = new ConservationOperation3();
            for (int points = 1; points <= operation3.Numberofpointsineactable; points++)
            {
                obj = new Specifyeactable();
                obj.Point = points;
                obj.Elevation = 0;
                obj.Area = 0;
                obj.Capacity = 0;
                specifytbl.Add(obj);
            }
            return Json(specifytbl, JsonRequestBehavior.AllowGet);
            //return File(path, "text/plain", "Conservation operation3.spi");
        }
    }
}