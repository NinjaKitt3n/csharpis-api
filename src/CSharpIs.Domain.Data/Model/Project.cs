using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpIs.Domain.Data.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProjectTag> Tags { get; set; }
    }
}
