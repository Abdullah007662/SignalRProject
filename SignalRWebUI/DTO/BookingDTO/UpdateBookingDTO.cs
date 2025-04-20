using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTO.BookingDTO
{
    public class UpdateBookingDTO
    {
        public int BookingID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
