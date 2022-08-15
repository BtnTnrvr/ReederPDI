using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReederPDI.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;

namespace ReederPDI.Controllers
{

    public class HomeController : Controller
    {
        ////DEVİCE
        //public JsonResult GetDevicesList(string searchTerm)
        //{
        //    var DevicesList = db.TableDevices.ToList();

        //    if(searchTerm != null)
        //    {
        //        DevicesList = db.TableDevices.Where(model => model.Devices.Contains(searchTerm)).ToList();
        //    }

        //    var modifiedData = DevicesList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.Devices
        //    });
        //    return Json(modifiedData, JsonRequestBehavior.AllowGet);
        //}
        ////TOUCH
        //public JsonResult GetTouchList(string search1Term)
        //{
        //    var TouchList = db.TableTocuhProblem.ToList();

        //    if (search1Term != null)
        //    {
        //        TouchList = db.TableTocuhProblem.Where(model => model.TP000.Contains(search1Term)).ToList();
        //    }

        //    var modified1Data = TouchList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.TP000
        //    });
        //    return Json(modified1Data, JsonRequestBehavior.AllowGet);
        //}
        //LCD
        //public JsonResult GetLCDList(string search2Term)
        //{
        //    var LCDList = db.TableLCDProblem.ToList();

        //    if (search2Term != null)
        //    {
        //        LCDList = db.TableLCDProblem.Where(model => model.LP000.Contains(search2Term)).ToList();
        //    }

        //    var modified2Data = LCDList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.LP000
        //    });
        //    return Json(modified2Data, JsonRequestBehavior.AllowGet);
        //}
        //MOTHERBOARD
        //public JsonResult GetMotherBoardList(string search3Term)
        //{
        //    var MotherBoardList = db.TableMotherBoardProblem.ToList();

        //    if (search3Term != null)
        //    {
        //        MotherBoardList = db.TableMotherBoardProblem.Where(model => model.PP000.Contains(search3Term)).ToList();
        //    }

        //    var modified3Data = MotherBoardList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.PP000
        //    });
        //    return Json(modified3Data, JsonRequestBehavior.AllowGet);
        //}
        //CHARGE
        //public JsonResult GetChargeList(string search4Term)
        //{
        //    var ChargeList = db.TableChargeProblem.ToList();

        //    if (search4Term != null)
        //    {
        //        ChargeList = db.TableChargeProblem.Where(model => model.BP000.Contains(search4Term)).ToList();
        //    }

        //    var modified4Data = ChargeList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.BP000
        //    });
        //    return Json(modified4Data, JsonRequestBehavior.AllowGet);
        //}
        ////CAMERA
        //public JsonResult GetCameraList(string search5Term)
        //{
        //    var CameraList = db.TableCameraProblem.ToList();

        //    if (search5Term != null)
        //    {
        //        CameraList = db.TableCameraProblem.Where(model => model.CP000.Contains(search5Term)).ToList();
        //    }

        //    var modified5Data = CameraList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.CP000
        //    });
        //    return Json(modified5Data, JsonRequestBehavior.AllowGet);
        //}
        ////NETWORK
        //public JsonResult GetNetworkList(string search6Term)
        //{
        //    var NetworkList = db.TableNetworkProblem.ToList();

        //    if (search6Term != null)
        //    {
        //        NetworkList = db.TableNetworkProblem.Where(model => model.NP000.Contains(search6Term)).ToList();
        //    }

        //    var modified6Data = NetworkList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.NP000
        //    });
        //    return Json(modified6Data, JsonRequestBehavior.AllowGet);
        //}
        ////SOUND
        //public JsonResult GetSoundList(string search7Term)
        //{
        //    var SoundList = db.TableSoundProblem.ToList();

        //    if (search7Term != null)
        //    {
        //        SoundList = db.TableSoundProblem.Where(model => model.VP000.Contains(search7Term)).ToList();
        //    }

        //    var modified7Data = SoundList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.VP000
        //    });
        //    return Json(modified7Data, JsonRequestBehavior.AllowGet);
        //}
        //FLEX
        //public JsonResult GetFlexList(string search8Term)
        //{
        //    var FlexList = db.TableFlexProblem.ToList();

        //    if (search8Term != null)
        //    {
        //        FlexList = db.TableFlexProblem.Where(model => model.SP000.Contains(search8Term)).ToList();
        //    }

        //    var modified8Data = FlexList.Select(model => new
        //    {
        //        id = model.ID,
        //        text = model.SP000
        //    });
        //    return Json(modified8Data, JsonRequestBehavior.AllowGet);
        //}
        //BOX
        //public JsonResult GetBoxList(string search9Term)
        //{
        //    using (PDIEntities db = new PDIEntities()) {
        //        var BoxList = db.TableBoxProblem.ToList();

        //        if (search9Term != null)
        //        {
        //            BoxList = db.TableBoxProblem.Where(model => model.JP000.Contains(search9Term)).ToList();
        //        }

        //        var modified9Data = BoxList.Select(model => new
        //        {
        //            id = model.ID,
        //            text = model.JP000
        //        });
        //    }
        //    return Json(modified9Data, JsonRequestBehavior.AllowGet);
        //}

        //GET: Home
        public ActionResult Index(int id = 0)
        {
            TablePDI AC = new TablePDI();
            using (PDIEntities db = new PDIEntities())
            {
                if (id != 0)
                {
                    AC = db.TablePDI.Where(model => model.ID == id).FirstOrDefault();
                    // --------------------------------------------------------------
                    AC.SelectedID9Array = AC.Device.Split(',').ToArray(); //Device
                    AC.SelectedIDArray = AC.TP000.Split(',').ToArray(); //Touch
                    AC.SelectedID1Array = AC.LP000.Split(',').ToArray(); //LCD
                    AC.SelectedID2Array = AC.PP000.Split(',').ToArray(); //MotherBoard
                    AC.SelectedID3Array = AC.BP000.Split(',').ToArray(); //Charge
                    AC.SelectedID4Array = AC.CP000.Split(',').ToArray(); //Camera
                    AC.SelectedID5Array = AC.NP000.Split(',').ToArray(); //Network
                    AC.SelectedID6Array = AC.VP000.Split(',').ToArray(); //Sound
                    AC.SelectedID7Array = AC.SP000.Split(',').ToArray(); //Flex
                    AC.SelectedID8Array = AC.JP000.Split(',').ToArray(); //Boxz"
                }
                AC.GetDeviceList = db.TableDevices.ToList(); //Device
                AC.GetTP000List = db.TableTocuhProblem.ToList(); //Touch
                AC.GetLP000List = db.TableLCDProblem.ToList(); //LCD
                AC.GetPP000List = db.TableMotherBoardProblem.ToList(); //MotherBoard
                AC.GetBP000List = db.TableChargeProblem.ToList(); //Charge
                AC.GetCP000List = db.TableCameraProblem.ToList(); //Camera
                AC.GetNP000List = db.TableNetworkProblem.ToList(); //Network
                AC.GetVP000List = db.TableSoundProblem.ToList(); //Sound
                AC.GetSP000List = db.TableFlexProblem.ToList(); //Flex
                AC.GetJP000List = db.TableBoxProblem.ToList(); //Box
            }   
            return View(AC);
        }
        [HttpPost]
        public ActionResult Index(TablePDI AC)
        {
            if(AC.SelectedIDArray != null && AC.SelectedID1Array != null && AC.SelectedID2Array != null && AC.SelectedID3Array != null && AC.SelectedID4Array != null && AC.SelectedID5Array != null && AC.SelectedID6Array != null && AC.SelectedID7Array != null && AC.SelectedID8Array != null && AC.SelectedID9Array != null)
            { 
            //multi select dropdown
            AC.Device = string.Join(",", AC.SelectedID9Array); //Device
            AC.LP000 = string.Join(",", AC.SelectedID1Array); //Touch
            AC.TP000 = string.Join(",", AC.SelectedIDArray); //LCD
            AC.PP000 = string.Join(",", AC.SelectedID2Array); //MotherBoard 
            AC.BP000 = string.Join(",", AC.SelectedID3Array); //Charge
            AC.CP000 = string.Join(",", AC.SelectedID4Array); //Camera
            AC.NP000 = string.Join(",", AC.SelectedID5Array); //Network
            AC.VP000 = string.Join(",", AC.SelectedID6Array); //Sound
            AC.SP000 = string.Join(",", AC.SelectedID7Array); //Flex
            AC.JP000 = string.Join(",", AC.SelectedID8Array); //Box
            }
            else
            {
                return View("Error2");
            }
            using (PDIEntities db = new PDIEntities())
            {
                if(AC.ID == 0 )
                {
                db.TablePDI.Add(AC);
                }
                else
                {
                    db.Entry(AC).State = EntityState.Modified;
                }
                db.SaveChanges();

            }
            return RedirectToAction("Index",new {id = 0});
        }

        public ActionResult About()
        {
            return View("About");
        }

        //Jquery Basic DataTable Without Searchable Columns

        //[HttpGet]
        //public ActionResult GetData()
        //{
        //    PDIEntities entities = new PDIEntities();
        //    var tablepdi = entities.TablePDI.Take(999999999).ToList();
        //    return Json(new { data = tablepdi }, JsonRequestBehavior.AllowGet);
        //}

        //END OF Jquery Basic DataTable Without Searchable Columns

        //Jquery Advanced DataTable With Searchable Columns
        public ActionResult GetPDI()
        {
            List<TablePDI_UPDATED> tpdiList = new List<TablePDI_UPDATED>();
           using (PDIEntities db = new PDIEntities())
            {
                tpdiList = db.TablePDI_UPDATED.ToList<TablePDI_UPDATED>();
                return Json(new { data = tpdiList }, JsonRequestBehavior.AllowGet);
            }
        }
        //END OF Jquery Advanced DataTable With Searchable Columns

        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult Welcome()
        {
            return View("Welcome");
        }
    }
}