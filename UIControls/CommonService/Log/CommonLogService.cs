using ExSimpleIoc.IServices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace CommonServices.Log
{
    public enum LogLevel : int
    {
        Trace,
        Debug,
        Warning,
        Info,
        Error,
        Critical,
        Other,
    }

    internal class LogClass
    {
        public LogLevel level;
        public string log;
    }


    public class LogOption
    {
        public string LogLevel { get; set; } = "Other";
        public string LogDirecotry { get; set; } = "SystemLogs";
        public bool ShowConsole { get; set; } = false;
        public bool WriteFile { get; set; } = false;
        public int LogSaveDays { get; set; } = 7;
        public int FileSize { get; set; } = 10 * 1024 * 1024;
    }

    public class CommonLogService : ILogService
    {

        private LogOption config = new LogOption();

        private LogLevel Level = LogLevel.Other;

        private static string LogDir = string.Empty;

        private ConcurrentQueue<Tuple<string, string, LogLevel>> msgQueue = new ConcurrentQueue<Tuple<string, string, LogLevel>>();

        private ManualResetEvent m_work = new ManualResetEvent(false);



        public CommonLogService(LogOption option)
        {
            config = option;
            try
            {
                Level = (LogLevel)Enum.Parse(typeof(LogLevel), config.LogLevel, true);
            }
            catch (Exception)
            {
                Level = LogLevel.Other;
            }
            try
            {
                config.LogDirecotry.TrimEnd('\\');
                LogDir = Environment.CurrentDirectory + "\\" + config.LogDirecotry;
            }
            catch
            {
                LogDir = Environment.CurrentDirectory + "\\SystemLog";
            }

            //清除过期日志
            try
            {
                string[] dirs = Directory.GetDirectories(config.LogDirecotry);
                if (dirs != null && dirs.Length > 0)
                {
                    foreach (var item in dirs)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(item);
                        if (DateTime.Now.Subtract(dirInfo.CreationTime).TotalDays >= config.LogSaveDays)
                        {
                            dirInfo.Delete(true);
                        }
                    }
                }
            }
            catch { }


            m_work.Reset();

            Task.Factory.StartNew(ProcessLog, TaskCreationOptions.LongRunning);


        }

        private void ProcessLog()
        {
            try
            {
                int i;
                List<LogClass> list;
                Tuple<string, string, LogLevel> tuple;

                while (true)
                {
                    i = 0;
                    list = new List<LogClass>();

                    while (msgQueue.TryDequeue(out tuple) && i++ < 10000)
                    {
                        list.Add(new LogClass() { log = tuple.Item1.PadLeft(8) + tuple.Item2, level = tuple.Item3 });
                    }
                    if (list.Count > 0)
                    {
                        WriteFile(list);
                    }

                    if (msgQueue.Count <= 0)
                    {
                        m_work.WaitOne();
                    }
                    Thread.Sleep(1);
                }
            }
            catch
            {

            }
        }



        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private  string GetPath(LogClass item)
        {
            int index = 0;
            string logPath;
            bool bl = true;
            do
            {
                index++;
                logPath = Path.Combine(LogDir, DateTime.Now.ToString("yyyy-MM-dd"), item.level.ToString(), DateTime.Now.ToString("yyyyMMdd") + (index == 1 ? "" : "_" + index.ToString()) + ".log");

                if (!Directory.Exists(Path.GetDirectoryName(logPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(logPath));
                }

                if (File.Exists(logPath))
                {
                    FileInfo fileInfo = new FileInfo(logPath);
                    if (fileInfo.Length < config.FileSize)
                    {
                        bl = false;
                    }
                }
                else
                {
                    bl = false;
                }
            } while (bl);

            return logPath;
        }


        private  void WriteFile(List<LogClass> list)
        {
            try
            {
                list.ForEach(item =>
                {
                    if (config.ShowConsole)
                    {
                        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}   {item.log}");
                    }
                    if (config.WriteFile)
                    {
                        string path = GetPath(item);

                        if (!File.Exists(path))
                        {
                            using (FileStream fs = new FileStream(path, FileMode.Create)) { fs.Close(); }
                        }
                        using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                #region 日志内容
                                string value = string.Format(@"{0}    {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), item.log);
                                #endregion
                                sw.WriteLine(value);
                                sw.Flush();
                            }
                            fs.Close();
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public void Critical(string msg) => WriteLog(LogLevel.Critical, msg);

        public void Debug(string msg) => WriteLog(LogLevel.Debug, msg);

        public void Error(string msg) => WriteLog(LogLevel.Error, msg);

        public void Info(string msg) => WriteLog(LogLevel.Info, msg);

        public void Trace(string msg) => WriteLog(LogLevel.Trace, msg);

        public void Warn(string msg) => WriteLog(LogLevel.Warning, msg);

        private void WriteLog(LogLevel logLevel, string message)
        {
            if (logLevel <= Level)
            {
                msgQueue.Enqueue(new Tuple<string, string, LogLevel>($"[{logLevel}]  ", message, logLevel));
                m_work.Set();
            }
        }
    }
}
