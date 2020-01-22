namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int TaskId { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskName { get; set; }

        public bool Progress { get; set; }

        public DateTime DueDate { get; set; }

        public int PriorityId { get; set; }

        public int TaskListId { get; set; }

        public virtual Priority Priority { get; set; }

        public virtual TaskList TaskList { get; set; }
    }
}
