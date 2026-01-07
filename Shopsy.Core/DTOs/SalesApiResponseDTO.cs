using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class SalesApiResponseDTO<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public SalesData<T> Data { get; set; } = default!;
    }

    public class SalesData<T>
    {
        public int TotalSales { get; set; }
        public T Sales { get; set; } = default!;
    }

}
