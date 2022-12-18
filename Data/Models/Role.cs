using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Models
{
    public class Role
    {
        public int id { get; } // первичный ключ
        public string name { set; get; }
        public Boolean isAdmin { set; get; }
        public List<string> availableModules { set; get; } // список доступных блоков для пользователя

        public List<User> Users { set; get; } // нужен ли список юзеров данной роли???
    }
}
