using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class Farm
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string DiaDiem { get; set; }
        public string AioKey { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Equipment> Equipments { get; set; }
    }
}
