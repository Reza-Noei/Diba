using System;

namespace Diba.Core.WebApi.Internal
{
    public class ScopeAttribute : Attribute
    {
        public ScopeAttribute(string name)
        {
            Name = name;   
        }

        public string Name { get; set; }
    }
}