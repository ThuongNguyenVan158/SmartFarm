using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class InputOutput
    {
        public int IdInput { get; set; }
        public int IdOutput { get; set; }
        public String LoaiThietBiInput { get; set; } 
        public Input Input{ get; set;}
        public Output Output { get; set; }
    }
}
