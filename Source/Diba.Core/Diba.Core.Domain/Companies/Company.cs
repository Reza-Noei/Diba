using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Company
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public Company(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}