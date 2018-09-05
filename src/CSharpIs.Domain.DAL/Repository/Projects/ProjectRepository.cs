using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpIs.Domain.Data.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace CSharpIs.Domain.DAL.Repository.Projects
{
    public interface IProjectRepository : IDisposable
    {
        Task<List<Project>> GetProjectsForSearch(string query, int entitiesToSkip, int limitResultsTo);
    }

    [UsedImplicitly]
    public class ProjectRepository : IProjectRepository
    {
        private readonly EntityContext _context;

        public ProjectRepository(EntityContext context)
        {
            _context = context;
        }

        public Task<List<Project>> GetProjectsForSearch(string query, int entitiesToSkip, int limitResultsTo)
        {
            return _context.Projects
                .Include(x => x.Author)
                .Include(x => x.Tags)
                .ThenInclude(x => x.Tag)
                .Where(x => query == null || x.Name.Contains(query))
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Id)
                .Skip(entitiesToSkip)
                .Take(limitResultsTo)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
