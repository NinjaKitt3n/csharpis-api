using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpIs.Services.Projects;
using Microsoft.AspNetCore.Mvc;

namespace CSharpIs.Api.Controllers
{
    [Route("search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public SearchController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<ProjectDto>))]
        public async Task<IActionResult> Get(string query = null, int page = 0, int count = 50)
        {
            var projects = await _projectService.GetProjectsForSearch(query, page, count);

            return Ok(projects);
        }
    }
}