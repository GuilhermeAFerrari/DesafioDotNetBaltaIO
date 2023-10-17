using System.ComponentModel.DataAnnotations;

namespace DesafioDotNetBaltaIO.Application.DTOs
{
    public record UserDTO(
        [property: Required] string Email,
        [property: Required] string Password,
        string? Name
    );
}
