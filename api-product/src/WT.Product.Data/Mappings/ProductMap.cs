using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WT.Product.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Entities.Product>
    {
        private const string TABLE_NAME = "Products";

        public void Configure(EntityTypeBuilder<Entities.Product> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.Name).IsRequired();
        }
    }
}
