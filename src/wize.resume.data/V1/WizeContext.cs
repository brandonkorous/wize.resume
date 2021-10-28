using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wize.common.tenancy.Interfaces;
using wize.resume.data.V1.Models;

namespace wize.resume.data.V1
{
    public class WizeContext : DbContext
    {
        private readonly ITenantProvider _tenantProvider;

        public WizeContext(DbContextOptions<WizeContext> options, ITenantProvider tenantProvider) : base(options)
        {
            _tenantProvider = tenantProvider;
            //this.ChangeTracker.AutoDetectChangesEnabled = false;
            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperienceTag>()
                .HasIndex(et => new { et.ExperienceId, et.TagId })
                .IsUnique()
                .HasName("Unique_Key_Relations");

            modelBuilder.Entity<Resume>()
                .HasIndex(r => r.SafeName)
                .HasName("UniqueKey_SafeName");

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Title)
                .HasName("UniqueKey_Title");

            modelBuilder = AddTenancy(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<ExperienceItem> ExperienceItems { get; set; }
        public virtual DbSet<ExperienceTag> ExperienceTags { get; set; }
        public virtual DbSet<Expertise> Expertises { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }

        #region Tenancy Handling
        private ModelBuilder AddTenancy(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>().Property<Guid>("TenantId");
            modelBuilder.Entity<Education>().Property<Guid>("TenantId");
            modelBuilder.Entity<Experience>().Property<Guid>("TenantId");
            modelBuilder.Entity<ExperienceItem>().Property<Guid>("TenantId");
            modelBuilder.Entity<ExperienceTag>().Property<Guid>("TenantId");
            modelBuilder.Entity<Expertise>().Property<Guid>("TenantId");
            modelBuilder.Entity<Project>().Property<Guid>("TenantId");
            modelBuilder.Entity<Resume>().Property<Guid>("TenantId");
            modelBuilder.Entity<Tag>().Property<Guid>("TenantId");
            modelBuilder.Entity<Volunteer>().Property<Guid>("TenantId");

            
            return modelBuilder;
        }

        public override TEntity Find<TEntity>(params object[] keyValues)
        {
            var model = base.Find<TEntity>(keyValues);
            var tenantId = _tenantProvider.GetTenantId();
            var modelTenantId = base.Entry(model).CurrentValues.GetValue<Guid>("TenantId");
            if (!tenantId.HasValue || modelTenantId != tenantId.Value)
                return default;

            return model;
        }

        public override object Find(Type entityType, params object[] keyValues)
        {
            var model = base.Find(entityType, keyValues);
            var tenantId = _tenantProvider.GetTenantId();
            var modelTenantId = base.Entry(model).CurrentValues.GetValue<Guid>("TenantId");
            if (!tenantId.HasValue || modelTenantId != tenantId.Value)
                return default;

            return model;
        }

        public override ValueTask<object> FindAsync(Type entityType, params object[] keyValues)
        {
            var model = base.FindAsync(entityType, keyValues);
            var tenantId = _tenantProvider.GetTenantId();
            var modelTenantId = base.Entry(model).CurrentValues.GetValue<Guid>("TenantId");
            if (!tenantId.HasValue || modelTenantId != tenantId.Value)
                return default;

            return model;
        }

        public override ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues)
        {
            var model = base.FindAsync<TEntity>(keyValues);
            var tenantId = _tenantProvider.GetTenantId();
            var modelTenantId = base.Entry(model).CurrentValues.GetValue<Guid>("TenantId");
            if (!tenantId.HasValue || modelTenantId != tenantId.Value)
                return default;

            return model;
        }

        public override ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken)
        {
            var model = base.FindAsync<TEntity>(keyValues, cancellationToken);
            var tenantId = _tenantProvider.GetTenantId();
            var modelTenantId = base.Entry(model).CurrentValues.GetValue<Guid>("TenantId");
            if (!tenantId.HasValue || modelTenantId != tenantId.Value)
                return default;

            return model;
        }

        public override ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken)
        {
            var model = base.FindAsync(entityType, keyValues, cancellationToken);
            var tenantId = _tenantProvider.GetTenantId();
            var modelTenantId = base.Entry(model).CurrentValues.GetValue<Guid>("TenantId");
            if (!tenantId.HasValue || modelTenantId != tenantId.Value)
                return default;

            return model;
        }

        public override int SaveChanges()
        {
            ApplyTenancy();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyTenancy();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyTenancy();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyTenancy();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyTenancy()
        {
            var modified = ChangeTracker.Entries<ITenantModel>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entity in modified)
            {
                var property = entity.Property("TenantId");
                if (property != null)
                {
                    property.CurrentValue = _tenantProvider.GetTenantId();
                }
            }
        }
        #endregion
    }
}
