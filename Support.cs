// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.Support
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using TaxDeterminationLoader.Resources;

namespace TaxDeterminationLoader
{
    internal sealed class Support
    {
        private string _sboCnx = Environment.GetCommandLineArgs().GetValue(1).ToString();
        private static string _cookie;
        private static SAPbobsCOM.Company _oCompany;
        private static SAPbouiCOM.Form _oForm;
        private static Item _oItem;
        private static Matrix _oMatrix;
        public static SAPbouiCOM.Application _sboApp;
        private static string _statusbarMessagesPrefix;
        private const int cellHeight = 15;
        private const int titleHeight = 17;

        private string CorrectCellAndTitleHightsInFormXMLString(string xmlString)
        {
            xmlString = this.ReplaceItemValueInXMLString(xmlString, Support.itemToChangeType.TitleHeight, 17);
            return this.ReplaceItemValueInXMLString(xmlString, Support.itemToChangeType.CellHeight, 15);
        }

        private static string CorrectNumberDecimalSeparator(string inNumber, Support.DecimalSeparatorType separatorType)
        {
            string str1 = 0.2.ToString().Substring(1, 1);
            string str2;
            string oldValue;
            try
            {
                Recordset businessObject = (Recordset)Support._oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                businessObject.DoQuery(TaxDeterminationLoader.Resources.Resources.QuerySboForDecimalAndThousandSeparator);
                str2 = businessObject.Fields.Item((object)TaxDeterminationLoader.Resources.Resources.QuerySboForDecimalSeparator_FieldName).Value.ToString();
                oldValue = businessObject.Fields.Item((object)TaxDeterminationLoader.Resources.Resources.QuerySboForThousandSeparator_FieldName).Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char ch in inNumber)
            {
                switch (ch)
                {
                    case ',':
                    case '-':
                    case '.':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        stringBuilder.Append(ch);
                        break;
                }
            }
            inNumber = stringBuilder.ToString();
            if (separatorType == Support.DecimalSeparatorType.Windows)
                inNumber = inNumber.Replace(oldValue, string.Empty);
            string str3 = inNumber;
            if (str2 != str1)
            {
                switch (separatorType)
                {
                    case Support.DecimalSeparatorType.Windows:
                        return inNumber.Replace(str2, str1);
                    case Support.DecimalSeparatorType.Sbo:
                        return inNumber.Replace(str1, str2);
                }
            }
            return str3;
        }

        private static string CorrectNumberDecimalSeparatorFromGridToWindowsFormat(string inNumber)
        {
            string newValue = 0.2.ToString().Substring(1, 1);
            string oldValue1;
            string oldValue2;
            try
            {
                Recordset businessObject = (Recordset)Support._oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                businessObject.DoQuery(TaxDeterminationLoader.Resources.Resources.QuerySboForDecimalAndThousandSeparator);
                oldValue1 = businessObject.Fields.Item((object)TaxDeterminationLoader.Resources.Resources.QuerySboForDecimalSeparator_FieldName).Value.ToString();
                oldValue2 = businessObject.Fields.Item((object)TaxDeterminationLoader.Resources.Resources.QuerySboForThousandSeparator_FieldName).Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char ch in inNumber)
            {
                switch (ch)
                {
                    case ',':
                    case '-':
                    case '.':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        stringBuilder.Append(ch);
                        break;
                }
            }
            inNumber = stringBuilder.ToString();
            inNumber = inNumber.Replace(oldValue2, string.Empty);
            return inNumber.Replace(oldValue1, newValue);
        }

        internal static int GetEditBoxInt32(string editBoxName)
        {
            string str = ((IEditText)Support._oForm.Items.Item((object)editBoxName).Specific).String;
            if (string.IsNullOrEmpty(str))
                return 0;
            return Convert.ToInt32(str);
        }

        internal static bool GetMatrixEditBoxContents(string columnName, int columnPos, int rowIndex, string textToGet)
        {
            bool flag = false;
            Column column = (Column)null;
            if (columnName != "")
            {
                if (columnName != "")
                    column = Support._oMatrix.Columns.Item((object)columnName);
            }
            else
                column = Support._oMatrix.Columns.Item((object)columnPos);
            EditText editText = (EditText)column.Cells.Item((object)rowIndex).Specific;
            if (textToGet.Equals(editText.Value.ToString()))
                flag = true;
            Marshal.ReleaseComObject((object)editText);
            Marshal.ReleaseComObject((object)column);
            return flag;
        }

        internal static Decimal GetMatrixItemFromCurrentRowAsDecimal(string columnName, int rowIndex)
        {
            Decimal num;
            try
            {
                Column column = Support._oMatrix.Columns.Item((object)columnName);
                EditText editText = (EditText)column.Cells.Item((object)rowIndex).Specific;
                string inNumber = editText.String;
                Marshal.ReleaseComObject((object)editText);
                Marshal.ReleaseComObject((object)column);
                num = Convert.ToDecimal(Support.CorrectNumberDecimalSeparator(Support.CorrectNumberDecimalSeparatorFromGridToWindowsFormat(inNumber), Support.DecimalSeparatorType.Windows));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return num;
        }

        internal static string GetMatrixItemFromCurrentRowAsString(string columnName, int rowIndex)
        {
            string str1;
            try
            {
                Column column = Support._oMatrix.Columns.Item((object)columnName);
                EditText editText = (EditText)column.Cells.Item((object)rowIndex).Specific;
                string str2 = editText.String;
                Marshal.ReleaseComObject((object)editText);
                Marshal.ReleaseComObject((object)column);
                str1 = str2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str1;
        }

        public Recordset getRecordSet(string query, string conditions)
        {
            Recordset businessObject = (Recordset)Support._oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            try
            {
                businessObject.DoQuery(query + conditions);
            }
            catch (Exception ex)
            {
                Log.writeLog(ProjectMessages.SQLError + ";" + ex.Message, "");
                Console.WriteLine(ex.Message);
            }
            return businessObject;
        }

        public string getRecordSetResult(Recordset RS, int pos)
        {
            return RS.Fields.Item((object)pos).Value.ToString();
        }

        public string getSAPFComboValue(string form, string item, string type)
        {
            Support._oItem = Support._sboApp.Forms.GetForm(form, 1).Items.Item((object)item);
            SAPbouiCOM.ComboBox comboBox = (SAPbouiCOM.ComboBox)Support._oItem.Specific;
            if (comboBox.Selected == null)
                return "";
            if (!(type != "value"))
                return comboBox.Selected.Value;
            if (type != "description")
                return "";
            return comboBox.Selected.Description;
        }

        public string getUDFComboValue(string formUID, string comboUID, string type)
        {
            Support._oItem = Support._sboApp.Forms.Item((object)formUID).Items.Item((object)comboUID);
            SAPbouiCOM.ComboBox comboBox = (SAPbouiCOM.ComboBox)Support._oItem.Specific;
            if (comboBox.Selected == null)
                return "";
            if (!(type != "value"))
                return comboBox.Selected.Value;
            if (type != "description")
                return "";
            return comboBox.Selected.Description;
        }

        public string getUDFEditValue(string formUID, string editUID)
        {
            Support._oItem = Support._sboApp.Forms.Item((object)formUID).Items.Item((object)editUID);
            return ((IEditText)Support._oItem.Specific).Value;
        }

        internal static bool IsFormOpen(string formType)
        {
            bool flag1 = false;
            bool flag2;
            try
            {
                for (int index = 0; index < Support._sboApp.Forms.Count; ++index)
                {
                    if (!(Support._sboApp.Forms.Item((object)index).TypeEx != formType))
                    {
                        flag1 = true;
                        break;
                    }
                }
                flag2 = flag1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag2;
        }

        private void LoadAFormFromFile(string xmlFileInnerString, bool makeVisible, string uniqueID, string formType, BoFormBorderStyle formBorderStyle)
        {
            try
            {
                FormCreationParams CreationPackage = (FormCreationParams)Support.pSbo.CreateObject(BoCreatableObjectType.cot_FormCreationParams);
                CreationPackage.XmlData = xmlFileInnerString;
                if (!string.IsNullOrEmpty(uniqueID))
                    CreationPackage.UniqueID = uniqueID;
                if (!string.IsNullOrEmpty(formType))
                    CreationPackage.FormType = formType;
                CreationPackage.BorderStyle = formBorderStyle;
                Support._oForm = Support.pSbo.Forms.AddEx(CreationPackage);
                Support._oForm.Visible = makeVisible;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadAFormFromSRF(string formType, string xmlFile, bool fileContents, bool makeVisible)
        {
            this.LoadAFormFromSRF(formType, xmlFile, fileContents, makeVisible, false);
        }

        public void LoadAFormFromSRF(string formType, string xmlFile, bool fileContents, bool makeVisible, bool freeze)
        {
            try
            {
                string str;
                if (!fileContents)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFile);
                    str = xmlDocument.InnerXml;
                }
                else
                    str = xmlFile;
                FormCreationParams CreationPackage = (FormCreationParams)Support.pSbo.CreateObject(BoCreatableObjectType.cot_FormCreationParams);
                CreationPackage.FormType = formType;
                CreationPackage.UniqueID = formType;
                CreationPackage.XmlData = str;
                Support._oForm = Support.pSbo.Forms.AddEx(CreationPackage);
                Support._oForm.Freeze(freeze);
            }
            catch (Exception ex)
            {
                Support.ShowMessageInStatusBar("Houve um erro na carga de um formulário: " + ex.Message, BoStatusBarMessageType.smt_Error);
            }
        }

        public void LoadAFormFromSRF(string xmlFile, bool fileContents, bool makeVisible, string uniqueID, string formType, BoFormBorderStyle formBorderStyle)
        {
            try
            {
                string xmlFileInnerString;
                if (!fileContents)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFile);
                    xmlFileInnerString = xmlDocument.InnerXml;
                }
                else
                    xmlFileInnerString = xmlFile;
                this.LoadAFormFromFile(xmlFileInnerString, makeVisible, uniqueID, formType, formBorderStyle);
            }
            catch (Exception ex)
            {
                Support.ShowMessageInStatusBar("Houve um erro na carga de um formulário: " + ex.Message, BoStatusBarMessageType.smt_Error);
            }
        }

        public void LoadForm(string xmlFile, string type)
        {
            try
            {
                if (type != "path")
                {
                    if (!(type == "xmlstring"))
                        return;
                    this.LoadSRFfromXML(ref xmlFile);
                }
                else
                    this.LoadSRFfromPath(ref xmlFile);
            }
            catch (Exception ex)
            {
                Log.writeLog("Erro ao abrir form;" + ex.Message, "");
                Console.WriteLine(ex.Message);
            }
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition)
        {
            return this.LoadFormSafely(formUniqueID, formXMLDefinition, false);
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition, bool freezeForm)
        {
            return this.LoadFormSafely(formUniqueID, formXMLDefinition, string.Empty, freezeForm);
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition, bool freezeForm, bool makeVisible)
        {
            return this.LoadFormSafely(formUniqueID, formXMLDefinition, string.Empty, freezeForm, makeVisible, true);
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition, string formTitle, bool freezeForm)
        {
            return this.LoadFormSafely(formUniqueID, formXMLDefinition, string.Empty, freezeForm, true, true);
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition, bool freezeForm, bool makeVisible, bool correctMatricesHeights)
        {
            return this.LoadFormSafely(formUniqueID, formXMLDefinition, string.Empty, freezeForm, makeVisible, correctMatricesHeights);
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition, string formTitle, bool freezeForm, bool makeVisible)
        {
            bool flag = false;
            foreach (SAPbouiCOM.Form form in (IForms)Support.pSbo.Forms)
            {
                if (form.UniqueID == formUniqueID)
                {
                    form.State = BoFormStateEnum.fs_Restore;
                    Support._oForm = form;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Support._oForm.Visible = makeVisible;
            }
            else
            {
                this.LoadAFormFromSRF(formUniqueID, formXMLDefinition, true, makeVisible);
                if (!string.IsNullOrEmpty(formTitle))
                    Support._oForm.Title = formTitle;
                Support._oForm.Freeze(false);
            }
            if (freezeForm)
                Support._oForm.Freeze(true);
            return flag;
        }

        public bool LoadFormSafely(string formUniqueID, string formXMLDefinition, string formTitle, bool freezeForm, bool makeVisible, bool correctMatricesHeights)
        {
            bool flag = false;
            foreach (SAPbouiCOM.Form form in (IForms)Support.pSbo.Forms)
            {
                if (form.UniqueID == formUniqueID)
                {
                    form.State = BoFormStateEnum.fs_Restore;
                    Support._oForm = form;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Support._oForm.Visible = makeVisible;
            }
            else
            {
                if (correctMatricesHeights)
                    formXMLDefinition = this.CorrectCellAndTitleHightsInFormXMLString(formXMLDefinition);
                this.LoadAFormFromSRF(formUniqueID, formXMLDefinition, true, makeVisible);
                if (!string.IsNullOrEmpty(formTitle))
                    Support._oForm.Title = formTitle;
                Support._oForm.Freeze(false);
            }
            if (freezeForm)
                Support._oForm.Freeze(true);
            return flag;
        }

        private void LoadSRFfromPath(ref string FileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Forms\\" + FileName);
            string XmlStr = xmlDocument.InnerXml.ToString();
            Support._sboApp.LoadBatchActions(ref XmlStr);
        }

        private void LoadSRFfromXML(ref string xmlFile)
        {
            XmlDocument xmlDocument = new XmlDocument();
            Support._sboApp.LoadBatchActions(ref xmlFile);
        }

        private string ReplaceItemValueInXMLString(string xmlString, Support.itemToChangeType itemToChange, int newValue)
        {
            string str = string.Empty;
            switch (itemToChange)
            {
                case Support.itemToChangeType.TitleHeight:
                    str = "titleHeight=";
                    break;
                case Support.itemToChangeType.CellHeight:
                    str = "cellHeight=";
                    break;
            }
            string[] separator = new string[1] { str };
            string[] strArray = xmlString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int length = strArray.Length;
            if (length == 1)
                return xmlString;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(strArray[0]);
            for (int index = 1; index < length; ++index)
            {
                stringBuilder.Append(str);
                stringBuilder.Append('"');
                stringBuilder.Append(newValue.ToString());
                stringBuilder.Append('"');
                int num = strArray[index].Substring(1).IndexOf('"');
                stringBuilder.Append(strArray[index].Substring(num + 2));
            }
            return stringBuilder.ToString();
        }

        internal void SetApplication()
        {
            SboGuiApi sboGuiApi = (SboGuiApi)new SboGuiApiClass();
            try
            {
                sboGuiApi.Connect(this._sboCnx);
                Support._sboApp = sboGuiApi.GetApplication(-1);
                Support._oCompany = (SAPbobsCOM.Company)new SAPbobsCOM.CompanyClass();
                Support._cookie = Support._sboApp.Company.GetConnectionContext(Support._oCompany.GetContextCookie());
                Support._oCompany.SetSboLoginContext(Support._cookie);
                Support._oCompany.Connect();
                if (!Support._oCompany.Connected)
                    Support.ShowMessageInStatusBar("Não Conectado!", BoStatusBarMessageType.smt_Error);
                else
                    Support.ShowMessageInStatusBar("Conectado!", BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void SetEventHandlingFilters(List<Support.EventFilterType> eventFilters)
        {
            EventFilters Filter = (EventFilters)new EventFiltersClass();
            foreach (Support.EventFilterType eventFilter1 in eventFilters)
            {
                EventFilter eventFilter2 = Filter.Add(eventFilter1._eventType);
                foreach (string FormType in eventFilter1._formUniqueId)
                    eventFilter2.AddEx(FormType);
            }
            Support._sboApp.SetFilter(Filter);
        }

        internal static void SetMatrixEditBoxContents(string columnName, int columnPos, int rowIndex, string textToSet)
        {
            Column column = (Column)null;
            if (columnName != "")
            {
                if (columnName != "")
                    column = Support._oMatrix.Columns.Item((object)columnName);
            }
            else
                column = Support._oMatrix.Columns.Item((object)columnPos);

            try
            {
                EditText editText = (EditText)column.Cells.Item((object)rowIndex).Specific;
                editText.String = textToSet;
                Marshal.ReleaseComObject((object)editText);
                Marshal.ReleaseComObject((object)column);
            }
            catch 
            {
                ComboBox editText = (ComboBox)column.Cells.Item((object)rowIndex).Specific;
                editText.Select(textToSet, BoSearchKey.psk_Index);
                Marshal.ReleaseComObject((object)editText);
                Marshal.ReleaseComObject((object)column);

            }



        }

        internal static void SetoFormByFormTypeEx(string formTypeEx)
        {
            try
            {
                for (int index = 0; index < Support._sboApp.Forms.Count; ++index)
                {
                    SAPbouiCOM.Form form = Support._sboApp.Forms.Item((object)index);
                    if (!(form.TypeEx != formTypeEx))
                    {
                        Support._oForm = form;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void SetoMatrix(string matrixName)
        {
            Support.SetoMatrix(matrixName, true);
        }

        private static void SetoMatrix(string matrixName, bool specific)
        {
            if (!specific)
            {
                Support._oMatrix = (Matrix)Support._oForm.Items.Item((object)matrixName);
            }
            else
            {
                try
                {
                    Support._oMatrix = (Matrix)Support._oForm.Items.Item((object)matrixName).Specific;
                }
                catch (Exception ex)
                {
                    Support.ShowMessageInStatusBar(ex.Message, BoStatusBarMessageType.smt_Error);
                }
            }
        }

        public void setUDFEditValue(string formUID, string editUID, string val)
        {
            Support._oItem = Support._sboApp.Forms.Item((object)formUID).Items.Item((object)editUID);
            ((IEditText)Support._oItem.Specific).String = val;
        }

        internal static int showMessageBox(string message, int type, string btn1, string btn2, string btn3)
        {
            return Support._sboApp.MessageBox(message, type, btn1, btn2, btn3);
        }

        internal static void ShowMessageInStatusBar(string message, BoStatusBarMessageType obj)
        {
            Support._sboApp.StatusBar.SetText(Support._statusbarMessagesPrefix + ": " + message, BoMessageTime.bmt_Short, obj);
        }

        internal static Matrix oMatrix
        {
            get
            {
                return Support._oMatrix;
            }
        }

        internal static SAPbouiCOM.Application pSbo
        {
            get
            {
                return Support._sboApp;
            }
        }

        internal static string StatusbarMessagesPrefix
        {
            set
            {
                Support._statusbarMessagesPrefix = value;
            }
        }

        private enum DecimalSeparatorType
        {
            Windows,
            Sbo,
        }

        internal struct EventFilterType
        {
            internal BoEventTypes _eventType;
            internal string[] _formUniqueId;
        }

        public enum itemToChangeType
        {
            TitleHeight,
            CellHeight,
        }
    }
}
