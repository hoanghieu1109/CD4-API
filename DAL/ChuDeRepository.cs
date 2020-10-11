using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ChuDeRepository : IChuDeRepository
    {
        private IDatabaseHelper _dbHelper;
        public ChuDeRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        //public bool Create(ChuDeModel model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ChuDe_get_data",
        //        "@MaChuDe", model.MaChuDe,
        //        "@TenChuDe", model.TenChuDe,
        //        "@GiaBan", model.GiaBan,
        //        "@ChuDe_name", model.ChuDe_name,
        //        "@ChuDe_price", model.ChuDe_price);
        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public ChuDeModel GetDatabyID(string id)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ChuDe_get_by_id",
        //             "@ChuDe_id", id);
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        return dt.ConvertTo<ChuDeModel>().FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<ChuDeModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_chude_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChuDeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<ChuDeModel> Search(int pageIndex, int pageSize, out long total, string ChuDe_group_id)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ChuDe_get_data",
        //            "@page_index", pageIndex,
        //            "@page_size", pageSize,
        //            "@ChuDe_group_id", ChuDe_group_id);
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<ChuDeModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
