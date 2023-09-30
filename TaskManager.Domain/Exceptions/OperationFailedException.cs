namespace TaskManager.Domain.Exceptions
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException() : base("Operation failed")
        {
            
        }

        public OperationFailedException(string message) : base(message)
        {
            
        }
    }
}
