namespace Library.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
            : base("name=LibrarydbEntitiesConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Book { get; set; }
    }
}
