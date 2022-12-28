using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Breed
    {
        [Key]
        public int id { get; set; } // первичный ключ
        public int? GroupId { set; get; } //внешний ключ группа породы
        public string nameBreed { set; get; }
        public Group Group { set; get; }
    }
}
