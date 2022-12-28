using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class GroupsMock
    {
        public IEnumerable<Group> get()
        {
            return new List<Group>{
                new Group { nameGroup = "Нет группы" },
                new Group { nameGroup = "Пастушьи и скотогонные собаки, кроме швейцарских скотогонных собак" },
                new Group { nameGroup = "Пинчеры и шнауцеры, молоссы, горные собаки и швейцарские скотогонные собаки" },
                new Group { nameGroup = "Терьеры" },
                new Group { nameGroup = "Таксы" },
            };
        }
    }
}
