using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISachRepository
    {
        //bool Create(ItemModel model);
        //ItemModel GetDatabyID(string id);
        List<SachModel> GetDataAll();
        List<SachModel> phantrang(int pageIndex, int pageSize, out long total);
    }
}
