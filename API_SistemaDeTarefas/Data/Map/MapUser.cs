using API_SistemaDeTarefas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_SistemaDeTarefas.Data.Map
{
    public class MapUser : IEntityTypeConfiguration<UserModel>
    {

        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        }
    
    }
}
