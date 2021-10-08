// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.EventHandler
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using TaxDeterminationLoader.Resources;

namespace TaxDeterminationLoader
{
  internal static class EventHandler
  {
    private static readonly Support Sup = new Support();
    private static int keyFieldsCounter;
    private static frmOKSFTCD ofrmOKSFTCD;
    private static frmOKSFTCD_Update ofrmOKSFTCD_Update;

    private static void AppEvent(BoAppEventTypes eventType)
    {
      if (eventType != BoAppEventTypes.aet_CompanyChanged && eventType != BoAppEventTypes.aet_LanguageChanged && eventType != BoAppEventTypes.aet_ServerTerminition && eventType != BoAppEventTypes.aet_ShutDown)
        return;
      System.Windows.Forms.Application.Exit();
    }

    internal static void EventHandlerStart()
    {
      try
      {
        EventHandler.Sup.SetApplication();
        Support.StatusbarMessagesPrefix = "TaxDeterminationLoader";
        List<Support.EventFilterType> eventFilters = new List<Support.EventFilterType>();
        Support.EventFilterType eventFilterType = new Support.EventFilterType()
        {
          _eventType = BoEventTypes.et_FORM_LOAD
        };
        eventFilterType._formUniqueId = new string[3]
        {
          "80402",
          "OKSFTCD",
          "OKSFTCD_Update"
        };
        eventFilters.Add(eventFilterType);
        eventFilterType._eventType = BoEventTypes.et_CLICK;
        eventFilterType._formUniqueId = new string[3]
        {
          "80402",
          "OKSFTCD",
          "OKSFTCD_Update"
        };
        eventFilters.Add(eventFilterType);
        eventFilterType._eventType = BoEventTypes.et_FORM_DATA_ADD;
        eventFilterType._formUniqueId = new string[3]
        {
          "80402",
          "OKSFTCD",
          "OKSFTCD_Update"
        };
        eventFilters.Add(eventFilterType);
        eventFilterType._eventType = BoEventTypes.et_FORM_VISIBLE;
        eventFilterType._formUniqueId = new string[3]
        {
          "80402",
          "OKSFTCD",
          "OKSFTCD_Update"
        };
        eventFilters.Add(eventFilterType);
        Support.SetEventHandlingFilters(eventFilters);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format(TaxDeterminationLoader.Resources.Resources.BusinessOneNotFound, (object) Environment.NewLine, (object) Environment.NewLine, (object) ex.Message));
        Environment.Exit(0);
      }
      // ISSUE: method pointer
      Support._sboApp.add_AppEvent(new _IApplicationEvents_AppEventEventHandler((object) null, (UIntPtr) __methodptr(AppEvent)));
      // ISSUE: method pointer
      Support.pSbo.add_ItemEvent(new _IApplicationEvents_ItemEventEventHandler((object) null, (UIntPtr) __methodptr(ItemEvent)));
      Support.ShowMessageInStatusBar("Addon carregado", BoStatusBarMessageType.smt_Success);
    }

    private static void Import()
    {
      try
      {
        string str1 = "";
        string udfEditValue1 = EventHandler.Sup.getUDFEditValue("OKSFTCD", "OKSFTCDECS");
        string udfEditValue2 = EventHandler.Sup.getUDFEditValue("OKSFTCD", "OKSFTCDECA");
        if (!object.Equals((object) udfEditValue1, (object) string.Empty))
        {
          if (!object.Equals((object) udfEditValue1, (object) string.Empty))
            str1 = udfEditValue1;
        }
        else if (object.Equals((object) Support.showMessageBox(ProjectMessages.BlankSeparatorChar, 2, "Sim", "Não", ""), (object) 1))
          str1 = " ";
        Support._sboApp.Forms.Item((object) "OKSFTCD").Close();
        using (StreamReader streamReader = new StreamReader(udfEditValue2))
        {
          long num1 = 0;
          long num2 = 0;
          while (true)
          {
            long num3;
            do
            {
              string str2;
              string[] strArray;
              int length;
              string textToSet1;
              string textToSet2;
              string textToSet3;
              string textToSet4;
              string textToSet5;
              string textToSet6;
              int num4;
              do
              {
                do
                {
                  string str3 = streamReader.ReadLine();
                  str2 = str3;
                  if (str3 != null)
                  {
                    ++num1;
                    num3 = 0L;
                  }
                  else
                    goto label_47;
                }
                while (!(str2 != "") || num1 <= 1L);
                char[] chArray = new char[1]{ str1[0] };
                strArray = str2.Split(chArray);
                length = strArray.Length;
                textToSet1 = "";
                textToSet2 = "";
                textToSet3 = "";
                textToSet4 = "";
                textToSet5 = "";
                textToSet6 = "";
                num4 = EventHandler.keyFieldsCounter + 2;
                switch (num4)
                {
                  case 3:
                    textToSet1 = strArray[0].ToString();
                    textToSet5 = strArray[1].ToString();
                    textToSet6 = strArray[2].ToString();
                    break;
                  case 4:
                    textToSet1 = strArray[0].ToString();
                    textToSet2 = strArray[1].ToString();
                    textToSet5 = strArray[2].ToString();
                    textToSet6 = strArray[3].ToString();
                    break;
                  case 5:
                    textToSet1 = strArray[0].ToString();
                    textToSet2 = strArray[1].ToString();
                    textToSet3 = strArray[2].ToString();
                    textToSet5 = strArray[3].ToString();
                    textToSet6 = strArray[4].ToString();
                    break;
                  case 6:
                    textToSet1 = strArray[0].ToString();
                    textToSet2 = strArray[1].ToString();
                    textToSet3 = strArray[2].ToString();
                    textToSet4 = strArray[3].ToString();
                    textToSet5 = strArray[4].ToString();
                    textToSet6 = strArray[5].ToString();
                    break;
                }
                if (textToSet5 != "")
                {
                  try
                  {
                    Convert.ToDateTime(textToSet5);
                    if (textToSet6 != "")
                      Convert.ToDateTime(textToSet6);
                  }
                  catch (Exception ex)
                  {
                    ++num3;
                    ++num2;
                    Log.writeLog(string.Format("Linha {0};{1};{2};{3}", (object) num1, (object) ProjectMessages.InvalidDate, (object) textToSet5, (object) textToSet6), "logImport.txt");
                  }
                }
                else
                {
                  ++num3;
                  ++num2;
                  Log.writeLog(string.Format("Linha {0};{1}", (object) num1, (object) ProjectMessages.EfectFromMandatory), "logImport.txt");
                }
              }
              while ((ulong) num3 > 0UL);
              Console.WriteLine("Valor 1: " + textToSet1);
              Console.WriteLine("Valor 2: " + textToSet2);
              Console.WriteLine("Valor 3: " + textToSet3);
              Console.WriteLine("Valor 4: " + textToSet4);
              Console.WriteLine("Efetivo desde: " + textToSet5);
              Console.WriteLine("Efetivo até: " + textToSet6);
              try
              {
                Support.SetoFormByFormTypeEx("80402");
                Support.SetoMatrix("2003");
                List<string> stringList = new List<string>();
                int num5 = 0;
                for (int index = 0; index < Support.oMatrix[].Count && num5 < EventHandler.keyFieldsCounter; ++index)
                {
                  if (Support.oMatrix[].Item((object) index).Editable)
                  {
                    ++num5;
                    stringList.Add(Support.oMatrix[].Item((object) index).UniqueID);
                  }
                }
                switch (num4)
                {
                  case 3:
                    Support.SetMatrixEditBoxContents(stringList[0], -1, Support.oMatrix.RowCount, textToSet1);
                    break;
                  case 4:
                    Support.SetMatrixEditBoxContents(stringList[0], -1, Support.oMatrix.RowCount, textToSet1);
                    Support.SetMatrixEditBoxContents(stringList[1], -1, Support.oMatrix.RowCount, textToSet2);
                    break;
                  case 5:
                    Support.SetMatrixEditBoxContents(stringList[0], -1, Support.oMatrix.RowCount, textToSet1);
                    Support.SetMatrixEditBoxContents(stringList[1], -1, Support.oMatrix.RowCount, textToSet2);
                    Support.SetMatrixEditBoxContents(stringList[2], -1, Support.oMatrix.RowCount, textToSet3);
                    break;
                  case 6:
                    Support.SetMatrixEditBoxContents(stringList[0], -1, Support.oMatrix.RowCount, textToSet1);
                    Support.SetMatrixEditBoxContents(stringList[1], -1, Support.oMatrix.RowCount, textToSet2);
                    Support.SetMatrixEditBoxContents(stringList[2], -1, Support.oMatrix.RowCount, textToSet3);
                    Support.SetMatrixEditBoxContents(stringList[3], -1, Support.oMatrix.RowCount, textToSet4);
                    break;
                }
              }
              catch (Exception ex)
              {
                ++num3;
                ++num2;
                Support.ShowMessageInStatusBar(ProjectMessages.FileProblems3, BoStatusBarMessageType.smt_Error);
                Log.writeLog(string.Format("Linha {0};{1};{2};{3}", (object) num1, (object) ProjectMessages.FileProblems3, (object) str2, (object) ex.Message), "logImport.txt");
                Support._sboApp.Forms.ActiveForm.Close();
              }
              if (num3 == 0L)
              {
                Support.oMatrix[].Item((object) "2000").Cells.Item((object) Support.oMatrix.RowCount).Click(BoCellClickType.ct_Double, 0);
                Support.SetoFormByFormTypeEx("80403");
                Support.SetoMatrix("2003");
                Support.SetMatrixEditBoxContents("2001", -1, Support.oMatrix.RowCount, textToSet5);
                Support.SetMatrixEditBoxContents("2002", -1, Support.oMatrix.RowCount, textToSet6);
                Support.oMatrix[].Item((object) "2000").Cells.Item((object) Support.oMatrix.RowCount).Click(BoCellClickType.ct_Double, 0);
                int rowIndex = 0;
                for (int index = num4; index < length; ++index)
                {
                  ++rowIndex;
                  Support.SetoFormByFormTypeEx("80404");
                  Support.SetoMatrix("2002");
                  string textToSet7 = strArray[index].ToString();
                  string str3;
                  if (textToSet7 == "")
                  {
                    str3 = "1";
                  }
                  else
                  {
                    Recordset recordSet = EventHandler.Sup.getRecordSet(TaxDeterminationLoader.Resources.Resources.SelectVerifyTaxCode, string.Format(" WHERE Code = '{0}'", (object) textToSet7));
                    str3 = EventHandler.Sup.getRecordSetResult(recordSet, 0);
                  }
                  if (Convert.ToInt32(str3) == 1)
                  {
                    if (!string.IsNullOrEmpty(textToSet7))
                    {
                      Console.WriteLine("Cod. Imposto {0}: {1}", (object) rowIndex, (object) textToSet7);
                      Support.SetMatrixEditBoxContents("2002", -1, rowIndex, textToSet7);
                    }
                  }
                  else
                  {
                    ++num3;
                    ++num2;
                    Log.writeLog(string.Format("Linha {0};{1};{2}", (object) num1, (object) ProjectMessages.InvalidTaxCode, (object) textToSet7), "logImport.txt");
                  }
                }
                SAPbouiCOM.Form activeForm1 = Support._sboApp.Forms.ActiveForm;
                activeForm1[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                activeForm1[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                SAPbouiCOM.Form activeForm2 = Support._sboApp.Forms.ActiveForm;
                activeForm2[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                activeForm2[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                Support._sboApp.Forms.ActiveForm[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
              }
            }
            while (num3 != 0L);
            Log.writeLog(string.Format("Linha {0};{1}", (object) num1, (object) ProjectMessages.SucessImport), "logImport.txt");
          }
label_47:
          if (!object.Equals((object) num2, (object) 0))
            Support.ShowMessageInStatusBar(ProjectMessages.FailedImport, BoStatusBarMessageType.smt_Error);
          else
            Support.ShowMessageInStatusBar(ProjectMessages.SucessImport, BoStatusBarMessageType.smt_Success);
        }
      }
      catch (Exception ex)
      {
        Log.writeLog(string.Format("{0};{1}", (object) ProjectMessages.Error1, (object) ex.Message), string.Empty);
        Console.WriteLine(ex.Message);
      }
    }

    private static void ItemEvent(string formUid, ref ItemEvent pVal, out bool bubbleEvent)
    {
      bubbleEvent = true;
      if (pVal.EventType == BoEventTypes.et_FORM_LOAD && (pVal.FormTypeEx == "80402" && pVal.Before_Action))
      {
        try
        {
          SAPbouiCOM.Form formByTypeAndCount = Support._sboApp.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);
          formByTypeAndCount[].Add("f80402bt1", BoFormItemTypes.it_BUTTON);
          formByTypeAndCount[].Item((object) "f80402bt1").Visible = false;
          formByTypeAndCount[].Add("f80402bt2", BoFormItemTypes.it_BUTTON);
          formByTypeAndCount[].Item((object) "f80402bt2").Visible = false;
          formByTypeAndCount[].Add("f80402bt3", BoFormItemTypes.it_BUTTON);
          formByTypeAndCount[].Item((object) "f80402bt3").Visible = false;
          formByTypeAndCount.Visible = false;
          Support.SetoFormByFormTypeEx("80401");
          Support.SetoMatrix("2003");
          string currentRowAsString = Support.GetMatrixItemFromCurrentRowAsString("2000", Support.oMatrix.GetNextSelectedRow(0, BoOrderType.ot_SelectionOrder));
          Recordset recordSet = EventHandler.Sup.getRecordSet(TaxDeterminationLoader.Resources.Resources.SelectVerifyKeyFields, string.Format(" WHERE TcdId = 1 AND Priority = '{0}'", (object) currentRowAsString));
          string recordSetResult1 = EventHandler.Sup.getRecordSetResult(recordSet, 0);
          string recordSetResult2 = EventHandler.Sup.getRecordSetResult(recordSet, 1);
          string recordSetResult3 = EventHandler.Sup.getRecordSetResult(recordSet, 2);
          string recordSetResult4 = EventHandler.Sup.getRecordSetResult(recordSet, 3);
          EventHandler.keyFieldsCounter = 0;
          if (recordSetResult1 != "0")
            ++EventHandler.keyFieldsCounter;
          if (recordSetResult2 != "0")
            ++EventHandler.keyFieldsCounter;
          if (recordSetResult3 != "0")
            ++EventHandler.keyFieldsCounter;
          if (recordSetResult4 != "0")
            ++EventHandler.keyFieldsCounter;
          formByTypeAndCount.Visible = true;
        }
        catch (Exception ex)
        {
          Log.writeLog("Erro na criação do botão;" + ex.Message, "");
          Console.WriteLine(ex.Message);
        }
      }
      if (pVal.EventType == BoEventTypes.et_FORM_VISIBLE && pVal.FormTypeEx == "80402")
      {
        try
        {
          SAPbouiCOM.Form formByTypeAndCount = Support._sboApp.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);
          if (!pVal.Before_Action && formByTypeAndCount.Visible)
          {
            formByTypeAndCount.Freeze(true);
            Item tem1 = formByTypeAndCount[].Item((object) "f80402bt1");
            int top1 = formByTypeAndCount[].Item((object) "2002").Top;
            int height1 = formByTypeAndCount[].Item((object) "2002").Height;
            int left1 = formByTypeAndCount[].Item((object) "2002").Left;
            tem1.Left = left1 - 63;
            tem1.Top = top1;
            tem1.Width = 60;
            tem1.Height = height1;
            tem1.Visible = true;
            ((IButton) tem1[]).Caption = "Importar";
            Item tem2 = formByTypeAndCount[].Item((object) "f80402bt2");
            int top2 = formByTypeAndCount[].Item((object) "2002").Top;
            int height2 = formByTypeAndCount[].Item((object) "2002").Height;
            int left2 = formByTypeAndCount[].Item((object) "2002").Left;
            tem2.Left = left2 - 126;
            tem2.Top = top2;
            tem2.Width = 60;
            tem2.Height = height2;
            tem2.Visible = true;
            ((IButton) tem2[]).Caption = "Limpar";
            Item tem3 = formByTypeAndCount[].Item((object) "f80402bt3");
            int top3 = formByTypeAndCount[].Item((object) "2002").Top;
            int height3 = formByTypeAndCount[].Item((object) "2002").Height;
            int left3 = formByTypeAndCount[].Item((object) "2002").Left;
            tem3.Left = left3 - 189;
            tem3.Top = top3;
            tem3.Width = 60;
            tem3.Height = height3;
            tem3.Visible = true;
            ((IButton) tem3[]).Caption = "Atualizar";
            formByTypeAndCount.Freeze(false);
          }
        }
        catch (Exception ex)
        {
          Console.Write(ex.Message);
        }
      }
      if (pVal.EventType != BoEventTypes.et_CLICK)
        return;
      if (pVal.FormTypeEx == "80402")
      {
        if (pVal.ItemUID == "f80402bt1" && !pVal.Before_Action)
        {
          string sapfComboValue = EventHandler.Sup.getSAPFComboValue("80401", "2025", "value");
          Recordset recordSet = EventHandler.Sup.getRecordSet(TaxDeterminationLoader.Resources.Resources.SelectVerifDetType, string.Format(" WHERE TcdId = '{0}'", (object) sapfComboValue));
          if ((uint) Convert.ToInt32(EventHandler.Sup.getRecordSetResult(recordSet, 0)) > 0U)
          {
            try
            {
              EventHandler.ofrmOKSFTCD = new frmOKSFTCD();
            }
            catch (Exception ex)
            {
              Log.writeLog(string.Format("Erro ao abrir o form de importação;{0}", (object) ex.Message), "");
            }
          }
          else
            Support.ShowMessageInStatusBar(ProjectMessages.DetTypeWrong, BoStatusBarMessageType.smt_Error);
        }
        if (pVal.ItemUID == "f80402bt2" && !pVal.Before_Action)
        {
          try
          {
            Support.SetoFormByFormTypeEx("80402");
            Support.SetoMatrix("2003");
            Support._sboApp.Forms.Item((object) formUid);
            for (int index = Support.oMatrix.RowCount - 1; index > 0; --index)
            {
              try
              {
                Support.oMatrix[].Item((object) "2000").Cells.Item((object) index).Click(BoCellClickType.ct_Regular, 0);
                Support._sboApp.Menus.Item((object) "1283").Enabled = true;
                Support._sboApp.Menus.Item((object) "1283").Activate();
                Support._sboApp.Menus.Item((object) "1283").Enabled = false;
              }
              catch
              {
                Support.oMatrix[].Item((object) "2000").Cells.Item((object) index).Click(BoCellClickType.ct_Right, 0);
                Support._sboApp.Menus.Item((object) "1283").Enabled = true;
                Support._sboApp.Menus.Item((object) "1283").Activate();
                Support._sboApp.Menus.Item((object) "1283").Enabled = false;
              }
            }
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
        if (pVal.ItemUID == "f80402bt3" && !pVal.Before_Action)
        {
          string sapfComboValue = EventHandler.Sup.getSAPFComboValue("80401", "2025", "value");
          Recordset recordSet = EventHandler.Sup.getRecordSet(TaxDeterminationLoader.Resources.Resources.SelectVerifDetType, string.Format(" WHERE TcdId = '{0}'", (object) sapfComboValue));
          if ((uint) Convert.ToInt32(EventHandler.Sup.getRecordSetResult(recordSet, 0)) > 0U)
          {
            try
            {
              EventHandler.ofrmOKSFTCD_Update = new frmOKSFTCD_Update();
            }
            catch (Exception ex)
            {
              Log.writeLog(string.Format("Erro ao abrir o form de importação;{0}", (object) ex.Message), "");
            }
          }
          else
            Support.ShowMessageInStatusBar(ProjectMessages.DetTypeWrong, BoStatusBarMessageType.smt_Error);
        }
      }
      if (formUid == "OKSFTCD")
      {
        if (pVal.ItemUID == "7" && !pVal.Before_Action)
        {
          try
          {
            SAPbouiCOM.Form form = Support._sboApp.Forms.Item((object) formUid);
            form.DataSources.UserDataSources.Item((object) "OKSFTCDECA").Value = General.GetFileNameViaOFD("csv files (*.csv)|*.csv", "", "Selecione o arquivo para importação");
            form.Mode = BoFormMode.fm_UPDATE_MODE;
          }
          catch (Exception ex)
          {
            Console.Write(ex.Message);
          }
        }
        if (pVal.ItemUID == "OKSFTCDBIM" && pVal.Before_Action && object.Equals((object) EventHandler.Sup.getUDFEditValue("OKSFTCD", "OKSFTCDECA"), (object) string.Empty))
        {
          Support.ShowMessageInStatusBar(ProjectMessages.BlankFilePath, BoStatusBarMessageType.smt_Error);
          bubbleEvent = false;
        }
        if (pVal.ItemUID == "OKSFTCDBIM" && !pVal.Before_Action)
          EventHandler.Import();
      }
      if (formUid == "OKSFTCD_Update")
      {
        if (pVal.ItemUID == "7" && !pVal.Before_Action)
        {
          try
          {
            SAPbouiCOM.Form form = Support._sboApp.Forms.Item((object) formUid);
            form.DataSources.UserDataSources.Item((object) "OKSFTCDECA").Value = General.GetFileNameViaOFD("csv files (*.csv)|*.csv", "", "Selecione o arquivo para importação");
            form.Mode = BoFormMode.fm_UPDATE_MODE;
          }
          catch (Exception ex)
          {
            Console.Write(ex.Message);
          }
        }
        if (pVal.ItemUID == "OKSFTCDBIM" && pVal.Before_Action && object.Equals((object) EventHandler.Sup.getUDFEditValue("OKSFTCD_Update", "OKSFTCDECA"), (object) string.Empty))
        {
          Support.ShowMessageInStatusBar(ProjectMessages.BlankFilePath, BoStatusBarMessageType.smt_Error);
          bubbleEvent = false;
        }
        if (pVal.ItemUID == "OKSFTCDBIM" && !pVal.Before_Action)
          EventHandler.Update();
      }
    }

    private static void Update()
    {
      try
      {
        string str1 = "";
        string udfEditValue1 = EventHandler.Sup.getUDFEditValue("OKSFTCD_Update", "OKSFTCDECS");
        string udfEditValue2 = EventHandler.Sup.getUDFEditValue("OKSFTCD_Update", "OKSFTCDECA");
        if (!object.Equals((object) udfEditValue1, (object) string.Empty))
        {
          if (!object.Equals((object) udfEditValue1, (object) string.Empty))
            str1 = udfEditValue1;
        }
        else if (object.Equals((object) Support.showMessageBox(ProjectMessages.BlankSeparatorChar, 2, "Sim", "Não", ""), (object) 1))
          str1 = " ";
        Support._sboApp.Forms.Item((object) "OKSFTCD_Update").Close();
        using (StreamReader streamReader = new StreamReader(udfEditValue2))
        {
          int num1 = 0;
          int num2 = 0;
          while (true)
          {
            string str2;
            int num3;
            do
            {
              string str3 = streamReader.ReadLine();
              str2 = str3;
              if (!string.IsNullOrEmpty(str3))
              {
                ++num1;
                num3 = 0;
              }
              else
                goto label_76;
            }
            while (string.IsNullOrEmpty(str2) || num1 <= 1);
            char[] chArray = new char[1]{ str1[0] };
            string[] strArray = str2.Split(chArray);
            int length = strArray.Length;
            string textToGet1 = "";
            string textToGet2 = "";
            string textToGet3 = "";
            string textToGet4 = "";
            string s1 = "";
            string s2 = "";
            int num4 = EventHandler.keyFieldsCounter + 2;
            switch (num4)
            {
              case 3:
                textToGet1 = strArray[0].ToString();
                s1 = strArray[1].ToString();
                s2 = strArray[2].ToString();
                break;
              case 4:
                textToGet1 = strArray[0].ToString();
                textToGet2 = strArray[1].ToString();
                s1 = strArray[2].ToString();
                s2 = strArray[3].ToString();
                break;
              case 5:
                textToGet1 = strArray[0].ToString();
                textToGet2 = strArray[1].ToString();
                textToGet3 = strArray[2].ToString();
                s1 = strArray[3].ToString();
                s2 = strArray[4].ToString();
                break;
              case 6:
                textToGet1 = strArray[0].ToString();
                textToGet2 = strArray[1].ToString();
                textToGet3 = strArray[2].ToString();
                textToGet4 = strArray[3].ToString();
                s1 = strArray[4].ToString();
                s2 = strArray[5].ToString();
                break;
            }
            if (!string.IsNullOrEmpty(s1))
            {
              try
              {
                Convert.ToDateTime(s1);
                if (!string.IsNullOrEmpty(s2))
                  Convert.ToDateTime(s2);
              }
              catch (Exception ex)
              {
                ++num3;
                ++num2;
                Log.writeLog(string.Format("Linha {0};{1};{2};{3}", (object) num1, (object) ProjectMessages.InvalidDate, (object) s1, (object) s2), "logImport.txt");
              }
            }
            else
            {
              ++num3;
              ++num2;
              Log.writeLog(string.Format("Linha {0};{1}", (object) num1, (object) ProjectMessages.EfectFromMandatory), "logImport.txt");
            }
            if (num3 == 0)
            {
              Console.WriteLine("Valor 1: " + textToGet1);
              Console.WriteLine("Valor 2: " + textToGet2);
              Console.WriteLine("Valor 3: " + textToGet3);
              Console.WriteLine("Valor 4: " + textToGet4);
              Console.WriteLine("Efetivo desde: " + s1);
              Console.WriteLine("Efetivo até: " + s2);
              List<string> stringList = new List<string>();
              try
              {
                Support.SetoFormByFormTypeEx("80402");
                Support.SetoMatrix("2003");
                int num5 = 0;
                for (int index = 1; index <= 8; ++index)
                {
                  string str3 = "V_" + (object) index;
                  if (num5 >= EventHandler.keyFieldsCounter)
                    index = 8;
                  else if (Support.oMatrix[].Item((object) str3).Editable)
                  {
                    ++num5;
                    stringList.Add(str3);
                  }
                }
              }
              catch
              {
              }
              if (num3 == 0)
              {
                bool flag = false;
                int num5 = num4;
                int rowIndex1;
                for (rowIndex1 = 1; rowIndex1 <= Support.oMatrix.RowCount; ++rowIndex1)
                {
                  switch (num5)
                  {
                    case 3:
                      if (Support.GetMatrixEditBoxContents(stringList[0], -1, rowIndex1, textToGet1))
                      {
                        flag = true;
                        break;
                      }
                      break;
                    case 4:
                      if (Support.GetMatrixEditBoxContents(stringList[0], -1, rowIndex1, textToGet1) && Support.GetMatrixEditBoxContents(stringList[1], -1, rowIndex1, textToGet2))
                      {
                        flag = true;
                        break;
                      }
                      break;
                    case 5:
                      if (Support.GetMatrixEditBoxContents(stringList[0], -1, rowIndex1, textToGet1) && Support.GetMatrixEditBoxContents(stringList[1], -1, rowIndex1, textToGet2) && Support.GetMatrixEditBoxContents(stringList[2], -1, rowIndex1, textToGet3))
                      {
                        flag = true;
                        break;
                      }
                      break;
                    case 6:
                      if (Support.GetMatrixEditBoxContents(stringList[0], -1, rowIndex1, textToGet1) && Support.GetMatrixEditBoxContents(stringList[1], -1, rowIndex1, textToGet2) && Support.GetMatrixEditBoxContents(stringList[2], -1, rowIndex1, textToGet3) && Support.GetMatrixEditBoxContents(stringList[3], -1, rowIndex1, textToGet4))
                      {
                        flag = true;
                        break;
                      }
                      break;
                  }
                  if (flag.Equals(true))
                    break;
                }
                Support.oMatrix[].Item((object) "2000").Cells.Item((object) rowIndex1).Click(BoCellClickType.ct_Double, 0);
                Support.SetoFormByFormTypeEx("80403");
                Support.SetoMatrix("2003");
                int rowIndex2 = 1;
                DateTime result1 = new DateTime();
                DateTime result2 = new DateTime();
                DateTime.TryParseExact(s1, "dd/MM/yyyy", (IFormatProvider) null, DateTimeStyles.None, out result1);
                if (!string.IsNullOrEmpty(s2))
                  DateTime.TryParseExact(s2, "dd/MM/yyyy", (IFormatProvider) null, DateTimeStyles.None, out result2);
                for (; rowIndex2 <= Support.oMatrix.RowCount; ++rowIndex2)
                {
                  if (Support.GetMatrixEditBoxContents("2001", -1, rowIndex2, string.Format("{0:yyyyMMdd}", (object) result1)))
                  {
                    if (!string.IsNullOrEmpty(s2))
                    {
                      if (Support.GetMatrixEditBoxContents("2002", -1, rowIndex2, string.Format("{0:yyyyMMdd}", (object) result2)))
                        flag = true;
                    }
                    else
                      flag = true;
                  }
                  if (flag.Equals(true))
                    break;
                }
                Support.oMatrix[].Item((object) "2000").Cells.Item((object) rowIndex2).Click(BoCellClickType.ct_Double, 0);
                int rowIndex3 = 0;
                for (int index = num4; index < length; ++index)
                {
                  ++rowIndex3;
                  Support.SetoFormByFormTypeEx("80404");
                  Support.SetoMatrix("2002");
                  string textToSet = strArray[index].ToString();
                  string str3;
                  if (textToSet == "")
                  {
                    str3 = "1";
                  }
                  else
                  {
                    Recordset recordSet = EventHandler.Sup.getRecordSet(TaxDeterminationLoader.Resources.Resources.SelectVerifyTaxCode, string.Format(" WHERE Code = '{0}'", (object) textToSet));
                    str3 = EventHandler.Sup.getRecordSetResult(recordSet, 0);
                  }
                  if (Convert.ToInt32(str3) == 1)
                  {
                    if (!string.IsNullOrEmpty(textToSet))
                    {
                      Console.WriteLine("Cod. Imposto {0}: {1}", (object) rowIndex3, (object) textToSet);
                      Support.SetMatrixEditBoxContents("2002", -1, rowIndex3, textToSet);
                    }
                  }
                  else
                  {
                    ++num3;
                    ++num2;
                    Log.writeLog(string.Format("Linha {0};{1};{2}", (object) num1, (object) ProjectMessages.InvalidTaxCode, (object) textToSet), "logImport.txt");
                  }
                }
                SAPbouiCOM.Form activeForm1 = Support._sboApp.Forms.ActiveForm;
                if (((IButton) activeForm1[].Item((object) "2000")[]).Caption.Equals("Atualizar"))
                {
                  activeForm1[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                  activeForm1[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                }
                else
                  activeForm1[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                SAPbouiCOM.Form activeForm2 = Support._sboApp.Forms.ActiveForm;
                if (((IButton) activeForm2[].Item((object) "2000")[]).Caption.Equals("Atualizar"))
                {
                  activeForm2[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                  activeForm2[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
                }
                else
                  activeForm2[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
              }
              if (num3 == 0)
                Log.writeLog(string.Format("Linha {0};{1}", (object) num1, (object) ProjectMessages.SucessImport), "logImport.txt");
            }
          }
label_76:
          SAPbouiCOM.Form activeForm = Support._sboApp.Forms.ActiveForm;
          Support._sboApp.Forms.ActiveForm[].Item((object) "2000").Click(BoCellClickType.ct_Regular);
          if (!object.Equals((object) num2, (object) 0))
            Support.ShowMessageInStatusBar(ProjectMessages.FailedImport, BoStatusBarMessageType.smt_Error);
          else
            Support.ShowMessageInStatusBar(ProjectMessages.SucessImport, BoStatusBarMessageType.smt_Success);
        }
      }
      catch (Exception ex)
      {
        Log.writeLog(string.Format("{0};{1}", (object) ProjectMessages.Error1, (object) ex.Message), string.Empty);
        Console.WriteLine(ex.Message);
      }
    }
  }
}
