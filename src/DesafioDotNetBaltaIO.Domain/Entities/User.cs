﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDotNetBaltaIO.Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("password")]
        public string? Password { get; set; }
    }
}
