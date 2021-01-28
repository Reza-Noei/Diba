namespace Diba.Core.Domain.Products.ProductConstraints
{
    public class Option:BaseEntity<int>
    {
        public int SelectiveConstraintId { get; set; }
        public virtual SelectiveConstraint SelectiveConstraint { get; set; }

        public string Value { get; set; }

        public int Key { get; set; }

        public Option(string value, int key)
        {
            Value = value;
            Key = key;
        }
    }
}