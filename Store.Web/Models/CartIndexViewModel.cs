﻿using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public String ReturnUrl { get; set; }
    }
}