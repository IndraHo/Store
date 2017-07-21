using Store.Domain.Abstract;
using Store.Domain.Entities;
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
        public ActionResult List(string category,int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = mRepository.Products.
                           Where(p => category == null || p.Category == category).
                           OrderBy(p => p.ID).
                           Skip((page - 1) * PageSize).
                           Take(PageSize),
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = category == null ? mRepository.Products.Count() : mRepository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory=category
            };
            return View(model);
        }
        public ActionResult GetImage(int id)
        {
            Product product = mRepository.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            return null;
        }
    }
}