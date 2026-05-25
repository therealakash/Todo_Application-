

namespace Todo_assginment.custom_exceptions
{ 
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}