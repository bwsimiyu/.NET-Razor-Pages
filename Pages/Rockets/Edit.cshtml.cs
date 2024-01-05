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
    public class EditModel : PageModel
    {
        private readonly RazorPagesRocket.Data.RazorPagesRocketContext _context;

        public EditModel(RazorPagesRocket.Data.RazorPagesRocketContext context)
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

            var rocket =  await _context.Rocket.FirstOrDefaultAsync(m => m.Id == id);
            if (rocket == null)
            {
                return NotFound();
            }
            Rocket = rocket;
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

            _context.Attach(Rocket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RocketExists(Rocket.Id))
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

        private bool RocketExists(int id)
        {
            return _context.Rocket.Any(e => e.Id == id);
        }
    }
}
