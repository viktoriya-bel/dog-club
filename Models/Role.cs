using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; } // первичный ключ
        public string name { set; get; }
        public Boolean isAdmin { set; get; }
        public List<string> unavailableModules { set; get; } // необходимо выпилить

        //public List<User> Users { set; get; } // нужен ли список юзеров данной роли???
    }
}
