﻿// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.frmOKSFTCD
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using SAPbouiCOM;
using System;

namespace TaxDeterminationLoader
{
  internal class frmOKSFTCD
  {
    private static readonly Support Sup = new Support();
    private EditText oEditFilePath;
    private EditText oEditSepChar;
    private Form oForm;

    public frmOKSFTCD()
    {
      try
      {
        Support support = new Support();
        support.LoadFormSafely("OKSFTCD", TaxDeterminationLoader.Resources.Resources.DetermCodImposto_formImport, false, true);
        this.oForm = Support._sboApp.Forms.Item((object) "OKSFTCD");
        this.oForm.DataSources.UserDataSources.Add("OKSFTCDECS", BoDataType.dt_SHORT_TEXT, 1);
        this.oForm.DataSources.UserDataSources.Add("OKSFTCDECA", BoDataType.dt_SHORT_TEXT, 254);
        this.oEditSepChar = (EditText) this.oForm[].Item((object) "OKSFTCDECS")[];
        this.oEditSepChar.DataBind.SetBound(true, "", "OKSFTCDECS");
        this.oEditFilePath = (EditText) this.oForm[].Item((object) "OKSFTCDECA")[];
        this.oEditFilePath.DataBind.SetBound(true, "", "OKSFTCDECA");
        support.setUDFEditValue("OKSFTCD", "OKSFTCDECS", ";");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
