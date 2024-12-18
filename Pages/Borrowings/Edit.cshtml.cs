﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_Lucas_Lab2.Data;

namespace Pop_Lucas_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Pop_Lucas_Lab2.Data.Pop_Lucas_Lab2Context _context;

        public EditModel(Pop_Lucas_Lab2.Data.Pop_Lucas_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowings == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowings.FindAsync(id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
                });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Members, "ID", "FullName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowings.Any(e => e.ID == id);
        }
    }
}
