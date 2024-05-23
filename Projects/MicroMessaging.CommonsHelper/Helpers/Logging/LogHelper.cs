using Microsoft.Extensions.Logging;
using System.Text;

namespace MicroMessaging.CommonsHelper.Helpers.Logging
{
    public static class LogHelper
    {
        public static void Error(this ILogger logger, Exception exception)
        {
            logger.LogError(exception.ToString());
        }

        public static void Error(this ILogger logger, Action<StringBuilder> action)
        {
            logger.Error(
                InterpritateMessage(action)
            );
        }

        public static void Error(this ILogger logger, string message)
        {
            logger.LogError(message);
        }

        public static void Error(this ILogger logger, string format, params object[] args)
        {
            try
            {
                logger.LogError(format, args);
            }
            catch (Exception exception)
            {
                logger.Error(
                    string.Format(
                        "Произошла ошибка логирования в методе 'Error(string format, params object[] args)':\r\n{0}",
                        exception
                    ),
                    exception
                );
            }
        }

        public static void Info(this ILogger logger, string message)
        {
            logger.LogInformation(message);
        }

        public static void Info(this ILogger logger, string format, params object[] args)
        {
            try
            {
                logger.LogInformation(format, args);
            }
            catch (Exception exception)
            {
                logger.Error(
                    string.Format(
                        "Произошла ошибка логирования в методе 'Info(string format, params object[] args):\r\n{0}'",
                        exception
                    ),
                    exception
                );
            }
        }



        public static void Debug(this ILogger logger, Action<StringBuilder> action)
        {
            logger.LogDebug(
                InterpritateMessage(action)
            );
        }

        public static void Debug(this ILogger logger, string message)
        {
            logger.LogDebug(message);
        }

        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            try
            {
                logger.LogDebug(format, args);
            }
            catch (Exception exception)
            {
                logger.Error(
                    string.Format(
                        "Произошла ошибка логирования в методе 'Debug(string format, params object[] args)':\r\n{0}",
                        exception
                    ),
                    exception
                );
            }
        }



        public static void Trace(this ILogger logger, Action<StringBuilder> action)
        {
            logger.LogTrace(
                InterpritateMessage(action)
            );
        }

        public static void Trace(this ILogger logger, string message)
        {
            logger.LogTrace(message);
        }

        public static void Trace(this ILogger logger, string format, params object[] args)
        {
            try
            {
                logger.LogTrace(format, args);
            }
            catch (Exception exception)
            {
                logger.Error(
                    string.Format(
                        "Произошла ошибка логирования в методе 'Trace(string format, params object[] args)':\r\n{0}",
                        exception
                    ),
                    exception
                );
            }
        }



        public static void Warn(this ILogger logger, Action<StringBuilder> action)
        {
            logger.LogWarning(
                InterpritateMessage(action)
            );
        }

        public static void Warn(this ILogger logger, string message)
        {
            logger.LogWarning(message);
        }

        public static void Warn(this ILogger logger, string format, params object[] args)
        {
            try
            {
                logger.LogWarning(format, args);
            }
            catch (Exception exception)
            {
                logger.Error(
                    string.Format(
                        "Произошла ошибка логирования в методе 'Warn(string format, params object[] args)':\r\n{0}",
                        exception
                    ),
                    exception
                );
            }
        }
        private static string InterpritateMessage(Action<StringBuilder> action)
        {
            var stringBuilder = new StringBuilder();

            action.Invoke(stringBuilder);

            return stringBuilder.ToString();
        }
    }
}
