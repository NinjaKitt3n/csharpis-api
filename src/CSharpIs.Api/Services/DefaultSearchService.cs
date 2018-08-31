using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpIs.Api.Models;

namespace CSharpIs.Api.Services
{
    public class DefaultSearchService : ISearchService
    {
        private static readonly List<Project> Projects = new List<Project>();

        static DefaultSearchService()
        {
            for (int i = 0; i < 1500; i++)
                Projects.Add(new Project
                {
                    Url = $"url {i}",
                    Name = "Finite.Commands",
                    Description = "A cool description!"
                });
        }

        public Task<SearchResult<Project>> SearchProjectsAsync(
            string query, int page, int count)
        {
            bool ProjectContainsQuery(Project project, string searchQuery)
            {
                return
                    project.Name.Contains(searchQuery,
                        StringComparison.OrdinalIgnoreCase)
                    || project.Description.Contains(searchQuery,
                        StringComparison.OrdinalIgnoreCase)
                    || project.Url.Contains(searchQuery,
                        StringComparison.OrdinalIgnoreCase);
            }

            int currentCount = 0;
            var projects =
                Projects.Where(x => ProjectContainsQuery(x, query))
                    .GroupBy(x => currentCount++ / count)
                    .Skip(page);

            return Task.FromResult(new SearchResult<Project>
            {
                Values = projects.FirstOrDefault().ToArray(),
                Pages = projects.Count()
            });
        }
    }
}