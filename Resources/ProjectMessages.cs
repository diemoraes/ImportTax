// Decompiled with JetBrains decompiler
// Type: TaxDeterminationLoader.Resources.ProjectMessages
// Assembly: TaxDeterminationLoader, Version=91.9.86.6, Culture=neutral, PublicKeyToken=null
// MVID: BA235D23-3174-4C88-BD2A-DB8A9B592F45
// Assembly location: C:\Users\diego.moraes\Desktop\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\TaxDeterminationLoader - 91.09.86.6\taxdeterminationloader.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace TaxDeterminationLoader.Resources
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class ProjectMessages
  {
    private static CultureInfo resourceCulture;
    private static ResourceManager resourceMan;

    internal ProjectMessages()
    {
    }

    internal static string BatchStockInsufficient
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (BatchStockInsufficient), ProjectMessages.resourceCulture);
      }
    }

    internal static string BlankFilePath
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (BlankFilePath), ProjectMessages.resourceCulture);
      }
    }

    internal static string BlankSeparatorChar
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (BlankSeparatorChar), ProjectMessages.resourceCulture);
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return ProjectMessages.resourceCulture;
      }
      set
      {
        ProjectMessages.resourceCulture = value;
      }
    }

    internal static string DetTypeWrong
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (DetTypeWrong), ProjectMessages.resourceCulture);
      }
    }

    internal static string EfectFromMandatory
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (EfectFromMandatory), ProjectMessages.resourceCulture);
      }
    }

    internal static string Error1
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (Error1), ProjectMessages.resourceCulture);
      }
    }

    internal static string FailedImport
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (FailedImport), ProjectMessages.resourceCulture);
      }
    }

    internal static string FileNotExist
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (FileNotExist), ProjectMessages.resourceCulture);
      }
    }

    internal static string FileProblems1
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (FileProblems1), ProjectMessages.resourceCulture);
      }
    }

    internal static string FileProblems2
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (FileProblems2), ProjectMessages.resourceCulture);
      }
    }

    internal static string FileProblems3
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (FileProblems3), ProjectMessages.resourceCulture);
      }
    }

    internal static string InvalidDate
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (InvalidDate), ProjectMessages.resourceCulture);
      }
    }

    internal static string InvalidState
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (InvalidState), ProjectMessages.resourceCulture);
      }
    }

    internal static string InvalidTaxCode
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (InvalidTaxCode), ProjectMessages.resourceCulture);
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ProjectMessages.resourceMan == null)
          ProjectMessages.resourceMan = new ResourceManager("TaxDeterminationLoader.Resources.ProjectMessages", typeof (ProjectMessages).Assembly);
        return ProjectMessages.resourceMan;
      }
    }

    internal static string SQLError
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (SQLError), ProjectMessages.resourceCulture);
      }
    }

    internal static string SucessImport
    {
      get
      {
        return ProjectMessages.ResourceManager.GetString(nameof (SucessImport), ProjectMessages.resourceCulture);
      }
    }
  }
}
