using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HRManager.Models;
using HRManager.Data;


namespace HRManager.Pages.Shared.Nomina
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
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

