using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowc
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Hodowca> Hodowca { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Hodowca = await context.Hodowca.ToListAsync();
        }
    }
}
