using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Yunly.Learning.RazorPagesMovie.Models
{
    public class YunlyLearningRazorPagesMovieContext : DbContext
    {
        public YunlyLearningRazorPagesMovieContext (DbContextOptions<YunlyLearningRazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Yunly.Learning.RazorPagesMovie.Models.Movie> Movie { get; set; }
    }
}
