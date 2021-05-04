using System;

namespace OpsDDDExtensions.Abstraction
{
    public abstract record Identity(Guid Value)
    {
        public override string ToString()
        {
            return Value.ToString();
        }
    }

}
