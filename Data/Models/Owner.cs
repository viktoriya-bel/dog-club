using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Models
{
    public class Owner
    {
        public int id { get; } // первичный ключ
        public string fullName { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
        public List<Dog> Dogs { set; get; } 
    }
}
