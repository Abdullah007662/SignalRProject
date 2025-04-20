using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ApiDTO.AboutDTO
{
    public class CreateAboutDTO
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
