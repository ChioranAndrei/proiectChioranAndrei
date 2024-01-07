using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectChioranAndrei.Data;
using proiectChioranAndrei.Models;

namespace proiectChioranAndrei.Pages.Orase
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
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID",
"NumeTara");
            return Page();
        }

        [BindProperty]
        public Oras Oras { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Oras == null || Oras == null)
            {
                return Page();
            }

            _context.Oras.Add(Oras);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
