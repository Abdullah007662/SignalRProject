using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public int CategoryCount();
        public int ActiveCategoryCount();
        public int PasiveCategoryCount();
    }
}
