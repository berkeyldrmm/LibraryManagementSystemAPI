using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLibraryProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Persistance.Configurations
{
    public class UserBookBorrowConfiguration : IEntityTypeConfiguration<UserBookBorrow>
    {
        public void Configure(EntityTypeBuilder<UserBookBorrow> builder)
        {
            builder.ToTable("UserBookBorrows");
        }
    }
}
