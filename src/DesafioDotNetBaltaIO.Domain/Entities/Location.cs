using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDotNetBaltaIO.Domain.Entities
{
    [Table("ibge")]
    public class Location
    {
        [Column("id")]
        public string Id { get; set; } = null!;
        [Column("state")]
        public string? State { get; set; }
        [Column("city")]
        public string? City { get; set; }
    }
}