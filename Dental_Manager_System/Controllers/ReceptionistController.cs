using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers

{
    public class ReceptionistController : Controller
    {
        // GET: LeTan
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult ViewAppointments()
        {
            return View();
        }
    }
}