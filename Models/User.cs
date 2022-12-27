using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class User
    {
        [Key]
        public int id { get; private set; } // первичный ключ
        public string userName { set; get; }
        public string password { set; get; }
        public int roleId { set; get; } // внешний ключ к таблице "Роли"

        //public virtual Role Role { set; get; }
    }
}
