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
            return controller.StatusCode(
                ResultMapper.GetHttpStatusCode(result.StatusCode),
                result);
        }
    }
}
