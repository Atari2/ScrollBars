// Decompiled with JetBrains decompiler
// Type: ScrollBars.Properties.Resources
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ScrollBars.Properties
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) ScrollBars.Properties.Resources.resourceMan, (object) null))
          ScrollBars.Properties.Resources.resourceMan = new ResourceManager("ScrollBars.Properties.Resources", typeof (ScrollBars.Properties.Resources).Assembly);
        return ScrollBars.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ScrollBars.Properties.Resources.resourceCulture;
      set => ScrollBars.Properties.Resources.resourceCulture = value;
    }
  }
}
