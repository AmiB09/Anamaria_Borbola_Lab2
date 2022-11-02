﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anamaria_Borbola_Lab2.Data;
using Anamaria_Borbola_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Anamaria_Borbola_Lab2.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Anamaria_Borbola_Lab2.Data.Anamaria_Borbola_Lab2Context _context;

        public DeleteModel(Anamaria_Borbola_Lab2.Data.Anamaria_Borbola_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(i => i.Author)
                .Include(i => i.Publisher)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }
            var book = await _context.Book.FindAsync(id);

            if (book != null)
            {
                Book = book;

                _context.Book.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
