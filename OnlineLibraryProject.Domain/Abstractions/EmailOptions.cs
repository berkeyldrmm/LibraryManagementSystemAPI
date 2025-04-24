﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain.Abstractions
{
    public abstract class EmailOptions
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
