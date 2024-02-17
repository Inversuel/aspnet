using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesAspnet.Models;

public class Persons
{
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public required string Imie { get; set; }

  [MaxLength(50)]
  public required string Nazwisko { get; set; }
  public required string Opis { get; set; }

  public ICollection<Emails>? Emails { get; set; } = [];
}