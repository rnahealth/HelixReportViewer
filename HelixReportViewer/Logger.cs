// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace HelixReportViewer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Ionic.Zip;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Logger
    {
        private static object logLock = new object();

        public static void Write_In_Log(Exception ex)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\");
            }

            string FileName = Environment.CurrentDirectory + @"\Logs\Errors.log";
            string sCurrentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            string Message = sCurrentTime + "\r\n";
            Message += "Message: " + ex.Message + "\r\n";
            Message += "StackTrace: " + ex.StackTrace + "\r\n";
            Message += (ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : string.Empty) + "\r\n\r\n\r\n";

            lock (logLock)
            {
                File.AppendAllText(FileName, Message);
                ArchiveFileIfNecessary(FileName);
            }
        }

        // overloaded to write more data alogn with teh exception
        public static void Write_In_Log(Exception ex, string moreInfo)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\");
            }

            string FileName = Environment.CurrentDirectory + @"\Logs\Errors.log";

            string sCurrentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            string Message = sCurrentTime + "\r\n";
            Message += "Message: " + ex.Message + "\r\n";
            Message += "StackTrace: " + ex.StackTrace + "\r\n";
            Message += (ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : string.Empty) + "\r\n";

            Message += moreInfo + "\r\n\r\n\r\n";

            lock (logLock)
            {
                File.AppendAllText(FileName, Message);
                ArchiveFileIfNecessary(FileName);
            }
        }

        public static void Write_In_Log(string FileName, string Msg)
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\");
                }

                FileName = Environment.CurrentDirectory + @"\Logs\" + FileName + ".log";

                string sCurrentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                string Message = sCurrentTime + "\r\n" + Msg + "\r\r";

                lock (logLock)
                {
                    File.AppendAllText(FileName, Message);
                    ArchiveFileIfNecessary(FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                return;
            }
        }

        public static void Write_In_Log_Connectivity(string FileName, string connectedIP, string Msg)
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\");
                }

                FileName = Environment.CurrentDirectory + @"\Logs\" + FileName + ".log";

                string sCurrentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                string Message = sCurrentTime + "  " + connectedIP + "  " + Msg + "\r";

                lock (logLock)
                {
                    File.AppendAllText(FileName, Message);
                    ArchiveFileIfNecessary(FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                return;
            }
        }

        public static void Write_In_Log(string FileName, string Msg, string Reason)
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\");
                }

                FileName = Environment.CurrentDirectory + @"\Logs\" + FileName + ".log";

                string sCurrentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                string Message = sCurrentTime + "\r\n" + Msg + "\r\n\r\n" + "Reason:" + Reason + "\r\n\r\n";

                lock (logLock)
                {
                    File.AppendAllText(FileName, Message);
                    ArchiveFileIfNecessary(FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                return;
            }
        }

        // overloaded to write more data alogn with the exception
        public static void Write_Transmitted_Message(string data, int type, string address)
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\");
                }

                string FileName = Environment.CurrentDirectory + @"\Logs\Messages.log";

                string sCurrentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                string Message = string.Empty;

                if (type == 1)
                {
                    Message = "Outgoing Message at ";
                    FileName = Environment.CurrentDirectory + @"\Logs\OutgoingMessagesAndResponse.log";
                }
                else if (type == 2)
                {
                    Message = "Incoming Response at ";
                    FileName = Environment.CurrentDirectory + @"\Logs\OutgoingMessagesAndResponse.log";
                }
                else if (type == 3)
                {
                    Message = "Incoming Message at ";
                    FileName = Environment.CurrentDirectory + @"\Logs\IncomingMessagesAndResponse.log";
                }
                else
                {
                    Message = "Outgoing Response at ";
                    FileName = Environment.CurrentDirectory + @"\Logs\IncomingMessagesAndResponse.log";
                }

                data = data.TrimEnd((char)28, (char)13);
                Message += sCurrentTime;

                if (address != string.Empty)
                {
                    Message += "  [IP: " + address + "]";
                }

                Message += "\r\n";
                Message += data + "\r\n\r\n";

                lock (logLock)
                {
                    File.AppendAllText(FileName, Message);
                    ArchiveFileIfNecessary(FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                return;
            }
        }

        public static void ArchiveFileIfNecessary(string sourceFile)
        {
            try
            {
                
                FileInfo fileInfo = new FileInfo(sourceFile);

                double fileSizeMB = (double)fileInfo.Length / 1024.0 / 1024.0;

                if (fileSizeMB > 10)
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + @"\Logs\Archive\"))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + @"\Logs\Archive\");
                    }

                    string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string destFile = sourceFile.Replace(@"Logs\", @"Logs\Archive\");
                    destFile = destFile.Replace(@".log", "-" + date + ".log");
                    string zipFileName = destFile.Replace(".log", ".zip");

                    File.Move(sourceFile, destFile);

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddFile(destFile, "");
                        zip.Save(zipFileName);
                    }

                    File.Delete(destFile);
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                return;
            }
        }
    }
}
