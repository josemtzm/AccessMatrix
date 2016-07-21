namespace AccessMatrixWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OracleContext : DbContext
    {
        public OracleContext()
            : base("name=OracleContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<t_clients> t_clients { get; set; }
        public virtual DbSet<t_clients_and_projects> t_clients_and_projects { get; set; }
        public virtual DbSet<t_departments> t_departments { get; set; }
        public virtual DbSet<t_departments_and_roles> t_departments_and_roles { get; set; }
        public virtual DbSet<t_locations> t_locations { get; set; }
        public virtual DbSet<t_matrix> t_matrix { get; set; }
        public virtual DbSet<t_oracledata_import_> t_oracledata_import_ { get; set; }
        public virtual DbSet<t_programs> t_programs { get; set; }
        public virtual DbSet<t_projects> t_projects { get; set; }
        public virtual DbSet<t_roles> t_roles { get; set; }
        public virtual DbSet<vw_access_matrix> vw_access_matrix { get; set; }
        public virtual DbSet<vw_admap_reference> vw_admap_reference { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.Region)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.ClientID)
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.ProgramID)
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.ProjectID)
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.DepartmentID)
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.JobFamily)
                .IsUnicode(false);

            modelBuilder.Entity<t_oracledata_import_>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<t_programs>()
                .Property(e => e.ProgramID)
                .IsUnicode(false);

            modelBuilder.Entity<t_roles>()
                .Property(e => e.JobFamily)
                .IsUnicode(false);
        }
    }
}
