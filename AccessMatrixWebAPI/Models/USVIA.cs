namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class USVIA : DbContext
    {
        public USVIA()
            : base("name=USVIAContext")
        {
        }

        public virtual DbSet<CLT_PNT_ORG> CLT_PNT_ORG { get; set; }
        public virtual DbSet<CLT> CLTS { get; set; }
        public virtual DbSet<DEPT> DEPTS { get; set; }
        public virtual DbSet<DOMAIN> DOMAINS { get; set; }
        public virtual DbSet<JOB> JOBS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<OU> OUS { get; set; }
        public virtual DbSet<PRJ> PRJS { get; set; }
        public virtual DbSet<PROFILE_ASSIGNMENTS> PROFILE_ASSIGNMENTS { get; set; }
        public virtual DbSet<PROFILE_OU> PROFILE_OU { get; set; }
        public virtual DbSet<PROFILE_SEC_GRP> PROFILE_SEC_GRP { get; set; }
        public virtual DbSet<PROFILE> PROFILES { get; set; }
        public virtual DbSet<PROG> PROGS { get; set; }
        public virtual DbSet<SEC_GRPS> SEC_GRPS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<AUD_PROFILE_ASSGS> AUD_PROFILE_ASSGS { get; set; }
        public virtual DbSet<AUD_PROFILE_OU> AUD_PROFILE_OU { get; set; }
        public virtual DbSet<AUD_PROFILE_SEC_GRP> AUD_PROFILE_SEC_GRP { get; set; }
        public virtual DbSet<AUD_PROFILES> AUD_PROFILES { get; set; }
        public virtual DbSet<STG_CLT_PNT_ORG> STG_CLT_PNT_ORG { get; set; }
        public virtual DbSet<STG_CLTS> STG_CLTS { get; set; }
        public virtual DbSet<STG_DEPTS> STG_DEPTS { get; set; }
        public virtual DbSet<STG_JOBS> STG_JOBS { get; set; }
        public virtual DbSet<STG_LOCATIONS> STG_LOCATIONS { get; set; }
        public virtual DbSet<STG_OUS> STG_OUS { get; set; }
        public virtual DbSet<STG_PRJS> STG_PRJS { get; set; }
        public virtual DbSet<STG_PROGS> STG_PROGS { get; set; }
        public virtual DbSet<STG_SEC_GRPS> STG_SEC_GRPS { get; set; }
        public virtual DbSet<V_PROFILE_D> V_PROFILE_D { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<CLT_PNT_ORG>()
                .HasMany(e => e.CLTS)
                .WithRequired(e => e.CLT_PNT_ORG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<CLT>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithOptional(e => e.CLT)
                .HasForeignKey(e => new { e.CLT_PNT_ORG_CD, e.GL_CLT_CD });

            modelBuilder.Entity<CLT>()
                .HasMany(e => e.PROGS)
                .WithRequired(e => e.CLT)
                .HasForeignKey(e => new { e.CLT_PNT_ORG_CD, e.GL_CLT_CD })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.GL_DEPT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithRequired(e => e.DEPT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.DN)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<DOMAIN>()
                .HasMany(e => e.OUS)
                .WithRequired(e => e.DOMAIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOMAIN>()
                .HasMany(e => e.PROFILES)
                .WithRequired(e => e.DOMAIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOMAIN>()
                .HasMany(e => e.SEC_GRPS)
                .WithRequired(e => e.DOMAIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.JOB_CD)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithRequired(e => e.JOB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.LOC_CD)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithRequired(e => e.LOCATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.DN)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<OU>()
                .HasMany(e => e.PROFILE_OU)
                .WithRequired(e => e.OU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.PRJ_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PRJ>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithOptional(e => e.PRJ)
                .HasForeignKey(e => new { e.CLT_PNT_ORG_CD, e.GL_CLT_CD, e.PROG_CD, e.PRJ_CD });

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.LOC_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.JOB_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.GL_DEPT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.COMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_ASSIGNMENTS>()
                .Property(e => e.PRJ_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_OU>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_OU>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_OU>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_OU>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_SEC_GRP>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_SEC_GRP>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_SEC_GRP>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE_SEC_GRP>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.SHARED_FLAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.COMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.SMTP_DISTRO)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.EMAIL_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.PREFERRED_SMTP)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.EMAIL_FWD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.COMMUNICATOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.COMM_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.VPN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.WEBMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.SHARED_DRIVE)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.BOX_ACCNT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithRequired(e => e.PROFILE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROFILE>()
                .HasMany(e => e.PROFILE_OU)
                .WithRequired(e => e.PROFILE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROFILE>()
                .HasMany(e => e.PROFILE_SEC_GRP)
                .WithRequired(e => e.PROFILE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<PROG>()
                .HasMany(e => e.PRJS)
                .WithRequired(e => e.PROG)
                .HasForeignKey(e => new { e.CLT_PNT_ORG_CD, e.GL_CLT_CD, e.PROG_CD })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROG>()
                .HasMany(e => e.PROFILE_ASSIGNMENTS)
                .WithOptional(e => e.PROG)
                .HasForeignKey(e => new { e.CLT_PNT_ORG_CD, e.GL_CLT_CD, e.PROG_CD });

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.DN)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<SEC_GRPS>()
                .HasMany(e => e.PROFILE_SEC_GRP)
                .WithRequired(e => e.SEC_GRPS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.LOC_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.JOB_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.GL_DEPT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.CRT_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.CRT_USR)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.EVENT_TYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.COMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_ASSGS>()
                .Property(e => e.PRJ_CD)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_OU>()
                .Property(e => e.CRT_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_OU>()
                .Property(e => e.CRT_USR)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_OU>()
                .Property(e => e.EVENT_TYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_SEC_GRP>()
                .Property(e => e.CRT_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_SEC_GRP>()
                .Property(e => e.CRT_USR)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILE_SEC_GRP>()
                .Property(e => e.EVENT_TYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.CRT_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.CRT_USR)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.EVENT_TYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.COMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.SMTP_DISTRO)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.EMAIL_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.PREFERRED_SMTP)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.EMAIL_FWD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.COMMUNICATOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.COMM_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.VPN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.WEBMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.SHARED_DRIVE)
                .IsUnicode(false);

            modelBuilder.Entity<AUD_PROFILES>()
                .Property(e => e.BOX_ACCNT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLT_PNT_ORG>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_CLTS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.GL_DEPT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_DEPTS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.JOB_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_JOBS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.LOC_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_LOCATIONS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.DN)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_OUS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.PRJ_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PRJS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.CLT_PNT_ORG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.DESC_SHRT)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.DESC_LNG)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_PROGS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.DN)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.LD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.LD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.LST_UPD_PROC)
                .IsUnicode(false);

            modelBuilder.Entity<STG_SEC_GRPS>()
                .Property(e => e.LST_UPD_USR)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.PROFILE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.PROFILE_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.PROFILE_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.DOMAIN_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.DOMAIN_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.DOMAIN_DN)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.DOMAIN_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.JOB_CD)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.JOB_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.JOB_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.LOC_CD)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.LOC_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.LOC_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.GL_CLT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.GL_CLT_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.GL_CLT_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.GL_DEPT_CD)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.GL_DEPT_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.GL_DEPT_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.PROG_CD)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.PROG_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.PROG_ACTV_FLG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_PROFILE_D>()
                .Property(e => e.SHARED_FLAG)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
