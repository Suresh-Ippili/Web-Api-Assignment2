using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApi.Models
{
    public class SubTask
    {
        [Key]
        public int SubTaskId { get; set; }

        [Required]
        public string SubTaskName { get; set; }

        public string SubTaskDescription { get; set; }

        [ForeignKey("Task")]
        public int TaskID { get; set; }

        public Task Task { get; set; }
    }
}
