using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NhaXuatBanBusiness : INhaXuatBanBusiness
    {
        private INhaXuatBanRepository _res;
        public NhaXuatBanBusiness(INhaXuatBanRepository NhaXuatBanGroupRes)
        {
            _res = NhaXuatBanGroupRes;
        }
        //public bool Create(NhaXuatBanModel model)
        //{
        //    return _res.Create(model);
        //}
        //public NhaXuatBanModel GetDatabyID(string id)
        //{
        //    return _res.GetDatabyID(id);
        //}
        public List<NhaXuatBanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        //public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string ChuDe_group_id)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, ChuDe_group_id);
        //}
    }

}
