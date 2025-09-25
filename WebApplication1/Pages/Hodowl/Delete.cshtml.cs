using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Hodowl
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext context;

        public DeleteModel(AppDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Hodowla Hodowla { get; set; } = default!;




        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }
            var hodowla = await context.Hodowla.FirstOrDefaultAsync(e => e.HodowlaId == id);
            if (hodowla == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Hodowla = hodowla;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Hodowla == null)
            {
                return RedirectToPage("./Index");
            }
            var hodowla = await context.Hodowla.FindAsync(id);
            if (hodowla != null)
            {
                Hodowla = hodowla;
                context.Hodowla.Remove(Hodowla);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
