using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CSharpIs.Api.Models;
using CSharpIs.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpIs.Api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(
            ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResult<Project>>> Get(
            [Required]string query, int page = 0, int count = 50)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();

            return Ok(await _searchService
                .SearchProjectsAsync(query, page, count));
        }
    }
}