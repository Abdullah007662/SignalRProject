using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public int BCategoryCount();
        public int BActiveCategoryCount();
        public int BPasiveCategoryCount();
    }
}
