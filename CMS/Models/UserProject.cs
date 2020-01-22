namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProject")]
    public partial class UserProject
    {
        public int UserProjectId { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public bool? SharedFlag { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
