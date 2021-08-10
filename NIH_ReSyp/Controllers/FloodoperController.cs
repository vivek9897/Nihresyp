using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NIH_ReSyp.Models;
using System.Diagnostics;

namespace NIH_ReSyp.Controllers
{
    public class FloodoperController : Controller
    {


        public void Output_file_Flood()
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
        public ActionResult Flood_Operation_Form()
        {    
            return View();
        }
        [HttpPost]
        public ActionResult Flood_Operation_Form(Floodoper fld)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(fld.Titleof_problem + "\n"
                      + fld.numberofstructure + "\n"
                      + fld.staringyear.ToString().PadLeft(9)
                      + fld.staringmnth.ToString().PadLeft(9)
                      + fld.staringmonth.ToString().PadLeft(9)
                      + fld.timestep.ToString().PadLeft(9)
                      + fld.numberofperiod.ToString().PadLeft(9)
                      + fld.Idofstructure.ToString().PadLeft(9)
                      
                      );
            }
            return File(path, "text/plain", "Floodoperation.spi");
        }


        public ActionResult Flood_Operation_Form2()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Flood_Operation_Form2(Floodoper2 fld2)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(fld2.Title_of_problem + "\n"
                    + fld2.Name_of_Reservoir + "\n"
                   + fld2.Starting_year.ToString().PadLeft(9)
                    + fld2.Starting_Month.ToString().PadLeft(9)
                     + fld2.No_of_months_for_analysis.ToString().PadLeft(9)
                     + fld2.Dead_storage_capacity.ToString().PadLeft(9)
                     + fld2.Deadsoragecapacity.ToString().PadLeft(9)
                    + fld2.Deadstoragecapacity.ToString().PadLeft(5)
                    + fld2.Deadstogecapacity.ToString().PadLeft(9)
                     + fld2.Deadstoragecacity.ToString().PadLeft(9)
                   + fld2.Dead_storagecapacity.ToString().PadLeft(9)
                     + fld2.Dead_storagepacity.ToString().PadLeft(9)
                     + fld2.SpecicyStorage.ToString().PadLeft(9)
                     + fld2.No_of_data_in_EAC_table.ToString().PadLeft(9)
                     + fld2.RequiredReliability.ToString().PadLeft(9)
                     + fld2.Evaaccuracy.ToString().PadLeft(9)
                     + fld2.Evaaccury.ToString().PadLeft(9)
                     

                    );
            }

            return File(path, "text/plain", "FloodOperation2.spi");
        }


        public ActionResult Flood_Operation_Form3()
        {
            Floodoper3 newmodellist = new Floodoper3();
            var list = new List<string>() { "Yes", "No" };
            ViewBag.list = list;
            return View(newmodellist);
        }



        [HttpPost]
        public ActionResult Flood_Operation_Form3(Floodoper3 fld3)
        {
            var list = new List<string>() { "Yes", "No" };
            ViewBag.list = list;
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            List<Specifyeacrtable> neweacrtbl = new List<Specifyeacrtable>();
            Specifyeacrtable obj;

            Floodoper3 newmodellist = new Floodoper3();

            for (int i=1;i<= fld3.numberofstructure;i++)
            {
                obj = new Specifyeacrtable();
                obj.Elevation = 0;
                obj.Area = 0;
                obj.Capacity = 0;
                obj.RelCapacity = 0;

                neweacrtbl.Add(obj);
            }
            newmodellist.specifyeacrtables = neweacrtbl;
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(fld3.Titleof_problem + "\n"
                      + fld3.numberofstructure + "\n"
                      + fld3.staringyear.ToString().PadLeft(9)
                      + fld3.staringmnth.ToString().PadLeft(9)
                      + fld3.staringmonth.ToString().PadLeft(9)
                      + fld3.timestep.ToString().PadLeft(9)
                      + fld3.numberofperiod.ToString().PadLeft(9)
                      + fld3.Idofstructure.ToString().PadLeft(9)
                      
                      );
            }
            //return File(path, "text/plain", "FloodOperation3.spi");
            return View(newmodellist);

        }
        [HttpPost]
        public JsonResult GetFloodOperation(Floodoper3 fld3, List<Specifyeacrtable> specifyeacrtablesnew)
        {

            List<Specifyeacrtable> neweacrtbl = new List<Specifyeacrtable>();
            Specifyeacrtable obj;
            for (int i = 1; i <= fld3.numberofstructure; i++)
            {
                obj = new Specifyeacrtable();
                obj.Elevation = 0;
                obj.Area = 0;
                obj.Capacity = 0;
                obj.RelCapacity = 0;

                neweacrtbl.Add(obj);
            }
            return Json(neweacrtbl,JsonRequestBehavior.AllowGet);
        //return File(path, "text/plain", "FloodOperation3.spi");


        }
    }
 
}