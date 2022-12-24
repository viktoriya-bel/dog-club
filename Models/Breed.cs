using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Breed
    {
        public int id { get; } // первичный ключ
        public int groupId { set; get; }
        public string nameBreed { set; get; }
        public virtual Group Group { set; get; }
    }
}
