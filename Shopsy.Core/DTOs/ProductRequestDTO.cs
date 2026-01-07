using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class ProductRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public string ProductImageUrl { get; set; } = string.Empty;
    }
}
