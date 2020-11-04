﻿using Model;
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
        SachModel GetDatabyID(int id);
        NhaXuatBanModel GetNXBBYSACH(int id);
        ChuDeModel GetCDBYSACH(int id);
        List<SachModel> GetDataAll();
        List<SachModel> GetDataByChuDe(string MaChuDe);
        List<SachModel> phantrang(int pageIndex, int pageSize, out long total, string tensach, string giaban);
    }
}
