using Microsoft.AspNetCore.Mvc;
using DaoManhTung_N05_221231041.Models;
namespace DaoManhTung_N05_221231041.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        QlbanHangQuanAoContext db = new QlbanHangQuanAoContext();
        List<PhanLoai> nav;
        public NavViewComponent()
        {

            nav = db.PhanLoais.ToList();

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", nav);
        }
    }
}
