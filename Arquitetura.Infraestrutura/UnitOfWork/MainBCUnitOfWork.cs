using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Arquitetura.Infraestrutura.Base;
using Arquitetura.Infraestrutura.UnitOfWork.Mapping;
using Arquitetura.Dominio.Aggregates.PessoaAgg;


namespace Arquitetura.Infraestrutura.UnitOfWork
{
    public class MainBCUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        #region Membros de IDbSet

        DbSet<Pessoa> usuario { get; set; }

        #endregion

        #region Membros de IQueryableUnitOfWork

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            //attach and set as unchanged
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            //this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }

        public void DeleteObject<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry<TEntity>(item).State = EntityState.Deleted;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #region Sobreposições de DbContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Add entity configurations in a structured way using 'TypeConfiguration’ classes
            modelBuilder.Configurations.Add(new PessoaEntityConfiguration());
            modelBuilder.Configurations.Add(new MunicipioEntityConfiguration());
        }

        #endregion
    }
}
