﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public class Organization
    {
        private string Name;
        private Catalog catalog;

        public Catalog GetCatalog()
        {
            return catalog;
        }
    }
}
