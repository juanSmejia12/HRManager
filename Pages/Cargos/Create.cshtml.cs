using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Cargos
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public CreateModel(HRManagerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Cargos == null || Cargo == null)
            {
                return Page();
            }

            _context.Cargos.Add(Cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
