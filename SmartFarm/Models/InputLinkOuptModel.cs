using System;

namespace SmartFarm.Models
{
    public class InputLinkOuptModel
    {
        public int idOutput { get; set; }
        public int idInput { get; set; }
        public string loaiThietBiInput { get; set;}
        public string feedName { get; set; }
        public TimeSpan timeSet { get;  set; }
        public float nguongMax{get; set; }
        public float nguongMin{get; set; }
    }
}