namespace VSCode.Memo.Domain.Exceptions
{
    public class InputException : Exception
    {
        public InputException(string message) : base(message)
        {
        }
    }
}