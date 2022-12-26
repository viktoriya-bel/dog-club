using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Group
    {
        [Key]
        public int id { get; } // первичный ключ
        public int nameGroup { set; get; }

        public List<Breed> Breeds { set; get; }
    }
}
