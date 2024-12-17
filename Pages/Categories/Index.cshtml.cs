using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Lucas_Lab2.Data;
using Pop_Lucas_Lab2.Models;

namespace Pop_Lucas_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Pop_Lucas_Lab2.Data.Pop_Lucas_Lab2Context _context;

        public IndexModel(Pop_Lucas_Lab2.Data.Pop_Lucas_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();
                CategoryData.Books = selectedCategory.BookCategories.Select(bc => bc.Book).ToList();
            }
        }
    }

    public class CategoryData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }

}
