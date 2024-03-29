﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Domain.DTOs.Response
{
    public class PaginatorResponse<T>
    {
        public List<T>? Items { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}
