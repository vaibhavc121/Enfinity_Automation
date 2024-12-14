using log4net;

public static class Logger
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

    public static void Info(string message)
    {
        log.Info(message);
    }

    public static void Debug(string message)
    {
        log.Debug(message);
    }

    public static void Error(string message, Exception? ex = null)
    {
        log.Error(message, ex);
    }
}
