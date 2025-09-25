using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hod_Ras
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext context;

        public CreateModel(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Hod_Rasy Hod_Rasy { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || context.Hod_Rasy == null || Hod_Rasy == null)
            {
                return Page();
            }
            context.Hod_Rasy.Add(Hod_Rasy);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
