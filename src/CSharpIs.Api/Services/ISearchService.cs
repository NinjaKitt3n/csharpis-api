using System.Threading.Tasks;
using CSharpIs.Api.Models;

namespace CSharpIs.Api.Services
{
    public interface ISearchService
    {
        Task<SearchResult<Project>> SearchProjectsAsync(
            string query, int page, int count);
    }
}