using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void BAdd(MoneyCase entity)
        {
            _moneyCaseDal.Add(entity);
        }

        public void BDelete(MoneyCase entity)
        {
            _moneyCaseDal.Delete(entity);
        }

        public MoneyCase BGetById(int id)
        {
            return _moneyCaseDal.GetById(id);
        }

        public List<MoneyCase> BGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public decimal BTotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void BUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);
        }
    }
}
