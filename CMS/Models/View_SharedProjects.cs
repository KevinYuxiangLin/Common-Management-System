namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_SharedProjects
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProjectName { get; set; }

        public int? OwnerId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string OwnerName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Username { get; set; }
    }
}
