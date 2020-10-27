using System;
using System.Collections.Generic;

namespace Model
{
    public class SachModel
    {
        public string masach { get; set; }
        public string tensach { get; set; }
        public string giaban { get; set; }
        public string mota { get; set; }
        public string anhbia { get; set; }
        public int soluongton { get; set; }
        public string manxb { get; set; }
        public string machude { get; set; }

        public NhaXuatBanModel NXB { get; set; }
        public ChuDeModel CD { get; set; }


    }
}
