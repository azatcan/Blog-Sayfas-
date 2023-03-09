using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly DataContext _dataContext;

        public AdminUserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Users.ToList());
        }
        public IActionResult Delete(int id)
        {
            var result = _dataContext.Users.Find(id);
            _dataContext.Users.Remove(result);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AdminUser");
        }
    }
}
