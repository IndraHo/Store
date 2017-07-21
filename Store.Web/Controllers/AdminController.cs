using Store.Domain.Abstract;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    [Authorize]
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
        public ActionResult Edit(Product product,HttpPostedFileBase image=null)
        {
            if (ModelState.IsValid)
            {
                if (image!=null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

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