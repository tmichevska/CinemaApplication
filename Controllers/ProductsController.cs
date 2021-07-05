using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Web.Data;
using CinemaApp.Web.Models;
using System.Security.Claims;

namespace CinemaApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Image,Description,Price,Rating")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        public async Task<IActionResult> AddToShoppingCart(int productId)
        {
            var product = await _context.Products.Where(z => z.ProductId == productId).FirstOrDefaultAsync();
            // select * from Products where ProductId = productId
            var model = new AddToShoppingCartDto();
            model.SelectedProduct = product;
            model.ProductId = product.ProductId;
            model.Quantity = 0;
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> AddToShoppingCart(AddToShoppingCartDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Where(z => z.Id == userId).
            Include(z => z.UserShoppingCart).
            Include("UserShoppingCart.ProductsInShoppingCart").
            Include("UserShoppingCart.ProductsInShoppingCart.Product").
            FirstOrDefaultAsync();

            var userShoppingCart = user.UserShoppingCart;
            if (userShoppingCart != null)
            {
                var product = _context.Products.Find(model.ProductId);
                if (product != null)
                {
                    ProductInShoppingCart itemToAdd = new ProductInShoppingCart {
                        Product = product,
                        ProductId = product.ProductId,
                        ShoppingCart = userShoppingCart,
                        Quantity = model.Quantity
                    };
                     _context.Add(itemToAdd);
                     await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Image,Description,Price,Rating")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
