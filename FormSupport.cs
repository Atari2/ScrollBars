// Decompiled with JetBrains decompiler
// Type: ScrollBars.FormSupport
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System.Windows.Forms;

namespace ScrollBars
{
  public static class FormSupport
  {
    public static void OpenFormAsDialog(Form parentForm, Form dialogForm)
    {
      dialogForm.TopMost = true;
      dialogForm.Show((IWin32Window) parentForm);
      parentForm.Enabled = false;
    }
  }
}
