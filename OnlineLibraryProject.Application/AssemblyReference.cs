﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(Assembly).Assembly;
    }
}
