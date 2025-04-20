using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ApiDTO.TestimonialDTO
{
    public class CreateTestimonialDTO
    {
        public string? NameSurname { get; set; }
        public string? Title { get; set; }
        public string? Commet { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
