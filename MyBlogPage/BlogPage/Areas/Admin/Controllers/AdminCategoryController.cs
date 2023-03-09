using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogPage.Areas.Admin.Controllers
{   
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCategoryController : Controller
        {
            DataContext _dataContext;

            public AdminCategoryController(DataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public IActionResult Index()
            {
                return View(_dataContext.Categories.ToList());
            }

            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(string Name, string Description)
            {
                var category = new Category()
                {
                    Name = Name,
                    Description = Description
                };
                _dataContext.Categories.Add(category);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "AdminCategory");
            }
            public IActionResult Delete(int id)
            {
                var result = _dataContext.Categories.Find(id);
                _dataContext.Remove(result);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "AdminCategory");
            }
            public IActionResult Update(int id)
            {
                var update = _dataContext.Categories.Find(id);
                return View(update);
            }

            [ValidateAntiForgeryToken]
            [HttpPost]
            public IActionResult Update(Category category)
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Bir Hata oluştu");
                }
                _dataContext.Update(category);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "AdminCategory");

            }

        }
    
}
