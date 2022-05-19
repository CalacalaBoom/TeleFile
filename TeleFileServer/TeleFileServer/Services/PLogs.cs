using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleFileServer.Services
{
    public class Plogs
    {
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="info">日志记录</param>
        public static void Info(string className, string info)
        {
            WriteLog("INFO", className, info);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="info">日志记录</param>
        public static void Warn(string className, string info)
        {
            WriteLog("WARN", className, info);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="info">日志记录</param>
        public static void Error(string className, string info)
        {
            WriteLog("ERROE", className, info);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="infoLevel">日志级别</param>
        /// <param name="info">日志记录</param>
        private static void WriteLog(string className, string infoLevel, string info)
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            string logFileName = logFilePath + "/" + "log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            if (!File.Exists(logFileName))
            {
                File.Create(logFileName).Close();
            }
            string logFormat = string.Format("[ {0} ] {1}  {2}  {3}",
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                           className, infoLevel, info);
            StreamWriter sw = File.AppendText(logFileName);
            sw.WriteLine(logFormat);
            sw.Flush();
            sw.Close();
        }

    }
}
