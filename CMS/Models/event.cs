namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("event")]
    public partial class _event
    {
        [Key]
        public int event_id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        public DateTime? event_start { get; set; }

        public DateTime? event_end { get; set; }

        public int? tasklist_id { get; set; }

        [StringLength(20)]
        public string progress { get; set; }

        [StringLength(10)]
        public string priority { get; set; }

        public int? task_id { get; set; }
    }
}
