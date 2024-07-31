using fristMVCDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace fristMVCDAL.Data.Configrations
{
    internal class EmployeeConfigrations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E=>E.Id).IsRequired().UseIdentityColumn(1, 1);
            builder.Property(E => E.FName).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(E => E.LName).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(E => E.Title).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(E => E.Age).IsRequired().HasMaxLength(50).HasColumnType("integer");
            builder.Property(E => E.Address).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
        }
    }
}
