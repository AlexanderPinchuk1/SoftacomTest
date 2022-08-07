namespace Library.Repositories
{
    public class LibraryUnitOfWork : UnitOfWork
    {
        public LibraryUnitOfWork(LibraryDbContext libraryDbContext)
            : base(libraryDbContext)
        {
        }
    }
}