using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Cargos
{
    public class EditModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public EditModel(HRManagerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargo == null)
            {
                return NotFound();
            }

            Cargo = cargo;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(Cargo.IdCargo))
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

        private bool CargoExists(int id)
        {
            return (_context.Cargos?.Any(e => e.IdCargo == id)).GetValueOrDefault();
        }
    }
}
