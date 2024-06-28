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

            //Doações
            builder
                .HasMany(d => d.Doacoes)
                .WithOne()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //Endereço
            builder
                 .OwnsOne(d => d.Endereco, e =>
                 {
                     e.Property(e => e.CEP).HasColumnName("CEP");
                     e.Property(e => e.Logradouro).HasColumnName("Logradouro");
                     e.Property(e => e.Bairro).HasColumnName("Bairro");
                     e.Property(e => e.Cidade).HasColumnName("Cidade");
                     e.Property(e => e.Numero).HasColumnName("Numero");
                     e.Property(e => e.Referencia).HasColumnName("Referencia");
                     
                 });
             
                
        }
    }
}
