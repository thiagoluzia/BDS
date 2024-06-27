using BDS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDS.Infrastructure.Persistences.Configurations
{
    public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Doador)
                .WithMany(e => e.Doacoes)
                .HasForeignKey(d => d.DoadorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
