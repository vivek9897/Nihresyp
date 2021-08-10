using NIH_ReSyp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIH_ReSyp.Controllers
{
    public class EACTableController : Controller
    {
       
        public ActionResult Linear_Interpolation_Form()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Linear_Interpolation_Form(EACTableLinear eactbl1)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            var Eactbldata = TempData["EACTBLdata"] as IEnumerable<Eactbldata>; 
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(eactbl1.Title_of_problem + "\n"
                    + eactbl1.Name_of_Reservoir + "\n"
                   + eactbl1.Numbersofyears.ToString().PadLeft(eactbl1.Numbersofyears.ToString().Length + 2)
                    + eactbl1.Reliability1.ToString().PadLeft(eactbl1.Reliability1.ToString().Length + 2)
                     + eactbl1.numberofdatapointsineac.ToString().PadLeft(eactbl1.numberofdatapointsineac.ToString().Length + 2)
                     + eactbl1.Reliability3.ToString().PadLeft(eactbl1.Reliability3.ToString().Length + 2)
                     + eactbl1.Reliability4.ToString().PadLeft(eactbl1.Reliability4.ToString().Length + 2)
                    + eactbl1.Reliability5.ToString().PadLeft(eactbl1.Reliability5.ToString().Length + 2)                   
                    );
                foreach (var a in Eactbldata)
                {
                    int elevation = a.elevation;
                    int area = a.Area;
                    int capacity = a.Capacity;
                    sw.WriteLine
                   (
                        elevation.ToString().PadLeft(elevation.ToString().Length +1)
                        + area.ToString().PadLeft(area.ToString().Length + 13)
                        + capacity.ToString().PadLeft(capacity.ToString().Length + 13) 
                    );
                }
            }
             return File(path, "text/plain", "Linear_Interpolation_Form.spi");
        }

        [HttpPost]
        public JsonResult LinearInterpolationForm(EACTableLinear eactbl1)
        {
           
            List<Eactbldata> newlistdata = new List<Eactbldata>();
            Eactbldata obj;
            for (int i = 1; i <= eactbl1.numberofdatapointsineac; i++)
            {
                obj = new Eactbldata();
                obj.elevation = 0;
                obj.Area = 0;
                obj.Capacity = 0;
                newlistdata.Add(obj);
            }          
            return Json(newlistdata,JsonRequestBehavior.AllowGet);
        }
         
        public ActionResult LinearEacTable(List<Eactbldata> eactbldatas)
        {
            TempData["EACTBLdata"] = eactbldatas;
            return RedirectToAction("Linear_Interpolation_Form");
        }

        public ActionResult Approximate_EAC_Table()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Approximate_EAC_Table(EACTableApprox eactbl2)
        {
            string path = @"E:\BossWebtech\Mydata\Textfile.spi";
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(eactbl2.Title_of_problem + "\n"
                    + eactbl2.Name_of_Reservoir + "\n"
                   + eactbl2.Numbersofyears.ToString().PadLeft(eactbl2.Numbersofyears.ToString().Length + 2)
                    + eactbl2.Reliability1.ToString().PadLeft(eactbl2.Reliability1.ToString().Length+2)
                     + eactbl2.Reliability2.ToString().PadLeft(eactbl2.Reliability2.ToString().Length + 2)
                     + eactbl2.Reliability3.ToString().PadLeft(eactbl2.Reliability3.ToString().Length + 2)
                     + eactbl2.Reliability4.ToString().PadLeft(eactbl2.Reliability4.ToString().Length + 2)
                    + eactbl2.Reliability5.ToString().PadLeft(eactbl2.Reliability5.ToString().Length + 2)

                    );
            }

            return File(path, "text/plain", "Approximate_EAC_Table.spi");
        }
    }
}