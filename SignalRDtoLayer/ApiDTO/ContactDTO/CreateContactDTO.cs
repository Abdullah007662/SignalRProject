using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ApiDTO.ContactDTO
{
    public class CreateContactDTO
    {
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FooterDescription { get; set; }
    }
}
