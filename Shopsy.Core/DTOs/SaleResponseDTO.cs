using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class SaleResponseDTO
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;

        public bool IsDelivered { get; set; }
        public DateTime? DeliveredOn { get; set; }

        public decimal SubTotal { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal GrandTotal { get; set; }

        public DateTime OrderDate { get; set; }

    }

}
