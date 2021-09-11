// Decompiled with JetBrains decompiler
// Type: ScrollBars.Numbers
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.Globalization;

namespace ScrollBars
{
  public static class Numbers
  {
    public static string FixAddressString(string hex, string defaultString)
    {
      int num;
      try
      {
        num = int.Parse(hex.Substring(Math.Max(hex.Length - 6, 0), Math.Min(6, hex.Length)), NumberStyles.HexNumber);
      }
      catch (Exception ex)
      {
        return defaultString;
      }
      if (hex.Length < 5 && num < 8192)
        num |= 8257536;
      return num.ToString("X6");
    }

    public static int IntParseSafe(string s, NumberStyles style, int defaultInt)
    {
      try
      {
        return int.Parse(s, style);
      }
      catch (Exception ex)
      {
        return defaultInt;
      }
    }

    public static bool IntTryParseWithHexPrefixSupport(string s, out int result)
    {
      NumberStyles style = NumberStyles.Any;
      if (s.Length >= 2 && s.Substring(0, 2) == "0x")
      {
        style = NumberStyles.HexNumber;
        s = s.Substring(2, s.Length - 2);
      }
      return int.TryParse(s, style, (IFormatProvider) CultureInfo.InvariantCulture.NumberFormat, out result);
    }

    public static int Bound(int n, int min, int max) => Math.Min(Math.Max(n, min), max);

    public static double Bound(double n, double min, double max) => Math.Min(Math.Max(n, min), max);
  }
}
