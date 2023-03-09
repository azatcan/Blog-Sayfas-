using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogPage.Controllers
{
    [AllowAnonymous]
    public class ArticleController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(DataContext dataContext, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public IActionResult ArticleDetails(int id)
        {
           
            var details = _dataContext.Articles.Find(id);
            var yorum = _dataContext.Comments.Where(x => x.ArticleId == id).ToList();
            ViewBag.yorum = yorum;

            var bul = User.Identity.Name;

            var kullanıcı = _dataContext.Users.Where(x => x.UserName == bul).Select(y => y.Id).FirstOrDefault();
            var islem = _dataContext.Comments.Where(x=>x.AppUserId == kullanıcı).ToList();
            ViewBag.kullanıcı = islem;
            
            return View(details);
        }
        
        
        [HttpPost]
        public IActionResult Comment(Comments data)
        {         
            if (User.Identity.IsAuthenticated)
            {
                _dataContext.Comments.Add(data);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
