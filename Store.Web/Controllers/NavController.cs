using Store.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository mRepository;

        public NavController(IProductRepository repository)
        {
            mRepository = repository;
        }
        // GET: Nav
        public ActionResult Menu(string category=null,bool horizontalLayout=false)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = mRepository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView("FlexMenu",categories);
        }
    }
}