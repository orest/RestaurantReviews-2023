using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data.Context;
using RestaurantReviews.Models;
using RestaurantReviews.Web.Models;

namespace RestaurantReviews.Web.Controllers {
    public class RestaurantsController : Controller {
        private readonly RestaurantContext _context;
        private readonly IMapper _mapper;

        public RestaurantsController(RestaurantContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index() {
            var restaurantContext = _context.Restaurants.Include(r => r.Cuisine);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Restaurants == null) {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.Cuisine)
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(m => m.RestaurantId == id);
            if (restaurant == null) {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create() {
            ViewData["CuisineCode"] = new SelectList(_context.Cuisines, "CuisineCode", "DisplayName");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantVm restaurant) {
            if (ModelState.IsValid) {

                Restaurant entity = _mapper.Map<Restaurant>(restaurant);
                _context.Restaurants.Add(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuisineCode"] = new SelectList(_context.Cuisines, "CuisineCode", "CuisineCode", restaurant.CuisineCode);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Restaurants == null) {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null) {
                return NotFound();
            }
            ViewData["CuisineCode"] = new SelectList(_context.Cuisines, "CuisineCode", "CuisineCode", restaurant.CuisineCode);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestaurantId,Name,CuisineCode,Address,City,StateCd,Zip,Phone,Website,Country,PriceRange,ImageUrl")] Restaurant restaurant) {
            if (id != restaurant.RestaurantId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!RestaurantExists(restaurant.RestaurantId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuisineCode"] = new SelectList(_context.Cuisines, "CuisineCode", "CuisineCode", restaurant.CuisineCode);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Restaurants == null) {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.Cuisine)
                .FirstOrDefaultAsync(m => m.RestaurantId == id);
            if (restaurant == null) {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Restaurants == null) {
                return Problem("Entity set 'RestaurantContext.Restaurants'  is null.");
            }
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null) {
                _context.Restaurants.Remove(restaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id) {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }
    }
}
