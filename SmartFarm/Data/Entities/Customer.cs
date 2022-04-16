using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class Customer : IdentityUser<Guid>
    {
        public string Ten { get; set; }
        public string Ho { get; set; }
        public string DiaChi { get; set; }
        public int SoHuuTrangTrai { get; set; }
        public string VaiTro { get; set; }
        public bool TrangThai { get; set; }
        public string Image { get; set; }
        public Farm Farm { get; set; }
        
    }
}
