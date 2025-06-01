using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Cargos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public IndexModel(HRManagerDbContext context)
        {
            _context = context;
        }

        public IList<Cargo> Cargos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cargos != null)
            {
                Cargos = await _context.Cargos.ToListAsync();
            }
        }
    }
}

