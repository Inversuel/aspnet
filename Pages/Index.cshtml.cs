using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAspnet.Data;
using RazorPagesAspnet.Models;

namespace RazorPagesAspnet.Pages;

public class IndexModel(ILogger<IndexModel> logger, RazorPagesAspnetContext context) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly RazorPagesAspnetContext _context = context;

    public IList<Persons> Persons { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Persons = await _context.Persons.Include(i => i.Emails).ToListAsync();
    }

    public async Task<IActionResult> OnPostDelete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var persons = await _context.Persons.FindAsync(id);
        if (persons != null)
        {
            _context.Persons.Remove(persons);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
    public async Task<IActionResult> OnPostAddEmail(int? id, string email)
    {
        if (id == null)
        {
            return NotFound();
        }

        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        _context.Emails.Add(new Emails { Email = email, PersonsId = person.Id, Persons = person });
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
    public async Task<IActionResult> OnPostDeleteEmail(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var emails = await _context.Emails.FindAsync(id);
        if (emails != null)
        {
            _context.Emails.Remove(emails);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}

