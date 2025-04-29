using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTO.MenuTableDTO
{
    public class GetByIdMenüTableDTO
    {
        public int MenuTableID { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
