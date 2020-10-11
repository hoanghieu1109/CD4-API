using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class SachRepository : ISachRepository
    {
        private IDatabaseHelper _dbHelper;
        public SachRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        //public bool Create(SachModel model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sach_get_data",
        //        "@MaSach", model.MaSach,
        //        "@TenSach", model.TenSach,
        //        "@GiaBan", model.GiaBan,
        //        "@Sach_name", model.Sach_name,
        //        "@Sach_price", model.Sach_price);
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
        public SachModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sach_get_by_id",
                     "@MaSach", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SachModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SachModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sach_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SachModel> phantrang(int pageIndex, int pageSize, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "phantrang",
                    "@page_index", pageIndex,
                    "@page_size", pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<SachModel> Search(int pageIndex, int pageSize, out long total, string Sach_group_id)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sach_get_data",
        //            "@page_index", pageIndex,
        //            "@page_size", pageSize,
        //            "@Sach_group_id", Sach_group_id);
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<SachModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
