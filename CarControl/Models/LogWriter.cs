using System;
using System.IO;
using System.Reflection;

public static class LogWriter
{

    public static void Write(string logMessage)
    {
        LogWrite(logMessage);
    }

    private static void LogWrite(string logMessage)
    {
   
        try
        {
            using (StreamWriter w = File.AppendText("C:\\inetpub\\CarControllog.txt"))
            {
                Log(logMessage, w);
            }
        }
        catch (Exception ex)
        {
        }
    }

    private static void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.WriteLine("{0} {1} {2}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString(), logMessage);
        }
        catch (Exception ex)
        {
        }
    }
}