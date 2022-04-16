using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Models
{
    public class EditEquipmentViewModel
    {
        public int id { get; set; }
        public string thongTin { get; set; }
        public string loai { get; set; }
        public string viTri { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public int idOutput { get; set; }
        public List<GetOutputViewModel> output { get; set; }
    }
}
