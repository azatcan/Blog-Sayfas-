using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.ViewComponents.Default
{
    public class CategoryPartial:ViewComponent
    {
        private readonly DataContext _dataContext;

        public CategoryPartial(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _dataContext.Categories.ToList();
            return View(values);
        }
    }
}
