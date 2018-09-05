using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpIs.Domain.Data.Model;
using CSharpIs.Services.Projects;
using Microsoft.AspNetCore.Mvc;

namespace CSharpIs.Api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public SearchController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get(string query = null, int page = 0, int count = 50)
        {
            var projects = await _projectService.GetProjectsForSearch(query, page, count);

            return Ok(projects);
        }
    }
}