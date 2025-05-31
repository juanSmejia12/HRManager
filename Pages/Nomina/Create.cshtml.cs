using HRManager.Models;
using HRManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HRManager.Pages.Nomina
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public CreateModel(HRManagerDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public Nominas Nomina { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Nomina == null || Nomina == null)
            {
                return Page();
            }

            _context.Nomina.Add(Nomina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

