using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Models
{
    public class EquipmentViewModel
    {
        public string loaiThietBi { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int thuocVeTrangTrai { get; set; }
        public string thongTin { get; set; }
        public string viTri { get; set; }
        public string image { get; set; }
        public bool trangThai { get; set; }
    }
}
