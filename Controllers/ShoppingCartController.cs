using CinemaApp.Web.Data;
using CinemaApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;
        

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId).
            Include(z => z.UserShoppingCart).
            Include("UserShoppingCart.ProductsInShoppingCart").
            Include("UserShoppingCart.ProductsInShoppingCart.Product").
            FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;

            var productList = userShoppingCart.ProductsInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                ProductPrice = z.Product.Price
            }).ToList() ;
            float totalPrice = 0;
            foreach(var item in productList)
            {
                totalPrice += item.Quantity*item.ProductPrice;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TotalPrice = totalPrice,
                ProducstInShoppingCart = userShoppingCart.ProductsInShoppingCart.ToList()
            };

            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId).
            Include(z => z.UserShoppingCart).
            Include("UserShoppingCart.ProductsInShoppingCart").
            Include("UserShoppingCart.ProductsInShoppingCart.Product").
            FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;
            var forRemoval = userShoppingCart.ProductsInShoppingCart.Where(z => z.ProductId == id).FirstOrDefault();
            userShoppingCart.ProductsInShoppingCart.Remove(forRemoval);
            _context.Update(userShoppingCart);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId).
            Include(z => z.UserShoppingCart).
            Include("UserShoppingCart.ProductsInShoppingCart").
            Include("UserShoppingCart.ProductsInShoppingCart.Product").
            FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;
            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };
            _context.Add(newOrder);
            _context.SaveChanges();

            List<ProductInOrder> productInOrder = (List<ProductInOrder>)userShoppingCart.ProductsInShoppingCart.
            Select(z => new ProductInOrder
                {
                    Product = z.Product,
                    ProductId = z.ProductId,
                    Order = newOrder,
                    OrderId = newOrder.OrderId
                }).ToList();


            foreach(var item in productInOrder)
            {
                _context.Add(item);
               

            }
            user.UserShoppingCart.ProductsInShoppingCart.Clear();
            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
