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
    public class ANAGDIP_Configuration : IEntityTypeConfiguration<ANAGDIP>
    {
        public void Configure(EntityTypeBuilder<ANAGDIP> builder)
        {
            builder.HasKey(cp => new { cp.ENTE, cp.PROGRESSIVO });
        }
    }
}
