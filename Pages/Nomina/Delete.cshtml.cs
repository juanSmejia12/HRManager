using HRManager.Models;
using HRManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManager.Pages.Nomina
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public DeleteModel(HRManagerDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public Nominas Nomina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nomina == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nomina.FirstOrDefaultAsync(m => m.IdNomina == id);

            if (nomina == null)
            {
                return NotFound();
            }
            else
            {
                Nomina = nomina;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Nomina == null)
            {
                return NotFound();
            }
            var nomina = await _context.Nomina.FindAsync(id);

            if (nomina != null)
            {
                Nomina = nomina;
                _context.Nomina.Remove(Nomina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        ///
    }
}

