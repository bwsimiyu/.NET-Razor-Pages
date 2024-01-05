using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesRocket.Data;
using RazorPagesRocket.Models;

namespace RazorPagesRocket.Pages_Rockets
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesRocket.Data.RazorPagesRocketContext _context;

        public CreateModel(RazorPagesRocket.Data.RazorPagesRocketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rocket Rocket { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rocket.Add(Rocket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
