using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;

        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Details(int id)
        {
            var result = _dataContext.Articles.Where(x=>x.CategoryId ==id).ToList();
            
            return View(result);
        }
    }
}
