using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anamaria_Borbola_Lab2.Data;
using Anamaria_Borbola_Lab2.Models;

namespace Anamaria_Borbola_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Anamaria_Borbola_Lab2.Data.Anamaria_Borbola_Lab2Context _context;

        public DetailsModel(Anamaria_Borbola_Lab2.Data.Anamaria_Borbola_Lab2Context context)
        {
            _context = context;
        }

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

    }
}
