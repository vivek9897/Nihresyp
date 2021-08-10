using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using NIH_ReSyp.Models;
using System.Diagnostics;





namespace NIH_ReSyp.Controllers
{
    public class CapCompController : Controller
    {




        public void Output_file()
        {
            string workingDir = @"C:\nih_resyp\";
            string inputpath = @"D:\Sequent_Peak_Analysis (43).spi";

            string outputpath = @"D:\outFile.spi";

            string filepath = Path.Combine(workingDir, "s2.bat");
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
            //Process proc = null;
            //try
            //{


            //    proc.StartInfo.WorkingDirectory = workingDir;
            //    proc.StartInfo.FileName = "s1.bat";
            //    proc.StartInfo.Arguments = mmmFilePath;  
            //    proc.StartInfo.CreateNoWindow = false;
            //    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  
            //    proc.Start();
            //    string output = proc.StandardOutput.ReadToEnd();
            //    Console.WriteLine(output);

            //    proc.WaitForExit();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            //}


            //Second method

            //Process compiler = new Process();
            //compiler.StartInfo.FileName = filepath;
            //compiler.StartInfo.Arguments = mmmFilePath;
            //compiler.StartInfo.UseShellExecute = false;
            //compiler.StartInfo.RedirectStandardOutput = true;
            //compiler.Start();

            //Console.WriteLine(compiler.StandardOutput.ReadToEnd());

            //compiler.WaitForExit();


            //first method
            //Create the ProcessInfo Object

            //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filepath);

            //psi.UseShellExecute = false;



            ////Start the Process
            //System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);

            //Read the sOut to a string
            //string results = proc.StandardOutput.ReadToEnd().Trim();
            //string error = proc.StandardError.ReadToEnd().Trim();

            //Write out The results;
            //string fmtStdOut = "<font face = courier size = o>{o}</font>";
            //Console.WriteLine(results);
            //this.Response.Write(String.Format(fmtStdOut, error.Replace(System.Environment.NewLine, "<br>")));
            
        }

        
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Sequent_Peak_Analysis()
        {
           
            var lis = new List<string>() { "Y", "N" };
            ViewBag.lis = lis;
            return View();
        }




        [HttpPost]
        public ActionResult Sequent_Peak_Analysis(capcompform1 capform)
        {
            var lis = new List<string>() { "Y", "N" };
            ViewBag.lis = lis;
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
               

            {
                var enumerable = TempData["name"] as IEnumerable<Inflowdemand>;
                
                sw.WriteLine(capform.Title_of_problem.PadLeft(capform.Title_of_problem.Length + 1) + "\n"
                  + capform.Name_of_Reservoir.PadLeft(capform.Name_of_Reservoir.Length + 1) + "\n"
                  + capform.Starting_year.ToString().PadLeft(capform.Starting_year.ToString().Length + 1)
                  + capform.Starting_Month.ToString().PadLeft(capform.Starting_Month.ToString().Length + 10)
                  + capform.No_of_month_for_analysis.ToString().PadLeft(capform.No_of_month_for_analysis.ToString().Length + 13)
                  + capform.Converting_Inflows_to_CuM.ToString().PadLeft(capform.Converting_Inflows_to_CuM.ToString().Length + 13)
                  + capform.Converting_Demands_to_CuM.ToString().PadLeft(capform.Converting_Demands_to_CuM.ToString().Length +10)
                   + capform.Demand_each_year.PadLeft(10) 
                   
                );
                var inflow = "";
                foreach (var a in enumerable)
                {

                    inflow +=

                      a.Inflow.ToString().PadLeft(10);
                  


                };
                sw.WriteLine(inflow);

                var demands = "";
                foreach (var b in enumerable)
                {

                    demands +=

                     b.Demand.ToString().PadLeft(10);

                }
                sw.WriteLine(demands);
            }
                //newmodelList.monthNamelist = monthLists;
                //return View();
            return File(path, "text/plain", "Sequent_Peak_Analysis.spi");

        }

      
       

      






        [HttpPost]
        public JsonResult SubmitInflowValue(capcompform1 capform)
        {
            
            List<Inflowdemand> monthLists = new List<Inflowdemand>();
            Inflowdemand obj;
            List<string> monthnames = new List<string>();
            string finalname = "";
            int lastmonth = capform.Starting_Month + capform.No_of_month_for_analysis;
            int no_of_years = lastmonth % 12;
            int counter = 0;
                for (int i = capform.Starting_Month; i <= lastmonth - 1; i++)
                {
                    obj = new Inflowdemand();

                    int monthno = i;
                    int newmonth = 0;
                    if (monthno > 12)
                    {
                        newmonth = monthno % 12;
                        if (newmonth == 0)
                        {
                            newmonth = 12;
                        }
                    }
                    else
                    {
                        newmonth = i;
                    }

                    DateTime date = new DateTime(capform.Starting_year + counter, newmonth, 1);

                    string month_name = date.ToString("MMM");


                    finalname = ((capform.Starting_year + counter)).ToString() + "-" + month_name;

                    if (month_name == "Dec")
                    {
                        counter = counter + 1;
                    }

                    obj.monthyear = finalname;
                    obj.Inflow = 0;
                    obj.Demand = 0;
                    monthLists.Add(obj);
                
            }
            capform.monthNamelist = monthLists;
            return Json(monthLists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult returnvalues(List<Inflowdemand> inflowdemand)
        {
            if (inflowdemand != null)
            {
                TempData["name"] = inflowdemand;
                TempData.Keep();
            }
            return RedirectToAction("Sequent_Peak_Analysis");
        }



        public ActionResult Storage_Yield_Analysis()
        {
            capcompform2 newmodellist = new capcompform2();
            var list = new List<string>() { "Y", "N" };
            ViewBag.list = list;
            return View(newmodellist);
        }


        [HttpPost]
        public ActionResult Storage_Yield_Analysis(capcompform2 capform2)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi"; 
            var list = new List<string>() { "Y", "N" };
            ViewBag.list = list;
            
            var enumerable = TempData["name"] as IEnumerable<Eactable>;
            var inflowdemands = TempData["INFLOW"] as IEnumerable<Inflowdemand2>;
            var monthlyyield = TempData["MONTHLYIELD"] as MonthlyYieldFactor;
            var Evaporationdepths = TempData["EVAPOR"] as EvaporationDepths;

            using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                
                    sw.WriteLine(capform2.Title_of_problem.PadLeft(0) + "\n"
                        + capform2.Name_of_Reservoir.PadLeft(0) + "\n"
                         + capform2.No_of_months_for_analysis.ToString().PadLeft(4)
                          + capform2.Starting_Month.ToString().PadLeft(9)
                       + capform2.Starting_year.ToString().PadLeft(17)
                         + capform2.Dead_storage_capacity.ToString().PadLeft(17)
                         + capform2.RequiredReliability.ToString().PadLeft(10)
                           + capform2.Converting_Inflows_to_CuM.ToString().PadLeft(14)
                         + capform2.ConvertingInflowsto_CuM.ToString().PadLeft(12)
                         + capform2.ConvertingInflowstoCuM.ToString().PadLeft(14)
                          + capform2.areaconverttothem.ToString().PadLeft(16)
                        + capform2.Converting_capacity_to_CuM.ToString().PadLeft(4)
                        + capform2.Converting_Demands_to_CuM.PadLeft(11) + "\n"
                         + capform2.Specicyanualyieldeded.ToString().PadLeft(11)
                         + capform2.SpecicyStorage.ToString().PadLeft(9)
                       + capform2.No_of_data_in_EAC_table.ToString().PadLeft(9)
                         + capform2.InitialReserVoirStorage.ToString().PadLeft(9)
                         + capform2.Evaaccuracy.ToString().PadLeft(9)
                         + capform2.Eoverallaccuracy.ToString().PadLeft(9) + "\n"
                         + monthlyyield.January.ToString().PadLeft(2)
                         + monthlyyield.February.ToString().PadLeft(14)
                         + monthlyyield.March.ToString().PadLeft(14)
                         + monthlyyield.April.ToString().PadLeft(14)
                         + monthlyyield.May.ToString().PadLeft(14)
                         + monthlyyield.June.ToString().PadLeft(14)
                         + monthlyyield.July.ToString().PadLeft(14)
                         + monthlyyield.August.ToString().PadLeft(14)
                         + monthlyyield.September.ToString().PadLeft(14)
                         + monthlyyield.October.ToString().PadLeft(14)
                         + monthlyyield.November.ToString().PadLeft(14)
                         + monthlyyield.December.ToString().PadLeft(14)
                        );
              
                    foreach (var a in enumerable)
                    {
                    
                        int b = a.area;
                        int c = a.capacity;
                        int d = a.elevation;


                        sw.WriteLine
                       (
                            b.ToString().PadLeft(5)
                            + c.ToString().PadLeft(5)
                            + d.ToString().PadLeft(3)+"\n"
                         + Evaporationdepths.January.ToString().PadLeft(2)
                         + Evaporationdepths.February.ToString().PadLeft(14)
                         + Evaporationdepths.March.ToString().PadLeft(14)
                         + Evaporationdepths.April.ToString().PadLeft(14)
                         + Evaporationdepths.May.ToString().PadLeft(14)
                         + Evaporationdepths.June.ToString().PadLeft(14)
                         + Evaporationdepths.July.ToString().PadLeft(14)
                         + Evaporationdepths.August.ToString().PadLeft(14)
                         + Evaporationdepths.September.ToString().PadLeft(14)
                         + Evaporationdepths.October.ToString().PadLeft(14)
                         + Evaporationdepths.November.ToString().PadLeft(14)
                         + Evaporationdepths.December.ToString().PadLeft(14)
                       );
                    }
                    
                foreach (var data in inflowdemands)
                {
                   
                        int inflow = data.Inflow;
                        sw.WriteLine
                       (
                             inflow.ToString().PadLeft(5)
                       );
                    
                }
            }
            return File(path, "text/plain", "Storage Yield Analysis.spi");
        }


        public void Output_file_Storage()
        {
            string workingDir = @"C:\nih_resyp\";
            string inputpath = @"D:\Sequent_Peak_Analysis (43).spi";

            string outputpath = @"D:\outFile.spi";

            string filepath = Path.Combine(workingDir, "s2.bat");
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
        public JsonResult GetEacTable(capcompform2 capform2)
        {
          
            List<Eactable> eactables = new List<Eactable>();
            Eactable obj;
            for (int a = 1; a <= capform2.No_of_data_in_EAC_table; a++)
            {
                obj = new Eactable();
                obj.area = 0;
                obj.capacity = 0;
                obj.elevation = 0;
                eactables.Add(obj);
            }           
            return Json(eactables, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetEacTableResult(List<Eactable> eactablesnew)
        {
            TempData["name"] = eactablesnew;
            TempData.Keep();
            return RedirectToAction("Storage_Yield_Analysis");
        }


        [HttpPost]
        public JsonResult GetINflow(capcompform2 capform2)
        {

            List<Inflowdemand2> monthlists = new List<Inflowdemand2>();
            Inflowdemand2 obje;
            string finalname = "";
            int lastmonth = capform2.Starting_Month + capform2.No_of_months_for_analysis;
            int no_of_years = lastmonth / 12;
            int counter = 0;
            for (int i = capform2.Starting_Month; i <= lastmonth - 1; i++)
            {
                obje = new Inflowdemand2();

                int monthno = i;
                int newmonth = 0;
                if (monthno > 12)
                {
                    newmonth = monthno % 12;
                    if (newmonth == 0)
                    {
                        newmonth = 12;
                    }
                }
                else
                {
                    newmonth = i;
                }
                DateTime date = new DateTime(capform2.Starting_year + counter, newmonth, 1);
                string month_name = date.ToString("MMM");
                finalname = ((capform2.Starting_year + counter)).ToString() + "-" + month_name;
                if (month_name == "Dec")
                {
                    counter = counter + 1;
                }
                obje.monthyear = finalname;
                obje.Inflow = 0;
                monthlists.Add(obje);
            }
            return Json(monthlists, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetInflowResult(List<Inflowdemand2> inflowdemandsnew)
        {
            TempData["INFLOW"] = inflowdemandsnew;
            TempData.Keep();
            return RedirectToAction("Storage_Yield_Analysis");
        }

        public ActionResult MonthlyYield(MonthlyYieldFactor monthlyYieldFactor)
        {
            TempData["MONTHLYIELD"] = monthlyYieldFactor;
            TempData.Keep();
            return RedirectToAction("Storage_Yield_Analysis");
        }

        public ActionResult Evaporation(EvaporationDepths evaporationDepths)
        {
            TempData["EVAPOR"] = evaporationDepths;
            TempData.Keep();
            return RedirectToAction("Storage_Yield_Analysis");
        }
    }
}