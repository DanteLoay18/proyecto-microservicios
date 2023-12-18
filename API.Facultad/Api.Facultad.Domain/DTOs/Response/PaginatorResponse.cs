﻿

namespace Api.Facultad.Domain.DTOs.Response
{
    public class PaginatorResponse<T>
    {
        public List<T>? Items { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}
