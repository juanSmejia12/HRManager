using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Cargos
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public DeleteModel(HRManagerDbContext context)
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
            else
            {
                Cargo = cargo;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FindAsync(id);

            if (cargo != null)
            {
                Cargo = cargo;
                _context.Cargos.Remove(Cargo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
