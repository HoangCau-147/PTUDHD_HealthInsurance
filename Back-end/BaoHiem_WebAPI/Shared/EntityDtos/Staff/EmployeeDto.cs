using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Staff
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? IdentifycationNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
