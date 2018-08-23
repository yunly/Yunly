using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Yunly.Learning.RazorPagesMovie.Models;

namespace Yunly.Learning.RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Yunly.Learning.RazorPagesMovie.Models.YunlyLearningRazorPagesMovieContext _context;

        public IndexModel(Yunly.Learning.RazorPagesMovie.Models.YunlyLearningRazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
