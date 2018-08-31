using System.Collections.Generic;

namespace CSharpIs.Api.Models
{
    public class SearchResult<T>
    {
        public ICollection<T> Values { get; set; }
        public int Pages { get; set; }
    }
}