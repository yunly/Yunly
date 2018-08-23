using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Yunly.Learning.RazorPagesMovie.Models;

namespace Yunly.Learning.RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Yunly.Learning.RazorPagesMovie.Models.YunlyLearningRazorPagesMovieContext _context;

        public CreateModel(Yunly.Learning.RazorPagesMovie.Models.YunlyLearningRazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}