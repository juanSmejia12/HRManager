using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Models;
using HRManager.Data;
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync

namespace HRManager.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Usuarios> Usuarios { get; set; } 

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios.ToListAsync(); 
        }
    }
}