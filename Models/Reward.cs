using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Reward
    {
        [Key]
        public int id { get; set; } // первичный ключ
        public string name { set; get; }
        public int? DogId { set; get; } //внешний ключ
        public DateTime date { set; get; }
    }
}
