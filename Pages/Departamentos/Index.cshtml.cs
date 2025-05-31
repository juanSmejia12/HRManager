using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Departamentos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public IndexModel(HRManagerDbContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamentos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departamentos != null)
            {
                Departamentos = await _context.Departamentos.ToListAsync();
            }
        }
    }
}
