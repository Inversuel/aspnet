
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAspnet.Data;
using RazorPagesAspnet.Models;

namespace RazorPagesAspnet.Pages.Edit
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesAspnetContext _context;

        public EditModel(RazorPagesAspnetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Persons Persons { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persons = await _context.Persons.Include(i => i.Emails).FirstOrDefaultAsync(m => m.Id == id);
            if (persons == null)
            {
                return NotFound();
            }
            Persons = persons;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var persons = await _context.Persons.Include(i => i.Emails).FirstOrDefaultAsync(m => m.Id == Persons.Id);

                if (persons == null)
                {
                    return Page();
                }
                persons.Imie = Persons.Imie;
                persons.Opis = Persons.Opis;
                persons.Nazwisko = Persons.Nazwisko;
                _context.Update(persons);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(Persons.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool PersonsExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
