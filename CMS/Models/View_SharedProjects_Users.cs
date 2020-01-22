namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_SharedProjects_Users
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
        [StringLength(50)]
        public string OwnerName { get; set; }

        public int? OwnerId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public string SharedByUsers { get; set; }
    }
}
