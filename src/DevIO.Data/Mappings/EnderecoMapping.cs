using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        private delegate string PropriedadeEndereco(Endereco endereco);
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property((e) => e.Bairro)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property((e) => e.Numero)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property((e) => e.Complemento)
                .HasColumnType("varchar(50)");

            builder.Property((e) => e.Cep)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property((e) => e.Bairro)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property((e) => e.Cidade)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property((e) => e.Estado)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.ToTable("Enderecos");
        }
    }
}
