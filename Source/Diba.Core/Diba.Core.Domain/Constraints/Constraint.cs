namespace Diba.Core.Domain.Constraints
{
    public class Constraint : BaseEntity<int>
    {
        public string Title { get; private set; }

        public Constraint(string title)
        {
            Title = title;
        }
    }
}