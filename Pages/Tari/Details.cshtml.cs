using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectChioranAndrei.Data;
using proiectChioranAndrei.Models;

namespace proiectChioranAndrei.Pages.Tari
{
    public class DetailsModel : PageModel
    {
        private readonly proiectChioranAndrei.Data.proiectChioranAndreiContext _context;

        public DetailsModel(proiectChioranAndrei.Data.proiectChioranAndreiContext context)
        {
            _context = context;
        }

      public Tara Tara { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tara == null)
            {
                return NotFound();
            }

            var tara = await _context.Tara.FirstOrDefaultAsync(m => m.ID == id);
            if (tara == null)
            {
                return NotFound();
            }
            else 
            {
                Tara = tara;
            }
            return Page();
        }
    }
}
