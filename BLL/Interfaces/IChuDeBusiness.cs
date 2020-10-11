using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IChuDeBusiness
    {
        //bool Create(ItemModel model);
        //ItemModel GetDatabyID(string id);
        List<ChuDeModel> GetDataAll();
        //List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
    }
}
