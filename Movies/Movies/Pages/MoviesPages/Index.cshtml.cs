using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.Model;

namespace Movies.Pages.MoviesPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string afterAddMessage { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<MovieData> myConnections { get; set; }

        public async Task OnGet()
        {
            myConnections = await _db.MovieDataItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theEntry = _db.MovieDataItems.Find(id);
            _db.MovieDataItems.Remove(theEntry);
            await _db.SaveChangesAsync();
            afterAddMessage = "Entry successfully deleted!";

            return RedirectToPage();
        }
    }
}