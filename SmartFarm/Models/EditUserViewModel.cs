using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Models
{
    public class EditUserViewModel
    {
        [Required()]
        public string ImgUrl { get; set; }
        [Required()]
        public string UserName { get; set; }
        [Required()]
        public string Password { get; set; }
        [Required()]
        public string RePassword { get; set; }
        [Required()]
        public string Ten { get; set; }
        [Required()]
        public string Ho { get; set; }
        [Required()]
        public string Email { get; set; }
        [Required()]
        public string Address { get; set; }
    }
}
