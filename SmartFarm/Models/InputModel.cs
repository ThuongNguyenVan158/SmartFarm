using System;

namespace SmartFarm.Models
{
    public class InputModel
    {
        public String loaiThietBi { get; set; }
        public String feedName { get; set; }
        public int id { get; set; }
        public int thuocVeTrangTrai { get; set; }
        public string name { get; set; }
        public string thongTin { get; set; }
        public string viTri { get; set; }
        public String image{ get; set;}
        public TimeSpan timeSet { get;  set; }
        public float nguongMax{get; set; }
        public string donVi{get; set; }
        public float nguongMin{get; set; }
        public int secondTime { get; set; }
        public string AioKey { get; set; }
        public string DrawFunction { get; set; }
        public int typeChart { get; set; }
    }
}