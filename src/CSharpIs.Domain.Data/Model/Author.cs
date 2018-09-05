using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpIs.Domain.Data.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ExploreUrl { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
