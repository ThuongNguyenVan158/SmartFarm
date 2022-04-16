using System;

namespace SmartFarm.Models{
    public class OutputModel {
        public int valueOpen { get; set; }
        public int id{ get; set;}
        public bool trangThaiHoatDong { get; set; }
        public String feedName{ get; set; }
        public String name{ get; set; }
        public int thuocVeTrangTrai{ get; set;}
        public bool trangThai{get; set; }
        public String viTri { get; set; }
        public String img { get; set; }
        public int idInput{ get; set;}
        public string loaiThietBi { get; set; }
        public bool auto{ get;  set;}
        public InputLinkOuptModel inputOupts { get;  set; }
        public string AioKey { get; set; }
        public int auto1{ get; set; }
    }
}