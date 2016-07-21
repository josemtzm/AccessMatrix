namespace AccessMatrixWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccessMatrixContext : DbContext
    {
        public AccessMatrixContext()
            : base("name=AccessMatrixContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<t_chat> t_chat { get; set; }
        public virtual DbSet<t_companies> t_companies { get; set; }
        public virtual DbSet<t_descriptions> t_descriptions { get; set; }
        public virtual DbSet<t_domains> t_domains { get; set; }
        public virtual DbSet<t_emaildomains> t_emaildomains { get; set; }
        public virtual DbSet<t_permissions> t_permissions { get; set; }
        public virtual DbSet<t_vpn> t_vpn { get; set; }
        public virtual DbSet<t_workbooth> t_workbooth { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_chat>()
                .Property(e => e.ChatName)
                .IsUnicode(false);

            modelBuilder.Entity<t_companies>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<t_descriptions>()
                .Property(e => e.DescriptionID)
                .IsUnicode(false);

            modelBuilder.Entity<t_descriptions>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<t_domains>()
                .Property(e => e.DomainName)
                .IsUnicode(false);

            modelBuilder.Entity<t_domains>()
                .Property(e => e.DomainAddress)
                .IsUnicode(false);

            modelBuilder.Entity<t_emaildomains>()
                .Property(e => e.EmailName)
                .IsUnicode(false);

            modelBuilder.Entity<t_emaildomains>()
                .Property(e => e.EmailDomain)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.OU)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.LogonScript)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.ProfileDrive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.ProfilePath)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.Membership)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.GroupSMTP)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.ApprovalStatus)
                .IsUnicode(false);

            modelBuilder.Entity<t_permissions>()
                .Property(e => e.ApprovedBy)
                .IsUnicode(false);

            modelBuilder.Entity<t_vpn>()
                .Property(e => e.VpnName)
                .IsUnicode(false);

            modelBuilder.Entity<t_workbooth>()
                .Property(e => e.WorkboothName)
                .IsUnicode(false);
        }
    }
}
