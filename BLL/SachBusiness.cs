using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class SachBusiness : ISachBusiness
    {
        private ISachRepository _res;
        public SachBusiness(ISachRepository SachGroupRes)
        {
            _res = SachGroupRes;
        }
        public bool Create(SachModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SachModel model)
        {
            return _res.Update(model);
        }
        public SachModel GetDatabyID(string id)
        {
            var kq= _res.GetDatabyID(id);
            kq.NXB = _res.GetNXBBYSACH(id);
            kq.CD = _res.GetCDBYSACH(id);
            return kq;
        }

       
        public List<SachModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<SachModel> phantrang(int pageIndex, int pageSize, out long total)
        {
            return _res.phantrang(pageIndex, pageSize, out total);
        }
        public List<SachModel> GetDataByChuDe(string id)
        {
            return _res.GetDataByChuDe(id);
        }
    }

}
