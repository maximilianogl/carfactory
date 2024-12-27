namespace CarFactory.Core.Application.Exceptions
{
    /// <summary>
    /// Custom exception for not found errors
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
