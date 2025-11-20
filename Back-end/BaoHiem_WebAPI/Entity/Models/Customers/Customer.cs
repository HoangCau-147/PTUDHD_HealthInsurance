using Entity.Models.Claim;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Customers
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? IdentifycationNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreateDay { get; set; } = DateTime.Now;
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? UserID { get; set; }

        public User? User { get; set; }

        public ICollection<ClaimRequest>? Claims { get; set; }
        public ICollection<ClaimPayment>? Payments { get; set; }
        
    }
}
