using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hod_Ras
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Hod_Rasy> Hod_Rasy { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Hod_Rasy = await context.Hod_Rasy.ToListAsync();
        }
    }
}
