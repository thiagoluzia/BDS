using BDS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDS.Infrastructure.Persistences.Configurations
{
    public class DoadorConfiguration : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(d => d.Doacoes)
                .WithOne()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Endereco)
                .WithMany()
                .HasForeignKey(e => e.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
