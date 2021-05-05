using System.Linq.Expressions;

namespace OpsDDDExtensions.Abstraction.Specification
{
    internal class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);
        internal ParameterReplacer(ParameterExpression parameter) => _parameter = parameter;
    }
}
