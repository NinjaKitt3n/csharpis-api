using CSharpIs.Domain.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CSharpIs.Domain.DAL
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTag> ProjectTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}
