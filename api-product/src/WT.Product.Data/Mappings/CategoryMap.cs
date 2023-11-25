using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WT.Product.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Entities.Category>
    {
        private const string TABLE_NAME = "Categories";

        public void Configure(EntityTypeBuilder<Entities.Category> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
