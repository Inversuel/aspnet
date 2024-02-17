using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAspnet.Data;
using RazorPagesAspnet.Models;

namespace RazorPagesAspnet.Pages.Create
{
    public class CreateModel(RazorPagesAspnetContext context) : PageModel
    {
        private readonly RazorPagesAspnetContext _context = context;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Persons Persons { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Persons.Add(Persons);

            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
