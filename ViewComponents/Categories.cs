using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly MyDatabaseContext db;

        public Categories(MyDatabaseContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Categories.Select(c => new { c.CategoryId, c.Name, c.Description});

            return View(data);
        }
    }
}
