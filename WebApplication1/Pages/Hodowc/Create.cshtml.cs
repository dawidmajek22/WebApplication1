using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowc
{
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
        public Hodowca Hodowca { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || context.Hodowca == null || Hodowca == null)
            {
                return Page();
            }
            context.Hodowca.Add(Hodowca);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        

    }
}
