// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.WindowWrapper
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using System;
using System.Windows.Forms;

namespace TaxDeterminationLoader
{
  internal class WindowWrapper : IWin32Window
  {
    private readonly IntPtr _hwnd;

    public WindowWrapper(IntPtr handle)
    {
      this._hwnd = handle;
    }

    public virtual IntPtr Handle
    {
      get
      {
        return this._hwnd;
      }
    }
  }
}
