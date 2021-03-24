using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class Movie
    {
        
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Year field is required")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public string? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes must be less than 25 characters.")]
        public string? Notes { get; set; }
    }
}
