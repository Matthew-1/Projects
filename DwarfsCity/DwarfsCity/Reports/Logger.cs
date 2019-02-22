using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.Reports
{
    public sealed class Logger
    {
        static private Logger logger = new Logger();
        private List<string> reports = new List<string>();

        private Logger() { }
        static public Logger GetInstance()
        {
            return logger;
        }
        public void AddLog(string log)
        {
            reports.Add(log);
        }
        public List<string> GetLogs()
        {
            return reports;
        }
        public void ClearData()
        {
            reports = new List<string>();
        }
    }
}
