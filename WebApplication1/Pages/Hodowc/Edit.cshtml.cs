using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowc
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;

        public EditModel(AppDbContext context)
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
            var hodowca = await context.Hodowca.FirstOrDefaultAsync(e=> e.IdHodowcy==id);
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Hodowca.Update(Hodowca);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
