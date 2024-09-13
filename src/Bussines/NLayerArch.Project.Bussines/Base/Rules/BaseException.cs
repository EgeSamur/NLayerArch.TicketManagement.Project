namespace NLayerArch.Project.Bussines.Base.Rules
{
    public class BaseException : ApplicationException
    {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
    }
}
