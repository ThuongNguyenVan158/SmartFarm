using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Models
{
    public class InsertEquipmentViewModel
    {
        public string loaiThietBi { get; set; }
        public string nameIn { get; set; }
        public string nameOut { get; set; }
        public int id { get; set; }
        public int thuocVeTrangTrai { get; set; }
        public string thongTin { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string image { get; set; }
        public bool trangThai { get; set; }
        public int idOutput { get; set; }
    }
}
