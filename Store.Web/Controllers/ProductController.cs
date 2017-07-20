using Store.Domain.Abstract;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository mRepository;

        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            mRepository = repository;
        }
        // GET: Product
        public ActionResult List(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = mRepository.Products.
                             OrderBy(p => p.ID).
                              Skip((page - 1) * PageSize).
                              Take(PageSize),
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = mRepository.Products.Count()
                }
            };
            return View(model);
        }
    }
}