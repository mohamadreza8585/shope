﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BEE
{
   public  class Order
    {
        public int Id { get; set; }
        public float totalpric { get; set; }
        public string userid { get; set; }
        public User user { get; set; }
        public List<Order_cours> cours { get; set; }

    }
    
}
