using HRManager.Models;
using HRManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;



namespace HRManager.Pages.Nominas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerDbContext _context;

        public IndexModel(HRManagerDbContext context)
        {
            _context = context;
        }

        public IList<Nomina> Nominas { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Nominas != null)
            {
                Nominas = await _context.Nominas.ToListAsync();
            }
        }

    }
}

