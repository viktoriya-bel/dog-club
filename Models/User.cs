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
        public int id { get; set; } // первичный ключ
        public string userName { set; get; }
        public string password { set; get; }
        public int? RoleId { set; get; } // внешний ключ к таблице "Роли"

        public Role Role { set; get; }
    }
}
