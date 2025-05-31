using HRManager.Models;
using HRManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;



namespace HRManager.Pages.Nomina
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public IndexModel(HRManagerDbContext context)
        {
            _context = context;
        }

        public IList<Nominas> Nomina { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Nomina != null)
            {
                Nomina = await _context.Nomina.ToListAsync();
            }
        }

    }
}

