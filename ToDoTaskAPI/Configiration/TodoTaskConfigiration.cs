using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTaskAPI.Models;

namespace ToDoTaskAPI.Configiration
{
    public class TodoTaskConfigiration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(w => w.Name)
                            .IsRequired(true)
                            .HasMaxLength(50);
            builder.Property(w => w.CreateAt)
               .HasDefaultValue(DateTime.Now);

            builder.Property(w => w.IsCompleted)
                .HasDefaultValue(false)
                .IsRequired(false);
        }
    }
    }


