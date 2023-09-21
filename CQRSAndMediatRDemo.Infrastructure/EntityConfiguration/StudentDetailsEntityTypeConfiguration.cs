using CQRSAndMediatRDemo.Infrastructure.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSAndMediatRDemo.Infrastructure.EntityConfiguration
{
    public class StudentDetailsEntityTypeConfiguration : IEntityTypeConfiguration<StudentDetails>
    {
        public void Configure(EntityTypeBuilder<StudentDetails> builder)
        {
            builder.ToTable("StudentDetails", DbContextClass.Default_schema);
            builder.HasKey(o => o.Id);



            builder
               .Property<string?>("StudentName")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .IsRequired(false);



            builder
               .Property<string?>("StudentEmail")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .IsRequired(false);



            builder
               .Property<string?>("StudentAddress")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .IsRequired(false);



            builder
               .Property<int?>("StudentAge")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .IsRequired(false);
        }
    }
}
