using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ChuDeBusiness : IChuDeBusiness
    {
        private IChuDeRepository _res;
        public ChuDeBusiness(IChuDeRepository ChuDeGroupRes)
        {
            _res = ChuDeGroupRes;
        }
        //public bool Create(ChuDeModel model)
        //{
        //    return _res.Create(model);
        //}
        //public ChuDeModel GetDatabyID(string id)
        //{
        //    return _res.GetDatabyID(id);
        //}
        public List<ChuDeModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        //public List<ChuDeModel> Search(int pageIndex, int pageSize, out long total, string ChuDe_group_id)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, ChuDe_group_id);
        //}
    }

}
