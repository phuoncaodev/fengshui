namespace fengshui.Entity.FluentConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using fengshui.Entity.Models;

    public class MobileNumberConfiguration : IEntityTypeConfiguration<MobileNumber>
    {
        public void Configure(EntityTypeBuilder<MobileNumber> builder)
        {
            builder.ToTable("MobileNumbers");
            
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasIndex(i => i.PhoneNumber).IsUnique(true);
            builder.Property(p => p.ServiceProvider).HasMaxLength(30);
        }
    }
}
