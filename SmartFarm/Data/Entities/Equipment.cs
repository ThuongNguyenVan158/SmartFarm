using System;
using System.Collections.Generic;

namespace SmartFarm.Data.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public int ThuocVeTrangTrai { get; set; }
        public String Image{ get; set;}
        public bool TrangThai { get; set; }
        public string ViTriDat { get; set; }
        public string ThongTin { get; set; }
        public Farm Farm { get; set; }
        public List<Input> Input { get; set; }
        public Output Output { get; set; }
    }
}
