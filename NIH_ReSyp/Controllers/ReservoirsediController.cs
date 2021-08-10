using NIH_ReSyp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIH_ReSyp.Controllers
{
    public class ReservoirsediController : Controller
    {
       
        // GET: Reservoirsedi
        public ActionResult New_Zero_Elevetion()
        {
          
            var list = new List<string>() {"Plain","Foot Hill","Hill","Gorge"};
            ViewBag.list = list;
            return View();
        }


        [HttpPost]
        public ActionResult New_Zero_Elevetion(Reservoirsedi1 reservoirsedi1)
        {

            var list = new List<string>() { "Plain", "Foot Hill", "Hill", "Gorge" };
            ViewBag.list = list;
            string path = @"E:\MYData\Textfile.txt";

            var Eactbldatanew = TempData["EACTBL"] as IEnumerable<NewzeroEacTbl>;

            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(reservoirsedi1.Title_of_problem + "\n"
                 + reservoirsedi1.Name_of_Reservoir + "\n"
                   + reservoirsedi1.Numbersoflevelsineacctbl.ToString().PadLeft(9)
                    + reservoirsedi1.Reliability1.ToString().PadLeft(9)
                     + reservoirsedi1.Reliability2.ToString().PadLeft(9)
                     + reservoirsedi1.Reliability3.ToString().PadLeft(9)
                     + reservoirsedi1.Reliability4.ToString().PadLeft(9)
                    + reservoirsedi1.Reliability5.ToString().PadLeft(5)
                    + reservoirsedi1.Reliability6.ToString().PadLeft(9)
                     + reservoirsedi1.Reliability7.ToString().PadLeft(9)                
                    );

                foreach (var a in Eactbldatanew)
                {
                    int elevation = a.Elevation;
                    int area = a.Area;
                    int capacity = a.Capacity;
                    sw.WriteLine
                   (
                        elevation.ToString().PadLeft(5)
                        + area.ToString().PadLeft(5)
                        + capacity.ToString().PadLeft(3) + "\n"

                    );
                }
            }

            return File(path, "text/plain", "NewZeroElevetion.spi");
        }

        [HttpPost]
        public JsonResult GETZeroElevetion(Reservoirsedi1 reservoirsedi1)
        {

            List<NewzeroEacTbl> newlisteac = new List<NewzeroEacTbl>();
            NewzeroEacTbl obj;
            for (int i = 1; i <= reservoirsedi1.Numbersoflevelsineacctbl; i++)
            {
                obj = new NewzeroEacTbl();
                obj.Elevation = 0;
                obj.Area = 0;
                obj.Capacity = 0;
                newlisteac.Add(obj);
            }
            return Json(newlisteac, JsonRequestBehavior.AllowGet);         
        }

        [HttpPost]
        public ActionResult EacTablenew(List<NewzeroEacTbl> newlisteactbl)
        {
            TempData["EACTBL"] = newlisteactbl;
            return RedirectToAction("New_Zero_Elevetion");
        }

        public ActionResult Sediment_Profile()
        {
            var list2 = new List<string>() { "Plain", "Foot Hill", "Hill", "Gorge" };
            ViewBag.list2 = list2;
            return View();
        }


        [HttpPost]
        public ActionResult Sediment_Profile(Reservoirsedi2 reservoirsedi2)
        {
            var list2 = new List<string>() { "Plain", "Foot Hill", "Hill", "Gorge" };
            ViewBag.list2 = list2;

            string path = @"E:\MYData\Textfile.txt";

            var Eactbldataprofile = TempData["EACTBLprofile"] as IEnumerable<SedimentprofileEacTbl>;

            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(reservoirsedi2.Title_of_problem + ""
                    + reservoirsedi2.Name_of_Reservoir + ""
                   + reservoirsedi2.NumbersofLevelsineac.ToString().PadLeft(9)
                    + reservoirsedi2.Reliability1.ToString().PadLeft(9)
                     + reservoirsedi2.Reliability2.ToString().PadLeft(9)
                     + reservoirsedi2.Reliability3.ToString().PadLeft(9)
                     + reservoirsedi2.Reliability4.ToString().PadLeft(9)
                    + reservoirsedi2.Reliability5.ToString().PadLeft(5)
                    + reservoirsedi2.Reliability6.ToString().PadLeft(9)
                     + reservoirsedi2.Reliability7.ToString().PadLeft(9)
                     + reservoirsedi2.newzero.ToString().PadLeft(9)
                    );
                foreach (var a in Eactbldataprofile)
                {
                    int elevation = a.Elevation;
                    int area = a.Area;
                    int capacity = a.Capacity;
                    sw.WriteLine
                   (
                        elevation.ToString().PadLeft(5)
                        + area.ToString().PadLeft(5)
                        + capacity.ToString().PadLeft(3) + "\n"

                    );
                }
            }
           return File(path, "text/plain", "SedimentProfile.spi");
        }

        [HttpPost]
        public JsonResult SedimentProfileFun(Reservoirsedi2 reservoirsedi2)
        {

            List<SedimentprofileEacTbl> newlist = new List<SedimentprofileEacTbl>();
            SedimentprofileEacTbl obje;
            for (int a = 1; a <= reservoirsedi2.NumbersofLevelsineac; a++)
            {
                obje = new SedimentprofileEacTbl();
                obje.Elevation = 0;
                obje.Area = 0;
                obje.Capacity = 0;
                newlist.Add(obje);
            }
            return Json(newlist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EacTableprofile(List<SedimentprofileEacTbl> sedimentprofileEacTbls)
        {
            TempData["EACTBLprofile"] = sedimentprofileEacTbls;
            return RedirectToAction("Sediment_Profile");
        }
    }
}
