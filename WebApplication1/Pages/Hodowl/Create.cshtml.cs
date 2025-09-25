using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowl
{

    public class CreateModel : PageModel
    {
        private readonly AppDbContext context;

        public CreateModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Hodowla Hodowla { get; set; } = default!;

        // To jest lista hodowców dla selecta
        public IList<Hodowca> Hodowcy { get; set; } = new List<Hodowca>();

        public async Task<IActionResult> OnGetAsync()
        {
            Hodowcy = await context.Hodowca.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Hodowla == null)
            {
                return Page();
            }

            context.Hodowla.Add(Hodowla);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
