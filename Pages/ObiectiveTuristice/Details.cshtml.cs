using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectChioranAndrei.Data;
using proiectChioranAndrei.Models;

namespace proiectChioranAndrei.Pages.ObiectiveTuristice
{
    public class DetailsModel : PageModel
    {
        private readonly proiectChioranAndrei.Data.proiectChioranAndreiContext _context;

        public DetailsModel(proiectChioranAndrei.Data.proiectChioranAndreiContext context)
        {
            _context = context;
        }

      public ObiectivTuristic ObiectivTuristic { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ObiectivTuristic == null)
            {
                return NotFound();
            }

            var obiectivturistic = await _context.ObiectivTuristic.Include(b=>b.Oras).FirstOrDefaultAsync(m => m.ID == id);
            if (obiectivturistic == null)
            {
                return NotFound();
            }
            else 
            {
                ObiectivTuristic = obiectivturistic;
            }
            return Page();
        }
    }
}
