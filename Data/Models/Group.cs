using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Models
{
    public class Group
    {
        public int id { get; } // первичный ключ
        public int nameGroup { set; get; }

        public List<Breed> Breeds { set; get; }
    }
}
