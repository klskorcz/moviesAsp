using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Model;

namespace Movies.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public MovieData Entry { get; set; }

        [TempData]
        public string afterAddMessage { get; set; }

        public void OnGet(int id)
        {
            Entry = _db.MovieDataItems.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var entryInDb = _db.MovieDataItems.Find(Entry.ID);
                entryInDb.MovieName = Entry.MovieName;
                entryInDb.MovieYear = Entry.MovieYear;
                entryInDb.MovieGenre = Entry.MovieGenre;
                entryInDb.MovieDirector = Entry.MovieDirector;

                await _db.SaveChangesAsync();
                afterAddMessage = "Entry item has been successfully updated! Sweet!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}