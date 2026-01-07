using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class ApiResponseDTO<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = default!;
    }
}
