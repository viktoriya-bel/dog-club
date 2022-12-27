using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class OwnersMock
    {
        public IEnumerable<Owner> get()
        {
            return new List<Owner>{
                new Owner { fullName = "Касатый Савва Герасимович", address = "Россия, г. Арзамас, Западная ул., д. 9 кв.66", phone = "+7 (939) 235-59-86" },
                new Owner { fullName = "Ягункина Валентина Прохоровна", address = "Россия, г. Копейск, Солнечный пер., д. 20 кв.109", phone = "+7 (912) 261-34-19" },
                new Owner { fullName = "Гавриленко Серафим Аркадьевич", address = "Россия, г. Королёв, Интернациональная ул., д. 17 кв.12", phone = "+7 (947) 123-56-25" },
                new Owner { fullName = "Филипов Лев Георгиевич", address = "Россия, г. Подольск, Партизанская ул., д. 8 кв.167", phone = "+7 (937) 973-22-64" },
                new Owner { fullName = "Волков Петр Лукьевич", address = "Россия, г. Иркутск, Коммунистическая ул., д. 17 кв.67", phone = "+7 (951) 375-79-54" },
            };
        }
    }
}
