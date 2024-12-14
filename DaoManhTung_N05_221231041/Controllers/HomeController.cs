using System.Diagnostics;
using DaoManhTung_N05_221231041.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DaoManhTung_N05_221231041.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlbanHangQuanAoContext db = new QlbanHangQuanAoContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var a = db.SanPhams.ToList();
            return View(a);
        }
        public JsonResult GetData(string MaSanPham)
        {
            var b = (from P in db.PhanLoais
                     join C in db.SanPhams
                     on P.MaPhanLoai equals C.MaPhanLoai
                     where P.MaPhanLoai == MaSanPham
                     select C
                        ).ToList();

            return Json(b);

        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(string? id)
        {

            var trongTai = db.SanPhams.Where(x => x.MaSanPham == id).SingleOrDefault();


            return View(trongTai);

        }

        [Route("Edit")]
        public IActionResult Edit(string? id)
        {

            var trongTai = db.SanPhams.Where(x => x.MaSanPham == id).SingleOrDefault();
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais.ToList(), "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus.ToList(), "MaPhanLoaiPhu", "TenPhanLoaiPhu");

            return View(trongTai);

        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(SanPham trongtai)
        {
            if (ModelState.IsValid)
            {
                db.Update(trongtai);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
