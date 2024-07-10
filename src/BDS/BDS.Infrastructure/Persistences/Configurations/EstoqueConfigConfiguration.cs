using BDS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDS.Infrastructure.Persistences.Configurations
{
    public class EstoqueConfigConfiguration : IEntityTypeConfiguration<EstoqueConfig>
    {
        public void Configure(EntityTypeBuilder<EstoqueConfig> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
