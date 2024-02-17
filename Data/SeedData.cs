using Microsoft.EntityFrameworkCore;
using RazorPagesAspnet.Data;
using RazorPagesAspnet.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
  public static async void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new RazorPagesAspnetContext(
        serviceProvider.GetRequiredService<
            DbContextOptions<RazorPagesAspnetContext>>()))
    {
      if (context == null || context.Persons == null || context.Emails == null)
      {
        throw new ArgumentNullException("Null RazorPagesAspnetContext");
      }
      if (context.Persons.Any() || context.Emails.Any())
      {
        return;
      }
      context.Persons.AddRange(
          new Persons
          {
            Imie = "Adam",
            Nazwisko = "Kowalski",
            Opis = "Opis adama Kowalski",
          },
          new Persons
          {
            Imie = "Jan",
            Nazwisko = "Kowalski",
            Opis = "Opis Jan Kowalski",
          },
          new Persons
          {
            Imie = "Barbara",
            Nazwisko = "Kowalski",
            Opis = "Opis Barbara Kowalski",
          },
          new Persons
          {
            Imie = "Wojtek",
            Nazwisko = "Kowalski",
            Opis = "Opis Wojtek Kowalski",
          },
          new Persons
          {
            Imie = "Sebastian",
            Nazwisko = "Kowalski",
            Opis = "Opis Wojtek Kowalski",
          },
          new Persons
          {
            Imie = "Andrzej",
            Nazwisko = "Kowalski",
            Opis = "Opis Wojtek Kowalski",
          },
          new Persons
          {
            Imie = "Jan",
            Nazwisko = "Kowalski",
            Opis = "Opis Wojtek Kowalski",
          },
          new Persons
          {
            Imie = "Tim",
            Nazwisko = "Kowalski",
            Opis = "Opis Wojtek Kowalski",
          },
          new Persons
          {
            Imie = "Theo",
            Nazwisko = "Kowalski",
            Opis = "Opis Wojtek Kowalski",
          }
      );
      context.SaveChanges();
      var personsLinst = await context.Persons.ToListAsync();
      foreach (var person in personsLinst)
      {
        context.Add(
          new Emails { Persons = person, Email = $"{person.Imie.ToLower()}.{person.Nazwisko.ToLower()}@example.com" }
        );
      }

      context.SaveChanges();
    }
  }
}