﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return StudentId + ": " + StudentName;
        }
    }
}
