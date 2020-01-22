namespace CMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<_event> events { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskList> TaskLists { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<View_all> View_all { get; set; }
        public virtual DbSet<View_Projects> View_Projects { get; set; }
        public virtual DbSet<View_SharedProjects> View_SharedProjects { get; set; }
        public virtual DbSet<View_SharedProjects_Users> View_SharedProjects_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<_event>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.progress)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.priority)
                .IsUnicode(false);

            modelBuilder.Entity<Priority>()
                .Property(e => e.PriorityName)
                .IsUnicode(false);

            modelBuilder.Entity<Priority>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Priority)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.TaskLists)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.UserProjects)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskList>()
                .Property(e => e.TaskListName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskList>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.TaskList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserProjects)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<View_all>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<View_all>()
                .Property(e => e.TaskListName)
                .IsUnicode(false);

            modelBuilder.Entity<View_all>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<View_all>()
                .Property(e => e.Progress)
                .IsUnicode(false);

            modelBuilder.Entity<View_all>()
                .Property(e => e.PriorityName)
                .IsUnicode(false);

            modelBuilder.Entity<View_Projects>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<View_SharedProjects>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<View_SharedProjects>()
                .Property(e => e.OwnerName)
                .IsUnicode(false);

            modelBuilder.Entity<View_SharedProjects>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<View_SharedProjects_Users>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<View_SharedProjects_Users>()
                .Property(e => e.OwnerName)
                .IsUnicode(false);
        }
    }
}
