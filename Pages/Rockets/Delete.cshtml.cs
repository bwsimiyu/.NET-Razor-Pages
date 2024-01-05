using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesRocket.Data;
using RazorPagesRocket.Models;

namespace RazorPagesRocket.Pages_Rockets
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesRocket.Data.RazorPagesRocketContext _context;

        public DeleteModel(RazorPagesRocket.Data.RazorPagesRocketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rocket Rocket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rocket.FirstOrDefaultAsync(m => m.Id == id);

            if (rocket == null)
            {
                return NotFound();
            }
            else
            {
                Rocket = rocket;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rocket.FindAsync(id);
            if (rocket != null)
            {
                Rocket = rocket;
                _context.Rocket.Remove(Rocket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
