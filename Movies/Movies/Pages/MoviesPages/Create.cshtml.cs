using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Model;

namespace Movies.Pages.MoviesPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string afterAddMessage { get; set; }

        [BindProperty]
        public MovieData Entry { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }else
            {
                _db.MovieDataItems.Add(Entry);

                await _db.SaveChangesAsync();
                afterAddMessage = "You added another favorite movie! Way to go!";
                return RedirectToPage("Index");
            }
        }
    }
}