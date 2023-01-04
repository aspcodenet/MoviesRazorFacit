using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesRazor.Data;

namespace MoviesRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public class MovieItem
        {
            public string Title { get; set; }
            public string Director { get; set; }
            public int Year { get; set; }
            public string GenreName { get; set; }

        }

        public List<MovieItem> Items { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Items = _context.Movies.Select(m => new MovieItem
            {
                Director = m.Director,
                Title = m.Title,
                Year = m.Year,
                GenreName = m.Genre.Name,
            }).ToList();
        }
    }
}