using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_SistemaDeTarefas.Models;

namespace API_SistemaDeTarefas.Data.Map
{
    public class MapTodo : IEntityTypeConfiguration<TodoModel>
    {
        
        public void Configure(EntityTypeBuilder<TodoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x=> x.Description).HasMaxLength(100);
            builder.Property(x=> x.Status).IsRequired();
            builder.Property(x => x.Usuario);

            builder.HasOne(x => x.Usuario);
        }
    }
}
