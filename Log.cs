// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.Log
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using System;
using System.IO;

namespace TaxDeterminationLoader
{
  public sealed class Log
  {
    private static string fileDefault = "log.txt";
    private static StreamWriter sw;

    public static void writeLog(string logLine, string fileName)
    {
      if (fileName != "")
      {
        if (!(fileName != ""))
          return;
        if (!File.Exists(fileName))
        {
          Log.sw = new StreamWriter(fileName);
          Log.sw.WriteLine(DateTime.Now.ToString() + ";" + logLine);
          Log.sw.Close();
        }
        else
        {
          Log.sw = File.AppendText(fileName);
          Log.sw.WriteLine(DateTime.Now.ToString() + ";" + logLine);
          Log.sw.Close();
        }
      }
      else if (!File.Exists(Log.fileDefault))
      {
        Log.sw = new StreamWriter(Log.fileDefault);
        Log.sw.WriteLine(DateTime.Now.ToString() + ";" + logLine);
        Log.sw.Close();
      }
      else
      {
        Log.sw = File.AppendText(Log.fileDefault);
        Log.sw.WriteLine(DateTime.Now.ToString() + ";" + logLine);
        Log.sw.Close();
      }
    }
  }
}
