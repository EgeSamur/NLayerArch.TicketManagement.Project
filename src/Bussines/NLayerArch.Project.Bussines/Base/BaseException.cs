namespace NLayerArch.Project.Bussines.Base
{
    public class BaseException : ApplicationException
    {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
    }
}
