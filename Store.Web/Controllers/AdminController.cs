using Store.Domain.Abstract;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository mRepository;

        public AdminController(IProductRepository repository)
        {
            mRepository = repository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(mRepository.Products);
        }
        public ActionResult Edit(int id)
        {
            Product product = mRepository.Products.FirstOrDefault(p => p.ID == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                mRepository.SaveProduct(product);
                TempData["message"] = "保存成功";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product product = mRepository.DeleteProduct(id);
            if (product!=null)
            {
                TempData["message"] = "删除成功";
            }
            return RedirectToAction("Index");
        }
    }
}