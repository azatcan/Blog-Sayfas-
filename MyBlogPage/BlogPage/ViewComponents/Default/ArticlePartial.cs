using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.ViewComponents.Default
{
    public class ArticlePartial:ViewComponent
    {
        private readonly DataContext _dataContext;

        public ArticlePartial(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _dataContext.Articles.ToList();
            return View(values);
        }
    }
}
