using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowl
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Hodowla> Hodowla { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Hodowla = await context.Hodowla
                .Include(h => h.Hodowca)
                .ToListAsync();
        }
    }
}
