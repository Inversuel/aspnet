using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesAspnet.Models;

public class Emails
{
  [Key]
  public int Id { get; set; }

  public required Persons Persons { get; set; }

  [ForeignKey("PersonsId_FK")]
  public int PersonsId { get; set; }

  [MaxLength(50), EmailAddress]
  public required string Email { get; set; }

}