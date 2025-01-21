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
    public class DOCUMENTO_UPLOAD_DIPENDENTE_Configuration : IEntityTypeConfiguration<DOCUMENTO_UPLOAD_DIPENDENTE>
    {
        public void Configure(EntityTypeBuilder<DOCUMENTO_UPLOAD_DIPENDENTE> builder)
        {
            builder.HasKey(cp => new { cp.ID, cp.DIPENDENTE });

            builder.HasOne(x => x.Document)
                .WithMany(x => x.DOCUMENTO_UPLOAD_DIPENDENTEs)
                .HasForeignKey(x => x.ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Anag)
                .WithMany(x => x.DOCUMENTO_UPLOAD_DIPENDENTEs)
                .HasForeignKey(x => x.DIPENDENTE)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
