using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
    public class GPSctx: DbContext
    {
        public DbSet<CF_Formacion> CF_Formacion { get; set; }
        public DbSet<CF_Version> CF_Version { get; set; }
        public DbSet<CF_PaginaContent> CF_PaginaContent { get; set; }
        public DbSet<CF_Evaluacion> CF_Evaluacion { get; set; }
        public DbSet<CF_EvaluacionVersion> CF_EvaluacionVersion { get; set; }
        public DbSet<CF_EvaluacionSeccion> CF_EvaluacionSeccion { get; set; }
        public DbSet<CF_EvaluacionPreg> CF_EvaluacionPreg { get; set; }
        public DbSet<CF_EvaluacionPregRes> CF_EvaluacionPregRes { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public GPSctx(DbContextOptions<GPSctx> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
