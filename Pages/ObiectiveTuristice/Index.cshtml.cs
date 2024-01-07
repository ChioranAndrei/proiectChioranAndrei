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
    public class IndexModel : PageModel
    {
        private readonly proiectChioranAndrei.Data.proiectChioranAndreiContext _context;

        public IndexModel(proiectChioranAndrei.Data.proiectChioranAndreiContext context)
        {
            _context = context;
        }

        public IList<ObiectivTuristic> ObiectivTuristic { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()

        {    /*
            var obiective = from m in _context.ObiectivTuristic
                            from o in _context.Oras
                            where m.OrasID == o.ID
                            select new { m.ID, m.Nume, m.Strada o.NumeOras };
            */
            if (!string.IsNullOrEmpty(SearchString))
            {
              //  obiective= obiective.Where(s => s.Nume.Contains(SearchString));

                   
                 ObiectivTuristic = await _context.ObiectivTuristic
                       .Include(o => o.Oras).Where(s => s.Nume.Contains(SearchString)).ToListAsync();
                    }
            
              else 
              if (_context.ObiectivTuristic != null)
                ObiectivTuristic = await _context.ObiectivTuristic
                    .Include(o => o.Oras).ToListAsync();
                
            }
            //{
            //  if (_context.ObiectivTuristic != null)
            //{
            //  ObiectivTuristic = await _context.ObiectivTuristic
            //.Include(o => o.Oras).ToListAsync();
            //    }
            //  }
        }
}
