using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GenericClassLibrary.Logging
{
    public static class TimeLogger
    {
        private static readonly object _lockObject = new object();
        private static readonly Dictionary<string, Stopwatch> Stopwatches = new Dictionary<string, Stopwatch>();

        public static void Start(EnumLogLevel logLevel, string action)
        {
            if (Logger.Level >= logLevel)
            {
                lock (_lockObject)
                {
                    if (Stopwatches.ContainsKey(action))
                    {
                        throw new Exception($"There is already a timer started for action: {action}");
                    }
                    Stopwatch sw = new Stopwatch();
                    Stopwatches.Add(action, sw);
                    sw.Start();
                }

            }
        }

        public static void Stop(string action)
        {
            lock (_lockObject)
            {
                if (!Stopwatches.TryGetValue(action, out Stopwatch sw))
                {
                    return;
                }

                sw.Stop();
                Logger.Info($"{action} took {sw.ElapsedMilliseconds} ms.");
                Stopwatches.Remove(action);
            }
        }
    }
}
