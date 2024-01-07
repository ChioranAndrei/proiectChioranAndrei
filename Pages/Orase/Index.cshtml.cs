using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectChioranAndrei.Data;
using proiectChioranAndrei.Models;
using proiectChioranAndrei.Models.ViewModels;

namespace proiectChioranAndrei.Pages.Orase
{
    public class IndexModel : PageModel
    {
        private readonly proiectChioranAndrei.Data.proiectChioranAndreiContext _context;

        public IndexModel(proiectChioranAndrei.Data.proiectChioranAndreiContext context)
        {
            _context = context;
        }

        public IList<Oras> Oras { get;set; } = default!;

        public OrasIndexData OrasData { get; set; }
        public int OrasID { get; set; }
        public int ObiectivTuristicID { get; set; }

        public async Task OnGetAsync(int? id) {
            OrasData = new OrasIndexData();
            OrasData.Orase = await _context.Oras
            .Include(i => i.ObiectivTuristic)
            //.ThenInclude(c => c.Strada)
            .Include(i => i.Tara)
            .OrderBy(i => i.NumeOras)
            .ToListAsync();

            if (id != null)
            {
                OrasID = id.Value;
                Oras oras = OrasData.Orase
                .Where(i => i.ID == id.Value).Single();
                OrasData.ObiectiveTuristice = oras.ObiectivTuristic;

                    ;
            }
        }

       
        }
    }

