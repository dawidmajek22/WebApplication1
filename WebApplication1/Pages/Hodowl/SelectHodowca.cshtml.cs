using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowl
{
    public class SelectHodowcaModel : PageModel
    {
        private readonly AppDbContext context;

        public SelectHodowcaModel(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Hodowca> Hodowcy { get; set; } = new List<Hodowca>();

        [BindProperty]
        public int HodowlaId { get; set; }

        [BindProperty]
        public int HodowcaId { get; set; }

        public async Task OnGetAsync(int hodowlaId)
        {
            Hodowcy = await context.Hodowca.ToListAsync();
            HodowlaId = hodowlaId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var hodowla = await context.Hodowla.FindAsync(HodowlaId);
            if (hodowla == null)
            {
                return RedirectToPage("./Index");
            }

            hodowla.IdHodowcy = HodowcaId;  // <-- tu przypisujemy nowego hodowcê
            context.Update(hodowla);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
