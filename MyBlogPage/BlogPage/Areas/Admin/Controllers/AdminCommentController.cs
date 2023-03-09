using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminCommentController : Controller
    {
        private readonly DataContext _dataContext;

        public AdminCommentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Comments.ToList());
        }
        public IActionResult Delete(int id)
        {
            var result = _dataContext.Comments.Find(id);
            _dataContext.Comments.Remove(result);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AdminComment");
        }
    }
}
