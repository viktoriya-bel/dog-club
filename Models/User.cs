using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class User
    {
        public int id { get; } // первичный ключ
        public string userName { set; get; }
        public string password { set; get; }
        public int roleId { set; get; } // внешний ключ к таблице "Роли"

        public virtual Role Role { set; get; }
    }
}
