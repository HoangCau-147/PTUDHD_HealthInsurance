using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances
{
    public class AddProgramPricePerProductDto
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int price { get; set; }
    }
}
