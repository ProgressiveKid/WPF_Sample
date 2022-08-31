﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class User
    {
        public int Rank { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }

        public User(string username, int steps)
        {
            this.UserName = username;
            this.Steps = steps;
        
        }
    }
}
