using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface INhaXuatBanRepository
    {
        //bool Create(ItemModel model);
        //ItemModel GetDatabyID(string id);
        List<NhaXuatBanModel> GetDataAll();
        //List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
    }
}
