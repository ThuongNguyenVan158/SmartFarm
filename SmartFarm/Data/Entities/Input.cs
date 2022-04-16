using System;
using System.Collections.Generic;

namespace SmartFarm.Data.Entities
{
    public class Input
    {
        public int Id { get; set; }
        public string LoaiThietBi { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
        public TimeSpan ThoiGianTruyXuat { get; set; }
        public string DonVi{ get; set;}
        public String FeedName { get; set; }
        public Equipment Equipment { get; set; }
        public List<InputOutput> InputOutputs { get; set; }
        public bool Calculator { get; set; }
    }
}
