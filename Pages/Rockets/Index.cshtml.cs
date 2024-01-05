using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesRocket.Data;
using RazorPagesRocket.Models;

namespace RazorPagesRocket.Pages_Rockets
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesRocket.Data.RazorPagesRocketContext _context;

        public IndexModel(RazorPagesRocket.Data.RazorPagesRocketContext context)
        {
            _context = context;
        }

        public IList<Rocket> Rocket { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RocketName { get; set; }

        public async Task OnGetAsync()
        {
            var rockets = from r in _context.Rocket select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                rockets = rockets.Where(q => q.Name.Contains(SearchString));
            }
            Rocket = await rockets.ToListAsync();
        }
    }
}
