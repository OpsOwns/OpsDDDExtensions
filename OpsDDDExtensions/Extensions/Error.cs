namespace OpsDDDExtensions.Extensions
{
    /// <summary>
    /// Error base class
    /// </summary>
    public class Error
    {
        public string Message { get; }
        public Error(string message)
        {
            Message = message;
        }
    }
}
