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
    public class CartController : Controller
    {
        private IProductRepository mRepository;
        public CartController(IProductRepository repository)
        {
            mRepository = repository;
        }
        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        // GET: Cart
        public ActionResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Product product = mRepository.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                cart.Add(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Product product = mRepository.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                cart.Remove(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ActionResult Checkout()
        {
            return View(new ShoppingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(Cart cart, ShoppingDetails shoppingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "对不起，您的购物篮是空的！");
            }
            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shoppingDetails);
            }
        }
    }
}