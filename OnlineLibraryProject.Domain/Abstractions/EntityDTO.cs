using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain.Abstractions
{
    public abstract record EntityDTO
    {
    }

    public abstract record EntityDTO<T> : EntityDTO
    {
        public T Id { get; set; }
    }
}
