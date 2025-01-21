using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations
{
    public class DOCUMENTO_UPLOAD_Configuration : IEntityTypeConfiguration<DOCUMENTO_UPLOAD>
    {
        public void Configure(EntityTypeBuilder<DOCUMENTO_UPLOAD> builder)
        {
            builder.HasKey(x => x.ID);
        }
    }
}
