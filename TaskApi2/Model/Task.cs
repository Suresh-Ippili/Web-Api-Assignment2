using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApi.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string TaskName { get; set; }

        public string Description { get; set; }
        public int Duration { get; set; }

        [Required]
        public string AssignedBy { get; set; }

        public ICollection<SubTask> SubTasks { get; set; }
    }
}
