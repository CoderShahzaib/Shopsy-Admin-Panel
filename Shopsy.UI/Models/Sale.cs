using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopsy.UI.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public Guid CustomerId { get; set; }

        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public bool IsDelivered { get; set; }

        public DateTime? DeliveredOn { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public string PaymentStatus { get; set; } = "Pending";

        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCharges { get; set; }

        public decimal GrandTotal { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
