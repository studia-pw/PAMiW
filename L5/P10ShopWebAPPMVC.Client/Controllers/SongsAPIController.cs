using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;


namespace P09ShopWebAPPMVC.Client.Controllers
{
    public class SongsAPIController : Controller
    {

        private readonly ISongService _songService;

        public SongsAPIController(ISongService songService)
        {
            _songService = songService;
          
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _songService.GetSongsAsync();
            return products != null ?
                          View(products.Data.AsEnumerable()) :
                          Problem("Entity set 'ShopContext.Songs'  is null.");

            //return products != null ? 
            //              View("~/Views/Products/Index.cshtml", products.Data.AsEnumerable()) :
            //              Problem("Entity set 'ShopContext.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
         
            if (id == null)
            {
                return NotFound();
            }
            var product = await _songService.GetSongByIdAsync((int)id);
            
            if (product.Data == null)
            {
                return NotFound();
            }

            return View(product.Data);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Duration,AlbumTitle,Artist,ReleaseDate")] Song song)
        {
             
            if (ModelState.IsValid)
            {
                await _songService.CreateSongAsync(song);
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var product =await _songService.GetSongByIdAsync((int)id);
            if (product.Data == null)
            {
                return NotFound();
            }
            return View(product.Data);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Duration,AlbumTitle,Artist,ReleaseDate")] Song song)
        {

            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productResult = await _songService.UpdateSongAsync(song);
                }
                catch (Exception)
                {
                     return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = await _songService.GetSongByIdAsync((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product.Data);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _songService.DeleteSongByIdAsync((int)id);
            if (product.Success)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
          
        }
         
    }
}
