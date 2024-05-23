using MicroMessaging.CommonsHelper.Helpers.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MicroMessaging.CommonsHelper.Helpers.Serialization.Json;

namespace MicroMessaging.WebServer.ApiComponents.Filters
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LogActionFilterAttribute> _logger;
        public bool IsNeedLogResponseContent { get; }

        public LogActionFilterAttribute(ILogger<LogActionFilterAttribute> logger, bool isNeedLogResponseContent = true)
        {
            _logger = logger;
            IsNeedLogResponseContent = isNeedLogResponseContent;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var parameters = context.ActionArguments;

            var message = $"Action caused: {context.HttpContext.Request.Path}" +
                          (parameters == null || parameters.Count == 0 ? string.Empty : $" with parameters: {GetParameters(parameters)}");

            _logger.Info(message);

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _logger.Error($"Received an error: {context.Exception.GetType().Name} Message: {context.Exception.Message}");
            }
            else
            {
                var message = $"Response received: {context.HttpContext.Response.StatusCode}";

                if (IsNeedLogResponseContent && context.Result is JsonResult result)
                {
                    var content = result.Value;

                    if (content != null)
                    {
                        message += $"{Environment.NewLine}Response object: ";
                        message += content.ToJson();
                    }
                }

                _logger.Info(message);
            }

            base.OnActionExecuted(context);
        }

        private string GetParameters(IDictionary<string, object> parameters)
        {
            return parameters.Aggregate(
                "",
                (current, parameter) =>
                    current + $"{Environment.NewLine} {parameter.Key}: {parameter.Value.ToJson()}");
        }
    }
}
