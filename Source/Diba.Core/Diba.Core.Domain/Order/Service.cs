namespace Diba.Core.Domain
{
    public abstract class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public abstract void AcceptVisitor(IServiceVisitor visitor);
        protected Service(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}