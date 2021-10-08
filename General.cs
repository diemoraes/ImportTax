// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.General
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace TaxDeterminationLoader
{
  internal sealed class General
  {
    public static T EnumTypeTo<T>(object value)
    {
      Type type = typeof (T);
      if (type.IsGenericType || !type.IsEnum)
      {
        try
        {
          return (T) Convert.ChangeType(value, type);
        }
        catch
        {
          return default (T);
        }
      }
      else
      {
        try
        {
          return !value.GetType().IsValueType ? (T) Enum.Parse(type, value.ToString()) : (T) Enum.ToObject(type, value);
        }
        catch
        {
          return default (T);
        }
      }
    }

    public static string[] fileReader(string filePath, string separator)
    {
      string[] strArray = (string[]) null;
      using (StreamReader streamReader = new StreamReader(filePath))
      {
        long num = 0;
        while (true)
        {
          string str1;
          do
          {
            string str2 = streamReader.ReadLine();
            str1 = str2;
            if (str2 != null)
              ++num;
            else
              goto label_2;
          }
          while (!(str1 != ""));
          char[] chArray = new char[1]{ separator[0] };
          strArray = str1.Split(chArray);
        }
label_2:
        return strArray;
      }
    }

    public static T GetCustomAttribute<T>(object value)
    {
      Type conversionType = typeof (T);
      object[] customAttributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof (T), false);
      int index = 0;
      if (index >= customAttributes.Length)
        return default (T);
      object obj = customAttributes[index];
      if (obj.GetType() == conversionType)
        return (T) Convert.ChangeType(obj, conversionType);
      return default (T);
    }

    public static string GetFileNameViaOFD(string filter, string initialDirectory, string dialogTitle)
    {
      GetFileNameClass getFileNameClass = new GetFileNameClass()
      {
        Filter = filter,
        InitialDirectory = initialDirectory,
        DialogTitle = dialogTitle
      };
      Thread thread = new Thread(new ThreadStart(getFileNameClass.GetFileName));
      thread.SetApartmentState(ApartmentState.STA);
      string fileName;
      try
      {
        thread.Start();
        do
          ;
        while (!thread.IsAlive);
        Thread.Sleep(1);
        thread.Join();
        fileName = getFileNameClass.FileName;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return fileName;
    }

    public static string GetFolderPath()
    {
      GetFolderPathClass getFolderPathClass = new GetFolderPathClass();
      Thread thread = new Thread(new ThreadStart(getFolderPathClass.GetFolderPath));
      thread.SetApartmentState(ApartmentState.STA);
      string folderPath;
      try
      {
        thread.Start();
        do
          ;
        while (!thread.IsAlive);
        Thread.Sleep(1);
        thread.Join();
        folderPath = getFolderPathClass.FolderPath;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return folderPath;
    }

    public static string GetSaveFile(string filter, string initialDirectory, string dialogTitle)
    {
      GetSaveFileNameClass saveFileNameClass = new GetSaveFileNameClass()
      {
        Filter = filter,
        InitialDirectory = initialDirectory,
        DialogTitle = dialogTitle
      };
      Thread thread = new Thread(new ThreadStart(saveFileNameClass.GetFileName));
      thread.SetApartmentState(ApartmentState.STA);
      string fileName;
      try
      {
        thread.Start();
        do
          ;
        while (!thread.IsAlive);
        Thread.Sleep(1);
        thread.Join();
        fileName = saveFileNameClass.FileName;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return fileName;
    }

    public static string NormalizeString(string texto)
    {
      string str = texto.Normalize(NormalizationForm.FormD);
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < str.Length; ++index)
      {
        if (CharUnicodeInfo.GetUnicodeCategory(str[index]) != UnicodeCategory.NonSpacingMark)
          stringBuilder.Append(str[index]);
      }
      return stringBuilder.ToString();
    }
  }
}
