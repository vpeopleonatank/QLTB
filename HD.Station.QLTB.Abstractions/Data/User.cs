using System.ComponentModel.DataAnnotations;

namespace HD.Station.Qltb.Abstractions.Data
{

  public class User {
    public int Id { get; private set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(255)]
    public string? Password { get; set; }

    public string? Bio { get; set; }

    [MaxLength(255)]
    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
  }
}
