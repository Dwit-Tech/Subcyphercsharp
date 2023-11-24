

namespace subcypherAPI
{
    public class Logger
    {
        private List<string> logs = new List<string>();

        public void AddLog(string logEntry)
        {
            logs.Add($"{logEntry} - {DateTime.Now}");
        }

        public IEnumerable<string> GetLogs()
        {
            return logs;
        }
    }
}


