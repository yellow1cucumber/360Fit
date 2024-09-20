using System.Net;

namespace Infrastructure.GraphQL.Exceptions
{
    public class ErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is NotFound)
            {
                return error.WithCode(HttpStatusCode.NotFound.ToString());
            }
            return error;
        }
    }
}
