using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectChioranAndrei.Data;
using proiectChioranAndrei.Models;

namespace proiectChioranAndrei.Pages.ObiectiveTuristice
{
    public class CreateModel : PageModel
    {
        private readonly proiectChioranAndrei.Data.proiectChioranAndreiContext _context;

        public CreateModel(proiectChioranAndrei.Data.proiectChioranAndreiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrasID"] = new SelectList(_context.Set<Oras>(), "ID", "NumeOras");
            return Page();
        }

        [BindProperty]
        public ObiectivTuristic ObiectivTuristic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ObiectivTuristic == null || ObiectivTuristic == null)
            {
                return Page();
            }

            _context.ObiectivTuristic.Add(ObiectivTuristic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
