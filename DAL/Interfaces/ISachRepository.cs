using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISachRepository
    {
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
        SachModel GetDatabyID(string id);
        NhaXuatBanModel GetNXBBYSACH(string id);
        ChuDeModel GetCDBYSACH(string id);
        List<SachModel> GetDataAll();
        List<SachModel> GetDataByChuDe(string MaChuDe);
        List<SachModel> phantrang(int pageIndex, int pageSize, out long total);
    }
}
