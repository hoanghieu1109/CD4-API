using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INhaXuatBanBusiness
    {
        //bool Create(ItemModel model);
        //ItemModel GetDatabyID(string id);
        List<NhaXuatBanModel> GetDataAll();
        //List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
    }
}
