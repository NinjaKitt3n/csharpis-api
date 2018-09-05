using System;
using System.Collections.Generic;

namespace CSharpIs.Services.Projects
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public List<string> Tags { get; set; }
    }
}
