using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpIs.Domain.DAL.Repository.Projects;
using JetBrains.Annotations;

namespace CSharpIs.Services.Projects
{
    public interface IProjectService : IDisposable
    {
        Task<IEnumerable<ProjectDto>> GetProjectsForSearch(string query, int pageNumber, int limitResultsTo);
    }

    [UsedImplicitly]
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsForSearch(string query, int pageNumber, int limitResultsTo)
        {
            var entitiesToSkip = limitResultsTo * (pageNumber);

            var projects = await _projectRepository.GetProjectsForSearch(query, entitiesToSkip, limitResultsTo);

            return projects.Select(x => new ProjectDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                DateAdded = x.DateAdded,
                DateLastUpdated = x.DateLastUpdated,
                ImageUrl = x.ImageUrl,
                Slug = x.Url,
                Tags = x.Tags.Select(q => q.Tag.Value).ToList(),
            });
        }

        public void Dispose()
        {
            _projectRepository?.Dispose();
        }
    }
}
