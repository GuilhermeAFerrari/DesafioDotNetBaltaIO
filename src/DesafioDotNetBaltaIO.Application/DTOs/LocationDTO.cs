using System.ComponentModel.DataAnnotations;

namespace DesafioDotNetBaltaIO.Application.DTOs
{
    public record LocationDTO(
        [property: Required, StringLength(7, MinimumLength = 7)] string Id,
        [property: StringLength(80)] string City,
        [property: StringLength(2, MinimumLength = 2)] string State);
}
