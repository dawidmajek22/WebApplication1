using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowc
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext context;

        public DeleteModel(AppDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Hodowca Hodowca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }
            var hodowca = await context.Hodowca.FirstOrDefaultAsync(e => e.IdHodowcy == id);
            if (hodowca == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Hodowca = hodowca;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }
            var hodowca = await context.Hodowca.FindAsync(id);
            if (hodowca == null)
            {
                return Page();
            }
            else
            {
                Hodowca = hodowca;
                context.Hodowca.Remove(Hodowca);
                await context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
                
        }
    }
}
