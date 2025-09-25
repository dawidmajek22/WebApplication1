using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hod_Ras
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;

        public EditModel(AppDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Hod_Rasy Hod_Rasy { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }
            var hod_rasy = await context.Hod_Rasy.FirstOrDefaultAsync(e => e.ID == id);
            if (hod_rasy == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Hod_Rasy = hod_rasy;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Hod_Rasy.Update(Hod_Rasy);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
