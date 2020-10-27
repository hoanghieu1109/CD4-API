using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class KhachHangRepository : IKhachHangRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhachHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khachhang_create",
                "@MaKH", model.MaKH,
                "@HoTen", model.HoTen,
                "@TaiKhoan",model.TaiKhoan,
                "@MatKhau", model.MatKhau,
                "@Email", model.Email,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
