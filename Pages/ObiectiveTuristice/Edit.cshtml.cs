using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectChioranAndrei.Data;
using proiectChioranAndrei.Models;

namespace proiectChioranAndrei.Pages.ObiectiveTuristice
{
    public class EditModel : PageModel
    {
        private readonly proiectChioranAndrei.Data.proiectChioranAndreiContext _context;

        public EditModel(proiectChioranAndrei.Data.proiectChioranAndreiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ObiectivTuristic ObiectivTuristic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ObiectivTuristic == null)
            {
                return NotFound();
            }

            var obiectivturistic =  await _context.ObiectivTuristic.FirstOrDefaultAsync(m => m.ID == id);
            if (obiectivturistic == null)
            {
                return NotFound();
            }
            ObiectivTuristic = obiectivturistic;
           ViewData["OrasID"] = new SelectList(_context.Set<Oras>(), "ID", "NumeOras");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ObiectivTuristic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObiectivTuristicExists(ObiectivTuristic.ID))
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

        private bool ObiectivTuristicExists(int id)
        {
          return (_context.ObiectivTuristic?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
