using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anamaria_Borbola_Lab2.Data;
using Anamaria_Borbola_Lab2.Models;

namespace Anamaria_Borbola_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Anamaria_Borbola_Lab2.Data.Anamaria_Borbola_Lab2Context _context;

        public DetailsModel(Anamaria_Borbola_Lab2.Data.Anamaria_Borbola_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(i => i.Member)
                .Include(i => i.Book)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
