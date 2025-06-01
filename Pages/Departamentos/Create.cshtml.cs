using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Departamentos
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public CreateModel(HRManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Departamento Departamento { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Entró al OnPostAsync");

            if (!ModelState.IsValid || _context.Departamentos == null || Departamento == null)
            {
                return Page();
            }

            _context.Departamentos.Add(Departamento);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Departamento guardado: {Departamento.NombreDepartamento} - {Departamento.Ubicacion}");

            return RedirectToPage("./Index");
        }
    }
}
