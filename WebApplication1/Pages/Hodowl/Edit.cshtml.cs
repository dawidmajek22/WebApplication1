using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowl
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;

        public EditModel(AppDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Hodowla Hodowla { get; set; } = default!;

        public IList<Hodowca> Hodowcy { get; set; } = new List<Hodowca>();

        public async Task<IActionResult> OnGetAsync(int? id, int? hodowcaId)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var hodowla = await context.Hodowla
                .Include(h => h.Hodowca) // <-- za³aduj hodowcê
                .FirstOrDefaultAsync(e => e.HodowlaId == id);

            if (hodowla == null)
            {
                return RedirectToPage("./Index");
            }

            if (hodowcaId != null)
            {
                hodowla.IdHodowcy = hodowcaId.Value;
                context.Hodowla.Update(hodowla);
                await context.SaveChangesAsync();

                // odœwie¿ dane z powi¹zanym hodowc¹
                hodowla = await context.Hodowla
                    .Include(h => h.Hodowca)
                    .FirstOrDefaultAsync(e => e.HodowlaId == id);
            }

            Hodowla = hodowla;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Hodowla.Update(Hodowla);
            await context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
