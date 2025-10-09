using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers
{
    public class AdminController : Controller
    {
        // GET: ADMIN
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachBacSi()
        {
            return View();
        }
        public ActionResult LichLamViecBacSi()
        {
            return View();
        }
        public ActionResult DanhSachNhanVien()
        {
            return View();
        }
        public ActionResult DanhSachKhachHang()
        {
            return View();
        }
        public ActionResult QuanLyDichVu()
        {
            return View();
        }
        public ActionResult QuanLyThuoc()
        {
            return View();
        }
    }
}