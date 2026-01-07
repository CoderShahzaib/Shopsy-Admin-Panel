using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class ProductApiResponseDTO<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public ProductData<T> Data { get; set; } = default!;
    }

    public class ProductData<T>
    {
        public int TotalProducts { get; set; }
        public T Products { get; set; } = default!;
    }

}
