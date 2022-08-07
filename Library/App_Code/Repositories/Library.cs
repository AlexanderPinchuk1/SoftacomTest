namespace Library.Repositories
{
    public partial class Book
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public System.DateTime PublishingDate { get; set; }
    }
}
