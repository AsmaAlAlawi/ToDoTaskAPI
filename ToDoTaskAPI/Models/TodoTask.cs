using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTaskAPI.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime DeadTime { get; set; }
        public DateTime CreateAt { get; set; }


        [ForeignKey(nameof(TaskCategory))]
        public int TaskCategoryId { get; set; }
        public TaskCategory TaskCategory { get; set; }

        

    }
}
