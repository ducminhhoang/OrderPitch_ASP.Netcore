namespace OrderFootballPitch.CustomExceptions
{
    public class BaseException<T> : Exception where T : class
    {
        public BaseException(string msg) : base(msg)
        {
        }
        public BaseException(string msg, string entityCode) : base(msg)
        {
        }
    }
}
