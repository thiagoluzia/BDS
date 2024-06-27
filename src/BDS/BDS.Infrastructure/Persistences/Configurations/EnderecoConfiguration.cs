using BDS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDS.Infrastructure.Persistences.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {

            builder.HasKey(x => x.Id);

            builder
                .HasOne(e => e.Doador)
                .WithMany()
                .HasForeignKey(e => e.DoadorID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
