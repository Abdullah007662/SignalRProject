using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ApiDTO.CategoryDTO
{
    public class ResultCategoryDTO
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
