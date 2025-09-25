using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.HodowcaHodowla
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<HodowcaHodowlaView> Dane { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Dane = _context.HodowcaHodowlaView.ToList();
        }
    }
}
