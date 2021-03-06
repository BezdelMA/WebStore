﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LevelEducation { get; set; }
        public DateTime StartOfWork { get; set; }

        public override string ToString()
        {
            return string.Format($"{Surname} {Name} {Age} {LevelEducation} {StartOfWork.ToShortDateString()}");
        }
    }
}
