﻿// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.GetFolderPathClass
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TaxDeterminationLoader
{
  internal class GetFolderPathClass
  {
    private readonly FolderBrowserDialog _oFolderPath = new FolderBrowserDialog();

    public void GetFolderPath()
    {
      if (this._oFolderPath.ShowDialog((IWin32Window) new WindowWrapper(GetFolderPathClass.GetForegroundWindow())) == DialogResult.OK)
        return;
      this._oFolderPath.SelectedPath = string.Empty;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    public string FolderPath
    {
      get
      {
        return this._oFolderPath.SelectedPath;
      }
    }
  }
}
