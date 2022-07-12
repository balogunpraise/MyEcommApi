using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerce.Api.Helpers
{
    public class PagedResponse<T> where T : class
    {

        public PagedResponse(int pageNumber, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            Count = count;
            Data = data;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
