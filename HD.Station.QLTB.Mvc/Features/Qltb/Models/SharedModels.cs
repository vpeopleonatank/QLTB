using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HD.Station.Qltb.Mvc.Models;

public record RequestEnvelope<T>
{
    [Required] [FromBody] public T Body { get; init; } = default!;
}
