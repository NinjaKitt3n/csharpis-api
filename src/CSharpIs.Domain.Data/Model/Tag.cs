using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpIs.Domain.Data.Model
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
    }
}
