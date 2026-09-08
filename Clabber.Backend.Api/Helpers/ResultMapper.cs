using Clabber.Backend.Application.Results;
using System.Net;

namespace Clabber.Backend.Api.Helpers
{
    public static class ResultMapper
    {
        public static int GetHttpStatusCode(OperationStatusCode statusCode)
        {
            return statusCode switch
            {
                OperationStatusCode.SUCCESS => (int)HttpStatusCode.OK,
                OperationStatusCode.VALIDATION_FAILED => (int)HttpStatusCode.BadRequest,
                OperationStatusCode.NOT_FOUND => (int)HttpStatusCode.NotFound,
                OperationStatusCode.UNAUTHORIZED => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
