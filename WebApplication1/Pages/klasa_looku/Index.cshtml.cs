using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.klasa_looku
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }
        public IList<klasa_lookup> klasa_lookup { get; set; } = default!;
        public async Task OnGetAsync()
        {
            klasa_lookup = await context.klasa_lookup.ToListAsync();
        }
    }
}
