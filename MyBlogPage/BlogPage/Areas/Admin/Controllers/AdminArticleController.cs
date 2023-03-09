using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogPage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminArticleController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHost;
        public AdminArticleController(DataContext dataContext, IWebHostEnvironment webHost)
        {
            _dataContext = dataContext;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View(_dataContext.Articles.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Dosya,CreateDate,IsActive,CategoryId")] Article article)
        {
            if (!ModelState.IsValid)
            {
                var dosyaYolu = Path.Combine(_webHost.WebRootPath, "İmage");
                if (!Directory.Exists(dosyaYolu))
                {
                    Directory.CreateDirectory(dosyaYolu);
                }
                var tamDosyaAdi = Path.Combine(dosyaYolu, article.Dosya.FileName);
                using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
                {
                    await article.Dosya.CopyToAsync(dosyaAkisi);
                }

                article.ImagePath = article.Dosya.FileName;

                _dataContext.Articles.Add(article);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index", "AdminArticle");
            }
            return View(article);
        }

        public IActionResult Delete(int id)
        {
            var delete = _dataContext.Articles.Find(id);
            _dataContext.Articles.Remove(delete);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AdminArticle");
        }

        public IActionResult Update(int id)
        {
            var update = _dataContext.Articles.Find(id);
            return View(update);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Update(Article article)
        {
            var dosyaYolu = Path.Combine(_webHost.WebRootPath, "İmage");
            var tamDosyaAdi = Path.Combine(dosyaYolu, article.Dosya.FileName);
            using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
            {
                article.Dosya.CopyTo(dosyaAkisi);
            }

            article.ImagePath = article.Dosya.FileName;
            _dataContext.Articles.Update(article);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AdminArticle");
        }
    }
}
