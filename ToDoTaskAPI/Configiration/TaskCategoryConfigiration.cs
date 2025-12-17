using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTaskAPI.Models;

namespace ToDoTaskAPI.Configiration
{
    public class TaskCategoryConfigiration : IEntityTypeConfiguration<TaskCategory>
    {
        public void Configure(EntityTypeBuilder<TaskCategory> builder)
        {
            builder.Property(w => w.CreatedAt)
                            .HasDefaultValue(DateTime.Now);


            builder.Property(w => w.Name)
                            .IsRequired()
                            .HasMaxLength(50);
        }
    }
}
