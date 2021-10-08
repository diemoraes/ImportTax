// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.GetSaveFileNameClass
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TaxDeterminationLoader
{
  internal class GetSaveFileNameClass
  {
    private readonly SaveFileDialog _oFileDialog = new SaveFileDialog();

    public void GetFileName()
    {
      if (this._oFileDialog.ShowDialog((IWin32Window) new WindowWrapper(GetSaveFileNameClass.GetForegroundWindow())) == DialogResult.OK)
        return;
      this._oFileDialog.FileName = string.Empty;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    public string DialogTitle
    {
      set
      {
        this._oFileDialog.Title = value;
      }
    }

    public string FileName
    {
      get
      {
        return this._oFileDialog.FileName;
      }
    }

    public string Filter
    {
      set
      {
        this._oFileDialog.Filter = value;
      }
    }

    public string InitialDirectory
    {
      set
      {
        this._oFileDialog.InitialDirectory = value;
      }
    }
  }
}
