using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Dog
    {
        [Key]
        public int id { get; } // первичный ключ
        public string name { set; get; }
        public int ownerId { set; get; }
        public DateTime dateBirth { set; get; }
        public DateTime dateDeath { set; get; }
        public string gender { set; get; }
        public int breedsId { set; get; }
        public int motherId { set; get; }
        public int fatherId { set; get; }

        public virtual Owner Owner { set; get; }
        public virtual Breed Breed { set; get; }
        public virtual Dog Mother { set; get; }
        public virtual Dog Father { set; get; }
    }
}
