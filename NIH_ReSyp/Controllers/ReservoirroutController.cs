using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NIH_ReSyp.Models;

namespace NIH_ReSyp.Controllers
{
    public class ReservoirroutController : Controller
    {
       

        public ActionResult Reservoir_Rout_Form()
        {
            
            var list = new List<string>() { "Modify Puls Method" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Reservoir_Rout_Form(Reservoir_rout rout)
        {
            var list = new List<string>() { "Modify Puls Method" };
            ViewBag.list = list;          
            string path = @"E:\MYData\Textfile.txt";

            var enumerable = TempData["name"] as IEnumerable<Ecrctable>;
            var routingdata = TempData["Rout"] as IEnumerable<InflowTable>;

            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(rout.Title_of_problem + "\n"
                    + rout.Name_of_Reservoir + "\n"
                   + rout.Numbersofyears.ToString().PadLeft(9)
                    + rout.Reliability1.ToString().PadLeft(9)
                     + rout.Reliability2.ToString().PadLeft(9)
                     + rout.Reliability3.ToString().PadLeft(9)
                     + rout.Reliability4.ToString().PadLeft(9)
                    + rout.Reliability5.ToString().PadLeft(5)
                    + rout.Reliability6.ToString().PadLeft(9)
                     + rout.Reliability7.ToString().PadLeft(9)
                   + rout.Reliability8.ToString().PadLeft(9)
                     + rout.Reliability9.ToString().PadLeft(9) 
                    );
                foreach (var a in enumerable)
                {
                    int elevation = a.Elevation;
                    int capacity = a.Capacity;
                    int relcapacity = a.RelCapacity;
                    sw.WriteLine
                   (
                        elevation.ToString().PadLeft(5)
                        + capacity.ToString().PadLeft(5)
                        + relcapacity.ToString().PadLeft(3)
                    );
                }
                foreach (var a in routingdata)
                {
                    int inflow = a.Inflow;                  
                    sw.WriteLine
                   (
                        inflow.ToString().PadLeft(4)
                    );
                }
            }

            return File(path, "text/plain", "Reservoir_Rout_Form.spi");

        }
        [HttpPost]
        public JsonResult GetReservoirRout(Reservoir_rout rout)
        {           
            List<Ecrctable> newlistecrc = new List<Ecrctable>();
            Ecrctable obj;
            for (int i = 1; i <= rout.Numbersofyears; i++)
            {
                obj = new Ecrctable();
                obj.Elevation = 0;
                obj.Capacity = 0;
                obj.RelCapacity = 0;
                newlistecrc.Add(obj);
            }

            return Json(newlistecrc, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetEacrTableResult(List<Ecrctable> ecrctables)
        {
            TempData["name"] = ecrctables;
            TempData.Keep();
            return RedirectToAction("Reservoir_Rout_Form");
        }


        public JsonResult GetReservoirRoutInflow(Reservoir_rout rout)
        {
            List<InflowTable> inflowlist = new List<InflowTable>();
            InflowTable objc;
            for (int a = 1; a <= rout.Reliability1; a++)
            {
                objc = new InflowTable();
                objc.Sequence = a;
                objc.Inflow = 0;
                inflowlist.Add(objc);
            }
            return Json(inflowlist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RoutInflow(List<InflowTable> inflowTables)
        {
            TempData["Rout"] = inflowTables;
            TempData.Keep();
            return RedirectToAction("Reservoir_Rout_Form");
        }
    }
}