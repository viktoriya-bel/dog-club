﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class Owner
    {
        [Key]
        public int id { get; set; } // первичный ключ
        public string fullName { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
        //public List<Dog> Dogs { set; get; } 
    }
}
