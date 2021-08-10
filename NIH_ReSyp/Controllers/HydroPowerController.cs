using NIH_ReSyp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIH_ReSyp.Controllers
{
    public class HydroPowerController : Controller
    {


        public void Output_file_Hydro()
        {
            string workingDir = @"C:\nih_resyp\";
            string inputpath = @"D:\Sequent_Peak_Analysis (43).spi";

            string outputpath = @"D:\outFile.spi";

            string filepath = Path.Combine(workingDir, "s6.bat");
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
        // GET: HydroPower
        public ActionResult Hydro_Power_Form()
        {          
            var list = new List<string>() { "Firm Power To Be Computed", "Operation To Be Simulated" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Hydro_Power_Form(hydropower hydro)
        {
            var list = new List<string>() { "Firm Power To Be Computed", "Operation To Be Simulated" };
            ViewBag.list = list;

            var Eactbldata = TempData["EACTBL"] as IEnumerable<EACtable>;
            var Evaporationdpths = TempData["EVAPOR"] as Evaporationdepths;
            var inflowdatas = TempData["Inflows"] as IEnumerable<MonthInflow>;

            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                  sw.WriteLine(hydro.Title_of_problem + "\n"
                    + hydro.Name_of_Reservoir + "\n"
                   + hydro.Startingyear.ToString().PadLeft(hydro.Startingyear.ToString().Length + 1)
                    + hydro.startingmonth.ToString().PadLeft(hydro.startingmonth.ToString().Length + 10)
                     + hydro.numberofmonthsforanalysis.ToString().PadLeft(hydro.numberofmonthsforanalysis.ToString().Length + 13)
                     + hydro.Reliability3.ToString().PadLeft(hydro.Reliability3.ToString().Length + 13)
                     + hydro.Reliability4.ToString().PadLeft(hydro.Reliability4.ToString().Length + 11) +'\n'
                    + hydro.Reliability5.ToString().PadLeft(hydro.Reliability5.ToString().Length + 1) + '\n'
                    + hydro.Reliability6.ToString()
                     + hydro.Reliability7.ToString().PadLeft(hydro.Reliability7.ToString().Length + 2)
                   + hydro.Reliability8.ToString().PadLeft(hydro.Reliability8.ToString().Length + 2)
                     + hydro.Reliability9.ToString().PadLeft(hydro.Reliability9.ToString().Length + 2)
                     + hydro.Reliabilit.ToString().PadLeft(hydro.Reliabilit.ToString().Length + 2)
                     + hydro.numberofdatapoints.ToString().PadLeft(hydro.numberofdatapoints.ToString().Length + 2)
                     + hydro.Reliaba.ToString().PadLeft(hydro.Reliaba.ToString().Length + 2) + '\n'
                     + hydro.Reliabw.ToString().PadLeft(hydro.Reliabw.ToString().Length + 1)
                     + hydro.Reliabq.ToString().PadLeft(hydro.Reliabq.ToString().Length + 12)
                     + hydro.Reliabc.ToString().PadLeft(hydro.Reliabc.ToString().Length + 13)
                      + hydro.Reliabd.ToString().PadLeft(hydro.Reliabd.ToString().Length + 13)+"\n"
                    );
                foreach (var a in Eactbldata)
                {
                    int elevation = a.elevation;
                    int area = a.area;
                    int capacity = a.capacity;
                    sw.WriteLine
                   (
                        elevation.ToString().PadLeft(2)
                        + area.ToString().PadLeft(13)
                        + capacity.ToString().PadLeft(13)+"\n"
                       
                    );
                }
                sw.WriteLine
                 (
                         Evaporationdpths.January.ToString().PadLeft(2)
                         + Evaporationdpths.February.ToString().PadLeft(14)
                         + Evaporationdpths.March.ToString().PadLeft(14)
                         + Evaporationdpths.April.ToString().PadLeft(14)
                         + Evaporationdpths.May.ToString().PadLeft(14)
                         + Evaporationdpths.June.ToString().PadLeft(14)
                         + Evaporationdpths.July.ToString().PadLeft(14)
                         + Evaporationdpths.August.ToString().PadLeft(14)
                         + Evaporationdpths.September.ToString().PadLeft(14)
                         + Evaporationdpths.October.ToString().PadLeft(14)
                         + Evaporationdpths.November.ToString().PadLeft(14)
                         + Evaporationdpths.December.ToString().PadLeft(14)
                  );

                foreach (var a in inflowdatas)
                {
                    int inflows = a.inflow;
                   
                    sw.WriteLine
                   (
                        inflows.ToString().PadLeft(inflows.ToString().Length + 1)
                    );
                }
            }
             return File(path, "text/plain", "Hydro_Power_Form.spi");
        }

        [HttpPost]
        public JsonResult HydroPowerForm(hydropower hydro)
        {
            List<EACtable> newlisteac = new List<EACtable>();
            EACtable obj;
            for (int a = 1; a <= hydro.numberofdatapoints; a++)
            {
                obj = new EACtable();
                obj.elevation = 0;
                obj.area = 0;
                obj.capacity = 0;
                newlisteac.Add(obj);
            }
            // return File(path, "text/plain", "Hydro_Power_Form.spi");
            return Json(newlisteac, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EacTable(List<EACtable> eACtablesnew)
        {
            TempData["EACTBL"] = eACtablesnew;
            return RedirectToAction("Hydro_Power_Form");
        }

        [HttpPost]
        public ActionResult Evaporation(Evaporationdepths evaporationdepths)
        {
            TempData["EVAPOR"] = evaporationdepths;            
            return RedirectToAction("Hydro_Power_Form");
        }



        [HttpPost]
        public ActionResult GETInflowFunc(hydropower hydro)
        {
           
            List<MonthInflow> newmonthinflow = new List<MonthInflow>();
            MonthInflow objec;
            string finalname = "";
            int lastmonth = hydro.startingmonth + hydro.numberofmonthsforanalysis;
            int no_of_years = lastmonth / 12;
            int counter = 0;
            for (int i = hydro.startingmonth; i <= lastmonth - 1; i++)
            {
                objec = new MonthInflow();

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

                DateTime date = new DateTime(hydro.Startingyear + counter, newmonth, 1);

                string month_name = date.ToString("MMM");


                finalname = ((hydro.Startingyear + counter)).ToString() + "-" + month_name;

                if (month_name == "Dec")
                {
                    counter = counter + 1;
                }

                objec.monthyear = finalname;
                objec.inflow = 0;
                newmonthinflow.Add(objec);
            }
            return Json(newmonthinflow, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Inflowreturnfun(List<MonthInflow> monthInflows)
        {
            TempData["Inflows"] = monthInflows;
            TempData.Keep();
            return RedirectToAction("Hydro_Power_Form");
        }
    }
}