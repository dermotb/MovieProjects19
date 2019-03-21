using System;
using System.ComponentModel.DataAnnotations;

namespace MovieClient.Models
{
    // various certs
    public enum Certificate { Universal, Twelve, Fifteen, Eighteen }

    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public String Title { get; set; }

        public string Genre { get; set; }

        public Certificate Cert { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Rating { get; set; }

    }
}
