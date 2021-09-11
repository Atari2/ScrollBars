// Decompiled with JetBrains decompiler
// Type: ScrollBars.ImportExport
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ScrollBars
{
  internal static class ImportExport
  {
    public const double NEWESTFILEVERSION = 1.0;

    public static string GenerateScrollingEffectFileContents(ScrollingEffect scrollingEffect)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.AppendLine("//ScrollBars SMW HDMA Effect File");
      stringBuilder1.AppendLine();
      stringBuilder1.AppendLine("//Header:");
      stringBuilder1.AppendLine("ScrollBarsVersion = " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
      stringBuilder1.AppendLine("EffectType = " + (object) (byte) 0);
      stringBuilder1.AppendLine("FileVersion = " + (object) 1.0);
      stringBuilder1.AppendLine();
      stringBuilder1.AppendLine("//FreeAddrs:");
      foreach (FreeAddr freeAddr in scrollingEffect.FreeAddrs)
        stringBuilder1.AppendLine("RAM[0x" + freeAddr.Addr.ToString("X4") + "] = 0x" + ((int) freeAddr.LengthMinusOne + 1).ToString("X"));
      stringBuilder1.AppendLine();
      for (int index1 = 0; index1 < 4; ++index1)
      {
        stringBuilder1.AppendLine("//Layer " + (object) (index1 + 1) + ":");
        ScrollingEffectLayer layer = scrollingEffect.Layers[index1];
        stringBuilder1.AppendLine("BG[" + (object) index1 + "].En = " + layer.Enabled.ToString());
        stringBuilder1.AppendLine("BG[" + (object) index1 + "].VSE = " + layer.VerticalScrollEnabled.ToString());
        stringBuilder1.AppendLine("BG[" + (object) index1 + "].VWE = " + layer.VerticalWrapEnabled.ToString());
        stringBuilder1.AppendLine("BG[" + (object) index1 + "].CompEn = " + layer.CompressionEnabled.ToString());
        StringBuilder stringBuilder2 = stringBuilder1;
        object[] objArray1 = new object[4]
        {
          (object) "BG[",
          (object) index1,
          (object) "].Ch = ",
          null
        };
        object[] objArray2 = objArray1;
        int num = layer.Channel;
        string str1 = num.ToString();
        objArray2[3] = (object) str1;
        string str2 = string.Concat(objArray1);
        stringBuilder2.AppendLine(str2);
        StringBuilder stringBuilder3 = stringBuilder1;
        object[] objArray3 = new object[4]
        {
          (object) "BG[",
          (object) index1,
          (object) "].VSA = 0x",
          null
        };
        object[] objArray4 = objArray3;
        num = layer.VerticalScrollAddress;
        string str3 = num.ToString("X6");
        objArray4[3] = (object) str3;
        string str4 = string.Concat(objArray3);
        stringBuilder3.AppendLine(str4);
        ScrollingEffectLayerTableEntry[] table = layer.Table;
        for (int index2 = 0; index2 < table.Length; ++index2)
        {
          StringBuilder stringBuilder4 = stringBuilder1;
          object[] objArray5 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].Gr = ",
            null
          };
          object[] objArray6 = objArray5;
          num = table[index2].Group;
          string str5 = num.ToString();
          objArray6[5] = (object) str5;
          string str6 = string.Concat(objArray5);
          stringBuilder4.AppendLine(str6);
          StringBuilder stringBuilder5 = stringBuilder1;
          object[] objArray7 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].HSA = 0x",
            null
          };
          object[] objArray8 = objArray7;
          num = table[index2].HorizontalScrollAddress;
          string str7 = num.ToString("X6");
          objArray8[5] = (object) str7;
          string str8 = string.Concat(objArray7);
          stringBuilder5.AppendLine(str8);
          StringBuilder stringBuilder6 = stringBuilder1;
          object[] objArray9 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].MultI = ",
            null
          };
          object[] objArray10 = objArray9;
          num = table[index2].MultiplierIndex;
          string str9 = num.ToString();
          objArray10[5] = (object) str9;
          string str10 = string.Concat(objArray9);
          stringBuilder6.AppendLine(str10);
          StringBuilder stringBuilder7 = stringBuilder1;
          object[] objArray11 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].ScSp = 0x",
            null
          };
          object[] objArray12 = objArray11;
          num = table[index2].ScrollSpeed;
          string str11 = num.ToString("X");
          objArray12[5] = (object) str11;
          string str12 = string.Concat(objArray11);
          stringBuilder7.AppendLine(str12);
          stringBuilder1.AppendLine("BG[" + (object) index1 + "].Tb[0x" + index2.ToString("X3") + "].WdEn = " + table[index2].WindEnabled.ToString());
          StringBuilder stringBuilder8 = stringBuilder1;
          object[] objArray13 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WdSpI = ",
            null
          };
          object[] objArray14 = objArray13;
          num = table[index2].WindSpeedIndex;
          string str13 = num.ToString();
          objArray14[5] = (object) str13;
          string str14 = string.Concat(objArray13);
          stringBuilder8.AppendLine(str14);
          StringBuilder stringBuilder9 = stringBuilder1;
          object[] objArray15 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WdDir = ",
            null
          };
          object[] objArray16 = objArray15;
          num = table[index2].WindDirection;
          string str15 = num.ToString();
          objArray16[5] = (object) str15;
          string str16 = string.Concat(objArray15);
          stringBuilder9.AppendLine(str16);
          stringBuilder1.AppendLine("BG[" + (object) index1 + "].Tb[0x" + index2.ToString("X3") + "].WvEn = " + table[index2].WaveEnabled.ToString());
          StringBuilder stringBuilder10 = stringBuilder1;
          object[] objArray17 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WvL = 0x",
            null
          };
          object[] objArray18 = objArray17;
          num = table[index2].Wavelength;
          string str17 = num.ToString("X");
          objArray18[5] = (object) str17;
          string str18 = string.Concat(objArray17);
          stringBuilder10.AppendLine(str18);
          StringBuilder stringBuilder11 = stringBuilder1;
          object[] objArray19 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WvAm = 0x",
            null
          };
          object[] objArray20 = objArray19;
          num = table[index2].WaveAmplitude;
          string str19 = num.ToString("X");
          objArray20[5] = (object) str19;
          string str20 = string.Concat(objArray19);
          stringBuilder11.AppendLine(str20);
          StringBuilder stringBuilder12 = stringBuilder1;
          object[] objArray21 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WvPos = 0x",
            null
          };
          object[] objArray22 = objArray21;
          num = table[index2].WavePosition;
          string str21 = num.ToString("X");
          objArray22[5] = (object) str21;
          string str22 = string.Concat(objArray21);
          stringBuilder12.AppendLine(str22);
          StringBuilder stringBuilder13 = stringBuilder1;
          object[] objArray23 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WvSpI = ",
            null
          };
          object[] objArray24 = objArray23;
          num = table[index2].WaveSpeedIndex;
          string str23 = num.ToString();
          objArray24[5] = (object) str23;
          string str24 = string.Concat(objArray23);
          stringBuilder13.AppendLine(str24);
          StringBuilder stringBuilder14 = stringBuilder1;
          object[] objArray25 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WvDir = ",
            null
          };
          object[] objArray26 = objArray25;
          num = table[index2].WaveDirection;
          string str25 = num.ToString();
          objArray26[5] = (object) str25;
          string str26 = string.Concat(objArray25);
          stringBuilder14.AppendLine(str26);
          StringBuilder stringBuilder15 = stringBuilder1;
          object[] objArray27 = new object[6]
          {
            (object) "BG[",
            (object) index1,
            (object) "].Tb[0x",
            (object) index2.ToString("X3"),
            (object) "].WvTI = ",
            null
          };
          object[] objArray28 = objArray27;
          num = table[index2].WaveTypeIndex;
          string str27 = num.ToString();
          objArray28[5] = (object) str27;
          string str28 = string.Concat(objArray27);
          stringBuilder15.AppendLine(str28);
        }
      }
      return stringBuilder1.ToString();
    }

    public static ImportExport.ReadFileContentsResult ReadEffectFileContents(
      string contents)
    {
      List<ImportExport.Definition> definitions = new List<ImportExport.Definition>();
      string[] strArray = Regex.Split(contents, "\r\n");
      string message = (string) null;
      for (int index1 = 0; index1 < strArray.Length; ++index1)
      {
        List<string> keyLevels = new List<string>();
        string keyValue = "";
        StringBuilder stringBuilder = new StringBuilder();
        int num1 = 0;
        string str = strArray[index1];
        for (int index2 = 0; index2 < str.Length; ++index2)
        {
          char ch = str[index2];
          if (ch != '/' || index2 <= 0 || str[index2 - 1] != '/')
          {
            switch (num1)
            {
              case 0:
                switch (ch)
                {
                  case ' ':
                    keyLevels.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                    num1 = 1;
                    continue;
                  case '.':
                    keyLevels.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                    continue;
                  case '=':
                    keyLevels.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                    num1 = 6;
                    continue;
                  case '[':
                    keyLevels.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                    num1 = 2;
                    continue;
                  default:
                    stringBuilder.Append(ch);
                    continue;
                }
              case 1:
                int num2;
                switch (ch)
                {
                  case ' ':
                    num2 = 1;
                    break;
                  case '.':
                    num1 = 0;
                    continue;
                  case '=':
                    num1 = 6;
                    continue;
                  default:
                    num2 = ch == '\t' ? 1 : 0;
                    break;
                }
                if (num2 != 0)
                  break;
                goto label_43;
              case 2:
                int num3;
                switch (ch)
                {
                  case ' ':
                    num3 = 1;
                    break;
                  case ']':
                    keyLevels.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                    num1 = 5;
                    continue;
                  default:
                    num3 = ch == '\t' ? 1 : 0;
                    break;
                }
                if (num3 == 0)
                {
                  stringBuilder.Append(ch);
                  num1 = 3;
                  break;
                }
                break;
              case 3:
                if (ch == ' ' || ch == '\t')
                {
                  num1 = 4;
                  break;
                }
                if (ch == ']')
                {
                  keyLevels.Add(stringBuilder.ToString());
                  stringBuilder = new StringBuilder();
                  num1 = 5;
                  break;
                }
                stringBuilder.Append(ch);
                break;
              case 4:
                int num4;
                switch (ch)
                {
                  case ' ':
                    num4 = 1;
                    break;
                  case ']':
                    keyLevels.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                    num1 = 5;
                    continue;
                  default:
                    num4 = ch == '\t' ? 1 : 0;
                    break;
                }
                if (num4 != 0)
                  break;
                goto label_43;
              case 5:
                int num5;
                switch (ch)
                {
                  case ' ':
                    num5 = 1;
                    break;
                  case '.':
                    num1 = 0;
                    continue;
                  case '=':
                    num1 = 6;
                    continue;
                  case '[':
                    num1 = 3;
                    continue;
                  default:
                    num5 = ch == '\t' ? 1 : 0;
                    break;
                }
                if (num5 != 0)
                  break;
                goto label_43;
              case 6:
                if (ch != ' ' && ch != '\t')
                {
                  keyValue = str.Substring(index2);
                  goto label_43;
                }
                else
                  break;
            }
          }
          else
            break;
        }
label_43:
        if (num1 == 6 && keyLevels.Count > 0)
          definitions.Add(new ImportExport.Definition(keyLevels, keyValue));
      }
      ImportExport.Definition last1 = ImportExport.Definition.FindLast(definitions, "FileVersion", true);
      if (last1 == null)
      {
        message = "File format version not defined. Attempting to read file anyway.";
      }
      else
      {
        double result;
        if (!double.TryParse(last1.KeyValue, out result))
        {
          message = "Unable to determine file format version. Attempting to read file anyway.";
          result = 1.0;
        }
        else if (result > 1.0)
        {
          message = "File format version is too new. Attempting to read file anyway.";
          result = 1.0;
        }
      }
      ImportExport.Definition last2 = ImportExport.Definition.FindLast(definitions, "EffectType", true);
      if (last2 == null)
        return new ImportExport.ReadFileContentsResult((ScrollingEffect) null, "Effect type not defined.");
      int result1;
      if (!Numbers.IntTryParseWithHexPrefixSupport(last2.KeyValue, out result1))
        return new ImportExport.ReadFileContentsResult((ScrollingEffect) null, "Unable to determine effect type.");
      if (result1 != 0)
        return new ImportExport.ReadFileContentsResult((ScrollingEffect) null, "Unidentified effect type.");
      ScrollingEffect scrollingEffect = new ScrollingEffect();
      scrollingEffect.FreeAddrs.Clear();
      for (int index = 0; index < definitions.Count; ++index)
      {
        ImportExport.Definition definition = definitions[index];
        List<string> keyLevels = definition.KeyLevels;
        int result2;
        bool result3;
        if (keyLevels.Count > 1 && keyLevels[0] == "BG")
        {
          int result4;
          if (Numbers.IntTryParseWithHexPrefixSupport(keyLevels[1], out result4) && result4 >= 0 && result4 < 4)
          {
            if (keyLevels.Count == 5 && keyLevels[2] == "Tb")
            {
              int result5;
              if (Numbers.IntTryParseWithHexPrefixSupport(keyLevels[3], out result5) && result5 >= 0 && result5 < 512)
              {
                if (keyLevels[4] == "Gr")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].Group = result2 % 2;
                }
                else if (keyLevels[4] == "HSA")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].HorizontalScrollAddress = result2 & 16777215;
                }
                else if (keyLevels[4] == "MultI")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].MultiplierIndex = result2 % ScrollingEffectLayerTableEntry.MULTIPLIERVALUES.Length;
                }
                else if (keyLevels[4] == "ScSp")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].ScrollSpeed = result2 % 513;
                }
                else if (keyLevels[4] == "WdEn")
                {
                  if (bool.TryParse(definition.KeyValue, out result3))
                    scrollingEffect.Layers[result4].Table[result5].WindEnabled = result3;
                }
                else if (keyLevels[4] == "WdSpI")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].WindSpeedIndex = result2 % ScrollingEffectLayerTableEntry.WINDSPEEDVALUES.Length;
                }
                else if (keyLevels[4] == "WdDir")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].WindDirection = result2 % 2;
                }
                else if (keyLevels[4] == "WvEn")
                {
                  if (bool.TryParse(definition.KeyValue, out result3))
                    scrollingEffect.Layers[result4].Table[result5].WaveEnabled = result3;
                }
                else if (keyLevels[4] == "WvL")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].Wavelength = result2 % 513;
                }
                else if (keyLevels[4] == "WvAm")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].WaveAmplitude = result2 % 65536;
                }
                else if (keyLevels[4] == "WvPos")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].WavePosition = result2;
                }
                else if (keyLevels[4] == "WvSpI")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].WaveSpeedIndex = result2 % ScrollingEffectLayerTableEntry.WAVESPEEDVALUES.Length;
                }
                else if (keyLevels[4] == "WvDir")
                {
                  if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                    scrollingEffect.Layers[result4].Table[result5].WaveDirection = result2 % 2;
                }
                else if (keyLevels[4] == "WvTI" && Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                  scrollingEffect.Layers[result4].Table[result5].WaveTypeIndex = result2 % ScrollingEffectLayerTableEntry.WAVETYPEVALUES.Length;
              }
            }
            else if (keyLevels.Count == 3)
            {
              if (keyLevels[2] == "En")
              {
                if (bool.TryParse(definition.KeyValue, out result3))
                  scrollingEffect.Layers[result4].Enabled = result3;
              }
              else if (keyLevels[2] == "VSE")
              {
                if (bool.TryParse(definition.KeyValue, out result3))
                  scrollingEffect.Layers[result4].VerticalScrollEnabled = result3;
              }
              else if (keyLevels[2] == "VWE")
              {
                if (bool.TryParse(definition.KeyValue, out result3))
                  scrollingEffect.Layers[result4].VerticalWrapEnabled = result3;
              }
              else if (keyLevels[2] == "CompEn")
              {
                if (bool.TryParse(definition.KeyValue, out result3))
                  scrollingEffect.Layers[result4].CompressionEnabled = result3;
              }
              else if (keyLevels[2] == "Ch")
              {
                if (Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                  scrollingEffect.Layers[result4].Channel = result2 % 8;
              }
              else if (keyLevels[2] == "VSA" && Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result2))
                scrollingEffect.Layers[result4].VerticalScrollAddress = result2 & 16777215;
            }
          }
        }
        else
        {
          int result6;
          int result7;
          if (keyLevels.Count == 2 && keyLevels[0] == "RAM" && Numbers.IntTryParseWithHexPrefixSupport(keyLevels[1], out result6) && Numbers.IntTryParseWithHexPrefixSupport(definition.KeyValue, out result7))
            scrollingEffect.FreeAddrs.Add(new FreeAddr((ushort) result6, (ushort) (result7 - 1)));
        }
      }
      return new ImportExport.ReadFileContentsResult(scrollingEffect, message);
    }

    private class Definition
    {
      private List<string> keyLevels;
      private string keyValue;

      public Definition(List<string> keyLevels, string keyValue)
      {
        this.keyLevels = keyLevels;
        this.keyValue = keyValue;
      }

      public List<string> KeyLevels
      {
        get => this.keyLevels;
        set => this.keyLevels = value;
      }

      public string KeyValue
      {
        get => this.keyValue;
        set => this.keyValue = value;
      }

      public static List<ImportExport.Definition> FindAll(
        List<ImportExport.Definition> definitions,
        string[] baseKeyLevels,
        bool exact)
      {
        List<ImportExport.Definition> definitionList = new List<ImportExport.Definition>();
        for (int index1 = 0; index1 < definitions.Count; ++index1)
        {
          ImportExport.Definition definition = definitions[index1];
          if (definition.KeyLevels.Count == baseKeyLevels.Length || definition.KeyLevels.Count > baseKeyLevels.Length && !exact)
          {
            bool flag = true;
            for (int index2 = 0; index2 < baseKeyLevels.Length; ++index2)
            {
              if (baseKeyLevels[index2] != definition.KeyLevels[index2])
                flag = false;
            }
            if (flag)
              definitionList.Add(definition);
          }
        }
        return definitionList;
      }

      public static List<ImportExport.Definition> FindAll(
        List<ImportExport.Definition> definitions,
        string baseKeyLevel,
        bool exact)
      {
        return ImportExport.Definition.FindAll(definitions, new string[1]
        {
          baseKeyLevel
        }, (exact ? 1 : 0) != 0);
      }

      public static List<ImportExport.Definition> FindAll(
        List<ImportExport.Definition> definitions,
        List<string> baseKeyLevels,
        bool exact)
      {
        return ImportExport.Definition.FindAll(definitions, baseKeyLevels.ToArray(), exact);
      }

      public static ImportExport.Definition FindLast(
        List<ImportExport.Definition> definitions,
        string[] baseKeyLevels,
        bool exact)
      {
        List<ImportExport.Definition> all = ImportExport.Definition.FindAll(definitions, baseKeyLevels, exact);
        return all == null || all.Count == 0 ? (ImportExport.Definition) null : all[all.Count - 1];
      }

      public static ImportExport.Definition FindLast(
        List<ImportExport.Definition> definitions,
        string baseKeyLevel,
        bool exact)
      {
        return ImportExport.Definition.FindLast(definitions, new string[1]
        {
          baseKeyLevel
        }, (exact ? 1 : 0) != 0);
      }

      public static ImportExport.Definition FindLast(
        List<ImportExport.Definition> definitions,
        List<string> baseKeyLevels,
        bool exact)
      {
        return ImportExport.Definition.FindLast(definitions, baseKeyLevels.ToArray(), exact);
      }
    }

    public struct ReadFileContentsResult
    {
      private ScrollingEffect scrollingEffect;
      private string message;

      public ReadFileContentsResult(ScrollingEffect scrollingEffect, string message)
      {
        this.scrollingEffect = scrollingEffect;
        this.message = message;
      }

      public ScrollingEffect ScrollingEffect => this.scrollingEffect;

      public string Message => this.message;
    }
  }
}
