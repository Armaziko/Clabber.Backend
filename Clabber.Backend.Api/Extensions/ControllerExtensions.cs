using Clabber.Backend.Api.Helpers;
using Clabber.Backend.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Clabber.Backend.Api.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ToActionResult(
            this ControllerBase controller,
            Result result)
        {
            if (result is null)
            {
                return controller.StatusCode(500);
            }

            var type = result.GetType();
            var valueInfo = type.GetProperty("Value");

            if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Result<>) || valueInfo is null)
            {
                if (result.Messages != null && result.Messages.Count > 0)
                {
                    return controller.StatusCode(
                        ResultMapper.GetHttpStatusCode(result.StatusCode), new { messages = result.Messages });
                }
                return controller.StatusCode(
                    ResultMapper.GetHttpStatusCode(result.StatusCode));
            }

            var value = valueInfo.GetValue(result);

            // In case value property is null, return messages as they might hold data about why it was null.
            if (value is null && result.Messages != null && result.Messages.Count > 0)
            {
                return controller.StatusCode(ResultMapper.GetHttpStatusCode(result.StatusCode), new { messages = result.Messages });
            }

            return controller.StatusCode(ResultMapper.GetHttpStatusCode(result.StatusCode), value);
        }
    }
}
