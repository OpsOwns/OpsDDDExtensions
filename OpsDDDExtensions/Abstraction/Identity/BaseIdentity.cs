using OpsDDDExtensions.Interfaces;

namespace OpsDDDExtensions.Abstraction.Identity
{
    /// <summary>
    /// Default base Identity class as ulid
    /// </summary>
    public abstract record BaseIdentity<TId>(TId Value) : IIdentity
    {
        public override string ToString() => Value.ToString();
    }
}
