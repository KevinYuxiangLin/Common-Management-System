namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_all
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProjectName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskListId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string TaskListName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string TaskName { get; set; }

        [StringLength(11)]
        public string Progress { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime DueDate { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string PriorityName { get; set; }
    }
}
