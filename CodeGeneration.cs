// Decompiled with JetBrains decompiler
// Type: ScrollBars.CodeGeneration
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.Collections.Generic;
using System.Text;

namespace ScrollBars
{
  internal static class CodeGeneration
  {
    public static string GenerateScrollingEffectCode(ScrollingEffect scrollingEffect)
    {
      List<FreeAddr> optimizedFreeAddrList = FreeAddr.GenerateOptimizedFreeAddrList(scrollingEffect.FreeAddrs);
      List<CodeGeneration.ScrollingEffectLayerTableEntryAssociation> scrollingEffectLayerTableAssociations = new List<CodeGeneration.ScrollingEffectLayerTableEntryAssociation>();
      int[][] numArray = new int[4][];
      bool flag1 = false;
      bool flag2 = false;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      StringBuilder stringBuilder6 = new StringBuilder();
      StringBuilder stringBuilder7 = new StringBuilder();
      List<CodeGeneration.WindOffsetAddressAssociation> addressAssociationList1 = new List<CodeGeneration.WindOffsetAddressAssociation>();
      List<CodeGeneration.WaveTableAssociation> tableAssociationList1 = new List<CodeGeneration.WaveTableAssociation>();
      List<CodeGeneration.WaveOffsetAddressAssociation> addressAssociationList2 = new List<CodeGeneration.WaveOffsetAddressAssociation>();
      for (int index1 = 0; index1 < 4; ++index1)
      {
        if (scrollingEffect.Layers[index1].Enabled)
        {
          ScrollingEffectLayerTableEntry[] table = scrollingEffect.Layers[index1].Table;
          int realTableLength = (int) scrollingEffect.Layers[index1].GetRealTableLength();
          numArray[index1] = new int[realTableLength];
          for (int index2 = 0; index2 < realTableLength; ++index2)
          {
            int num = CodeGeneration.ScrollingEffectLayerTableEntryAssociation.FindScrollingEffectLayerTableEntryIndex(scrollingEffectLayerTableAssociations, table[index2]);
            if (num == -1)
            {
              num = scrollingEffectLayerTableAssociations.Count;
              FreeAddr freeAddr;
              try
              {
                freeAddr = FreeAddr.GetFreeAddr(ref optimizedFreeAddrList, (ushort) 2);
              }
              catch (FreeAddr.NotEnoughFreeAddrsException ex)
              {
                throw new FreeAddr.NotEnoughFreeAddrsException();
              }
              scrollingEffectLayerTableAssociations.Add(new CodeGeneration.ScrollingEffectLayerTableEntryAssociation(table[index2], freeAddr.Addr));
            }
            numArray[index1][index2] = num;
          }
        }
      }
      stringBuilder5.AppendLine("\tREP #%00100000");
      stringBuilder6.AppendLine("\tREP #%00100000");
      for (int index3 = 0; index3 < scrollingEffectLayerTableAssociations.Count; ++index3)
      {
        CodeGeneration.ScrollingEffectLayerTableEntryAssociation entryAssociation1 = scrollingEffectLayerTableAssociations[index3];
        List<CodeGeneration.ScrollingEffectLayerTableEntryAssociation> currentScrollingEffectLayerTableEntryAssociations = new List<CodeGeneration.ScrollingEffectLayerTableEntryAssociation>();
        ScrollingEffectLayerTableEntry effectLayerTableEntry;
        int num1;
        if (!entryAssociation1.Used)
        {
          effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
          num1 = effectLayerTableEntry.ScrollSpeed != 0 ? 1 : 0;
        }
        else
          num1 = 0;
        if (num1 != 0)
        {
          for (int index4 = 0; index4 < scrollingEffectLayerTableAssociations.Count; ++index4)
          {
            CodeGeneration.ScrollingEffectLayerTableEntryAssociation entryAssociation2 = scrollingEffectLayerTableAssociations[index4];
            int num2;
            if (!entryAssociation1.Used)
            {
              effectLayerTableEntry = entryAssociation2.ScrollingEffectLayerTableEntry;
              if (effectLayerTableEntry.ScrollSpeed != 0)
              {
                effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
                num2 = effectLayerTableEntry.InSameSetAs(entryAssociation2.ScrollingEffectLayerTableEntry) ? 1 : 0;
              }
              else
                num2 = 1;
            }
            else
              num2 = 0;
            if (num2 != 0)
            {
              entryAssociation2.Used = true;
              currentScrollingEffectLayerTableEntryAssociations.Add(entryAssociation2);
              scrollingEffectLayerTableAssociations[index4] = entryAssociation2;
            }
          }
          StringBuilder stringBuilder8 = new StringBuilder();
          effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
          if (effectLayerTableEntry.WaveEnabled)
          {
            List<CodeGeneration.WaveTableAssociation> waveTableAssociations = tableAssociationList1;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int wavelength1 = effectLayerTableEntry.Wavelength;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int waveAmplitude1 = effectLayerTableEntry.WaveAmplitude;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int waveTypeIndex1 = effectLayerTableEntry.WaveTypeIndex;
            int num3 = CodeGeneration.WaveTableAssociation.FindWaveTableIndex(waveTableAssociations, wavelength1, waveAmplitude1, waveTypeIndex1);
            if (num3 == -1)
            {
              num3 = tableAssociationList1.Count;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int wavelength2 = effectLayerTableEntry.Wavelength;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveAmplitude2 = effectLayerTableEntry.WaveAmplitude;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveTypeIndex2 = effectLayerTableEntry.WaveTypeIndex;
              ushort[] waveCoordinates = CodeGeneration.getWaveCoordinates(wavelength2, waveAmplitude2, waveTypeIndex2);
              List<CodeGeneration.WaveTableAssociation> tableAssociationList2 = tableAssociationList1;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int wavelength3 = effectLayerTableEntry.Wavelength;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveAmplitude3 = effectLayerTableEntry.WaveAmplitude;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveTypeIndex3 = effectLayerTableEntry.WaveTypeIndex;
              CodeGeneration.WaveTableAssociation tableAssociation = new CodeGeneration.WaveTableAssociation(wavelength3, waveAmplitude3, waveTypeIndex3);
              tableAssociationList2.Add(tableAssociation);
              stringBuilder7.Append(".WTbl" + (object) num3);
              stringBuilder7.Append(CodeGeneration.ushortArrayToWordTable(waveCoordinates));
              stringBuilder7.AppendLine();
              stringBuilder7.AppendLine();
            }
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int wavePosition = effectLayerTableEntry.WavePosition;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int wavelength4 = effectLayerTableEntry.Wavelength;
            int num4 = wavePosition % wavelength4;
            List<CodeGeneration.WaveOffsetAddressAssociation> waveOffsetAddressAssociations = addressAssociationList2;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int wavelength5 = effectLayerTableEntry.Wavelength;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int waveSpeedIndex1 = effectLayerTableEntry.WaveSpeedIndex;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int waveDirection1 = effectLayerTableEntry.WaveDirection;
            int direction = num4;
            int index5 = CodeGeneration.WaveOffsetAddressAssociation.FindWaveOffsetAddressIndex(waveOffsetAddressAssociations, wavelength5, waveSpeedIndex1, waveDirection1, direction);
            if (index5 == -1)
            {
              index5 = addressAssociationList2.Count;
              int address1 = (int) FreeAddr.GetFreeAddr(ref optimizedFreeAddrList, (ushort) 2).Addr | (int) scrollingEffect.Bank << 16;
              List<CodeGeneration.WaveOffsetAddressAssociation> addressAssociationList3 = addressAssociationList2;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int wavelength6 = effectLayerTableEntry.Wavelength;
              int speed = num4;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveSpeedIndex2 = effectLayerTableEntry.WaveSpeedIndex;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveDirection2 = effectLayerTableEntry.WaveDirection;
              int address2 = address1;
              CodeGeneration.WaveOffsetAddressAssociation addressAssociation = new CodeGeneration.WaveOffsetAddressAssociation(wavelength6, speed, waveSpeedIndex2, waveDirection2, address2);
              addressAssociationList3.Add(addressAssociation);
              StringBuilder stringBuilder9 = stringBuilder4;
              int address3 = address1;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveSpeedIndex3 = effectLayerTableEntry.WaveSpeedIndex;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int waveDirection3 = effectLayerTableEntry.WaveDirection;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int wavelength7 = effectLayerTableEntry.Wavelength;
              string str = CodeGeneration.incrementUpdaterCode16Bit16BitForWaveIndex(address3, waveSpeedIndex3, waveDirection3, wavelength7);
              stringBuilder9.Append(str);
              stringBuilder1.AppendLine("\tLDA.b #$" + ((byte) (num4 << 1)).ToString("X2"));
              stringBuilder1.AppendLine("\tSTA" + CodeGeneration.ramAddressReferenceCode(address1));
              if ((num4 & (int) byte.MaxValue) != num4 >> 8)
                stringBuilder1.AppendLine("\tLDA.b #$" + ((byte) (num4 >> 7)).ToString("X2"));
              stringBuilder1.AppendLine("\tSTA" + CodeGeneration.ramAddressReferenceCode(address1 & 16711680 | address1 + 1 & (int) ushort.MaxValue));
            }
            int address = addressAssociationList2[index5].Address;
            stringBuilder8.AppendLine("\tLDA" + CodeGeneration.ramAddressReferenceCode(address));
            StringBuilder stringBuilder10 = stringBuilder8;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            string str1 = CodeGeneration.multDiv(effectLayerTableEntry.MultiplierIndex);
            stringBuilder10.Append(str1);
            stringBuilder8.AppendLine("\tREP #%00010000");
            stringBuilder8.AppendLine("\tTAX");
            stringBuilder8.AppendLine("\tLDA.w .WTbl" + (object) num3 + ",x");
            stringBuilder8.AppendLine("\tSEP #%00010000");
            StringBuilder stringBuilder11 = stringBuilder8;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            string str2 = "\tCLC : ADC" + CodeGeneration.ramAddressReferenceCode(effectLayerTableEntry.HorizontalScrollAddress);
            stringBuilder11.AppendLine(str2);
          }
          else
          {
            StringBuilder stringBuilder12 = stringBuilder8;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            string str3 = "\tLDA" + CodeGeneration.ramAddressReferenceCode(effectLayerTableEntry.HorizontalScrollAddress);
            stringBuilder12.AppendLine(str3);
            StringBuilder stringBuilder13 = stringBuilder8;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            string str4 = CodeGeneration.multDiv(effectLayerTableEntry.MultiplierIndex);
            stringBuilder13.Append(str4);
          }
          effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
          if (effectLayerTableEntry.WindEnabled)
          {
            List<CodeGeneration.WindOffsetAddressAssociation> windOffsetAddressAssociations = addressAssociationList1;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int windSpeedIndex1 = effectLayerTableEntry.WindSpeedIndex;
            effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
            int windDirection1 = effectLayerTableEntry.WindDirection;
            int index6 = CodeGeneration.WindOffsetAddressAssociation.FindWindOffsetAddressIndex(windOffsetAddressAssociations, windSpeedIndex1, windDirection1);
            if (index6 == -1)
            {
              index6 = addressAssociationList1.Count;
              int address4 = (int) FreeAddr.GetFreeAddr(ref optimizedFreeAddrList, (ushort) 2).Addr | (int) scrollingEffect.Bank << 16;
              List<CodeGeneration.WindOffsetAddressAssociation> addressAssociationList4 = addressAssociationList1;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int windSpeedIndex2 = effectLayerTableEntry.WindSpeedIndex;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int windDirection2 = effectLayerTableEntry.WindDirection;
              int address5 = address4;
              CodeGeneration.WindOffsetAddressAssociation addressAssociation = new CodeGeneration.WindOffsetAddressAssociation(windSpeedIndex2, windDirection2, address5);
              addressAssociationList4.Add(addressAssociation);
              stringBuilder1.Append(CodeGeneration.stzCode(address4, "A", false, true));
              StringBuilder stringBuilder14 = stringBuilder4;
              int address6 = address4;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int windSpeedIndex3 = effectLayerTableEntry.WindSpeedIndex;
              effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
              int windDirection3 = effectLayerTableEntry.WindDirection;
              string str = CodeGeneration.incrementUpdaterCode16Bit(address6, windSpeedIndex3, windDirection3, true);
              stringBuilder14.Append(str);
            }
            int address = addressAssociationList1[index6].Address;
            stringBuilder8.AppendLine("\tCLC : ADC" + CodeGeneration.ramAddressReferenceCode(address));
            stringBuilder8.AppendLine("\tSTA.b $00");
          }
          stringBuilder8.AppendLine("\tSTA.b $00");
          string speedUpdaterCode = CodeGeneration.generateScrollingEffectSpeedUpdaterCode(scrollingEffect.Bank, currentScrollingEffectLayerTableEntryAssociations);
          effectLayerTableEntry = entryAssociation1.ScrollingEffectLayerTableEntry;
          if (effectLayerTableEntry.Group == 0)
          {
            stringBuilder5.Append(stringBuilder8.ToString());
            stringBuilder5.AppendLine(speedUpdaterCode);
            flag1 = true;
          }
          else
          {
            stringBuilder5.Append(stringBuilder8.ToString());
            stringBuilder6.AppendLine(speedUpdaterCode);
            flag2 = true;
          }
        }
      }
      stringBuilder5.AppendLine("\tSEP #%00100000");
      stringBuilder5.AppendLine("\tRTS");
      stringBuilder6.AppendLine("\tSEP #%00100000");
      stringBuilder6.AppendLine("\tRTS");
      stringBuilder2.AppendLine("\tREP #%00010000");
      for (int index7 = 0; index7 < 4; ++index7)
      {
        if (scrollingEffect.Layers[index7].Enabled)
        {
          int length = numArray[index7].Length;
          if (scrollingEffect.Layers[index7].VerticalWrapEnabled)
            length += 223;
          stringBuilder7.Append(".HTbl" + (object) (index7 + 1));
          for (int index8 = 0; index8 < length; ++index8)
            stringBuilder7.AppendLine("\tdb $01 : dw $" + scrollingEffectLayerTableAssociations[numArray[index7][index8 & 511]].Destination.ToString("X4"));
          stringBuilder7.AppendLine("\tdb $00");
          stringBuilder7.AppendLine();
          stringBuilder2.AppendLine("\tLDA.b #%01000010");
          stringBuilder2.AppendLine("\tSTA.w $43" + (object) scrollingEffect.Layers[index7].Channel + "0");
          stringBuilder2.AppendLine("\tLDA.b #$" + (index7 * 2 + 13).ToString("X2"));
          stringBuilder2.AppendLine("\tSTA.w $43" + (object) scrollingEffect.Layers[index7].Channel + "1");
          if (scrollingEffect.Layers[index7].VerticalScrollEnabled)
          {
            string str = CodeGeneration.ramAddressReferenceCode(scrollingEffect.Layers[index7].VerticalScrollAddress);
            stringBuilder2.AppendLine("\tREP #%00100000");
            stringBuilder2.AppendLine("\tLDA" + str);
            stringBuilder2.AppendLine("\tAND.w #$01FF");
            stringBuilder2.AppendLine("\tSTA.b $00");
            stringBuilder2.AppendLine("\tASL");
            stringBuilder2.AppendLine("\tCLC");
            stringBuilder2.AppendLine("\tADC.b $00");
            stringBuilder2.AppendLine("\tCLC");
            stringBuilder2.AppendLine("\tADC.w #.HTbl" + (object) (index7 + 1));
            stringBuilder2.AppendLine("\tSTA.w $43" + (object) scrollingEffect.Layers[index7].Channel + "2");
            stringBuilder2.AppendLine("\tSEP #%00100000");
          }
          else
          {
            stringBuilder2.AppendLine("\tLDX.w #.HTbl" + (object) (index7 + 1));
            stringBuilder2.AppendLine("\tSTX.w $43" + (object) scrollingEffect.Layers[index7].Channel + "2");
          }
          stringBuilder2.AppendLine("\tLDA.b #.HTbl" + (object) (index7 + 1) + ">>16");
          stringBuilder2.AppendLine("\tSTA.w $43" + (object) scrollingEffect.Layers[index7].Channel + "4");
          stringBuilder2.AppendLine("\tLDA.b #$" + scrollingEffect.Bank.ToString("X2"));
          stringBuilder2.AppendLine("\tSTA.w $43" + (object) scrollingEffect.Layers[index7].Channel + "7");
          stringBuilder2.AppendLine("\tLDA.b #%" + Convert.ToString((int) Math.Pow(2.0, (double) scrollingEffect.Layers[index7].Channel), 2));
          stringBuilder2.AppendLine("\tTSB.w $0D9F");
        }
      }
      stringBuilder2.AppendLine("\tSEP #%00010000");
      if (flag1)
        stringBuilder1.AppendLine("\tJSR {MainCodeLabel}_Grp1");
      if (flag2)
        stringBuilder1.AppendLine("\tJSR {MainCodeLabel}_Grp2");
      stringBuilder1.AppendLine("\tRTL");
      if (flag1 && flag2)
      {
        stringBuilder7.AppendLine(".Grps\tdw .Grp1,.Grp2");
        stringBuilder2.AppendLine("LDA.b $14");
        stringBuilder2.AppendLine("AND.b #%00000001");
        stringBuilder2.AppendLine("ASL");
        stringBuilder2.AppendLine("TAX");
        stringBuilder2.AppendLine("JSR (.Grps,x)");
      }
      else if (flag1)
        stringBuilder2.AppendLine("\tJSR .Grp1");
      else if (flag2)
        stringBuilder2.AppendLine("\tJSR .Grp2");
      stringBuilder2.AppendLine("\tRTL");
      StringBuilder stringBuilder15 = new StringBuilder();
      stringBuilder15.AppendLine("{InitCodeLabel}:");
      stringBuilder15.Append(stringBuilder1.ToString());
      stringBuilder15.AppendLine();
      stringBuilder15.AppendLine("{MainCodeLabel}:");
      if (stringBuilder4.Length + stringBuilder3.Length > 0)
      {
        stringBuilder15.AppendLine("\tLDA.w $13D4");
        stringBuilder15.AppendLine("\tBEQ +");
        stringBuilder15.AppendLine("\tJMP .skip");
        stringBuilder15.Append("+");
      }
      if (stringBuilder4.Length > 0)
      {
        stringBuilder15.AppendLine("\tREP #%00100000");
        stringBuilder15.Append(stringBuilder4.ToString());
        stringBuilder15.AppendLine("\tSEP #%00100000");
      }
      stringBuilder15.Append(stringBuilder3.ToString());
      if (stringBuilder4.Length + stringBuilder3.Length > 0)
        stringBuilder15.Append(".skip");
      stringBuilder15.Append(stringBuilder2.ToString());
      stringBuilder15.AppendLine();
      if (flag1)
      {
        stringBuilder15.Append(".Grp1");
        stringBuilder15.Append(stringBuilder5.ToString());
        stringBuilder15.AppendLine();
      }
      if (flag2)
      {
        stringBuilder15.Append(".Grp2");
        stringBuilder15.Append(stringBuilder6.ToString());
        stringBuilder15.AppendLine();
      }
      stringBuilder15.AppendLine(stringBuilder7.ToString());
      return stringBuilder15.ToString();
    }

    private static string generateScrollingEffectSpeedUpdaterCode(
      byte bank,
      List<CodeGeneration.ScrollingEffectLayerTableEntryAssociation> currentScrollingEffectLayerTableEntryAssociations)
    {
      int[] numArray = new int[513];
      StringBuilder stringBuilder1 = new StringBuilder();
      string str1 = bank.ToString("X2");
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = -1;
      foreach (CodeGeneration.ScrollingEffectLayerTableEntryAssociation entryAssociation in currentScrollingEffectLayerTableEntryAssociations)
      {
        if (entryAssociation.ScrollingEffectLayerTableEntry.ScrollSpeed < numArray.Length)
          numArray[entryAssociation.ScrollingEffectLayerTableEntry.ScrollSpeed] = (int) entryAssociation.Destination;
      }
      for (int index = 0; index < 512; index += 4)
      {
        if (numArray[index + 1] != -1 || numArray[index + 3] != -1)
        {
          stringBuilder1.AppendLine("\tLDY.b #$00");
          stringBuilder1.AppendLine("\tLDA.b $00");
          stringBuilder1.AppendLine("\tBPL +");
          stringBuilder1.AppendLine("\tINY");
          stringBuilder1.AppendLine("\tEOR.w #$FFFF");
          stringBuilder1.AppendLine("\tINC A");
          stringBuilder1.AppendLine("+\tCLC");
          stringBuilder1.AppendLine("\tADC.w #$0080");
          stringBuilder1.AppendLine("\tXBA");
          stringBuilder1.AppendLine("\tAND.w #$00FF");
          stringBuilder1.AppendLine("\tCPY.b #$00");
          stringBuilder1.AppendLine("\tBEQ +");
          stringBuilder1.AppendLine("\tEOR.w #$FFFF");
          stringBuilder1.AppendLine("\tINC A");
          stringBuilder1.AppendLine("+\tSTA.b $02");
          break;
        }
      }
      for (int index = 0; index < 512; index += 4)
      {
        if (numArray[index + 2] != -1 || numArray[index + 3] != -1)
        {
          stringBuilder1.AppendLine("\tLDY.b #$00");
          stringBuilder1.AppendLine("\tLDA.b $00");
          stringBuilder1.AppendLine("\tLSR");
          stringBuilder1.AppendLine("\tBPL +");
          stringBuilder1.AppendLine("\tINY");
          stringBuilder1.AppendLine("\tEOR.w #$FFFF");
          stringBuilder1.AppendLine("\tINC A");
          stringBuilder1.AppendLine("+\tCLC");
          stringBuilder1.AppendLine("\tADC.w #$0080");
          stringBuilder1.AppendLine("\tXBA");
          stringBuilder1.AppendLine("\tAND.w #$007F");
          stringBuilder1.AppendLine("\tCPY.b #$00");
          stringBuilder1.AppendLine("\tBEQ +");
          stringBuilder1.AppendLine("\tEOR.w #$FFFF");
          stringBuilder1.AppendLine("\tINC A");
          stringBuilder1.AppendLine("+\tSTA.b $04");
          break;
        }
      }
      if ((currentScrollingEffectLayerTableEntryAssociations.Count != 1 || currentScrollingEffectLayerTableEntryAssociations[0].ScrollingEffectLayerTableEntry.ScrollSpeed != 512) && (currentScrollingEffectLayerTableEntryAssociations.Count != 1 || currentScrollingEffectLayerTableEntryAssociations[0].ScrollingEffectLayerTableEntry.ScrollSpeed != 0) && (currentScrollingEffectLayerTableEntryAssociations.Count != 2 || (currentScrollingEffectLayerTableEntryAssociations[0].ScrollingEffectLayerTableEntry.ScrollSpeed != 0 || currentScrollingEffectLayerTableEntryAssociations[1].ScrollingEffectLayerTableEntry.ScrollSpeed != 512) && (currentScrollingEffectLayerTableEntryAssociations[1].ScrollingEffectLayerTableEntry.ScrollSpeed != 0 || currentScrollingEffectLayerTableEntryAssociations[0].ScrollingEffectLayerTableEntry.ScrollSpeed != 512)))
      {
        stringBuilder1.AppendLine("\tLDX.b $00");
        stringBuilder1.AppendLine("\tSTX.w $211B");
        stringBuilder1.AppendLine("\tLDX.b $01");
        stringBuilder1.AppendLine("\tSTX.w $211B");
      }
      if (numArray[0] != -1)
      {
        stringBuilder1.AppendLine("\tLDA.w #$0000");
        stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[0] & (int) ushort.MaxValue).ToString("X4"));
      }
      int num;
      if (numArray[1] != -1)
      {
        if (numArray[2] != -1)
        {
          if (numArray[3] != -1)
          {
            stringBuilder1.AppendLine("\tLDA.b $04");
            stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[1] & (int) ushort.MaxValue).ToString("X4"));
            stringBuilder1.AppendLine("\tCLC : ADC.b $02");
            StringBuilder stringBuilder2 = stringBuilder1;
            string str2 = str1;
            num = numArray[3] & (int) ushort.MaxValue;
            string str3 = num.ToString("X4");
            string str4 = "\tSTA.l $" + str2 + str3;
            stringBuilder2.AppendLine(str4);
            stringBuilder1.AppendLine("\tLDAs.b $02");
            StringBuilder stringBuilder3 = stringBuilder1;
            string str5 = str1;
            num = numArray[2] & (int) ushort.MaxValue;
            string str6 = num.ToString("X4");
            string str7 = "\tSTA.l $" + str5 + str6;
            stringBuilder3.AppendLine(str7);
          }
          else
          {
            stringBuilder1.AppendLine("\tLDA.b $04");
            stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[1] & (int) ushort.MaxValue).ToString("X4"));
            stringBuilder1.AppendLine("\tLDA.b $02");
            StringBuilder stringBuilder4 = stringBuilder1;
            string str8 = str1;
            num = numArray[2] & (int) ushort.MaxValue;
            string str9 = num.ToString("X4");
            string str10 = "\tSTA.l $" + str8 + str9;
            stringBuilder4.AppendLine(str10);
          }
        }
        else if (numArray[3] != -1)
        {
          stringBuilder1.AppendLine("\tLDA.b $04");
          stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[1] & (int) ushort.MaxValue).ToString("X4"));
          stringBuilder1.AppendLine("\tCLC : ADC.b $02");
          StringBuilder stringBuilder5 = stringBuilder1;
          string str11 = str1;
          num = numArray[3] & (int) ushort.MaxValue;
          string str12 = num.ToString("X4");
          string str13 = "\tSTA.l $" + str11 + str12;
          stringBuilder5.AppendLine(str13);
        }
        else
        {
          stringBuilder1.AppendLine("\tLDA.b $04");
          stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[1] & (int) ushort.MaxValue).ToString("X4"));
        }
      }
      else if (numArray[2] != -1)
      {
        if (numArray[3] != -1)
        {
          stringBuilder1.AppendLine("\tLDA.b $02");
          stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[2] & (int) ushort.MaxValue).ToString("X4"));
          stringBuilder1.AppendLine("\tCLC : ADC.b $04");
          StringBuilder stringBuilder6 = stringBuilder1;
          string str14 = str1;
          num = numArray[3] & (int) ushort.MaxValue;
          string str15 = num.ToString("X4");
          string str16 = "\tSTA.l $" + str14 + str15;
          stringBuilder6.AppendLine(str16);
        }
        else
        {
          stringBuilder1.AppendLine("\tLDA.b $02");
          stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[2] & (int) ushort.MaxValue).ToString("X4"));
        }
      }
      else if (numArray[3] != -1)
      {
        stringBuilder1.AppendLine("\tLDA.b $02");
        stringBuilder1.AppendLine("\tCLC : ADC.b $04");
        stringBuilder1.AppendLine("\tSTA.l $" + str1 + (numArray[3] & (int) ushort.MaxValue).ToString("X4"));
      }
      for (int index = 4; index < 512; index += 4)
      {
        if (numArray[index] != -1 || numArray[index + 1] != -1 || numArray[index + 2] != -1 || numArray[index + 3] != -1)
        {
          StringBuilder stringBuilder7 = stringBuilder1;
          num = index >> 2;
          string str17 = "\tLDX.b #$" + num.ToString("X2");
          stringBuilder7.AppendLine(str17);
          stringBuilder1.AppendLine("\tSTX.w $211C");
          stringBuilder1.AppendLine("\tLDA.w $2134");
          stringBuilder1.AppendLine("\tASL");
          stringBuilder1.AppendLine("\tAND.w #$FF00");
          stringBuilder1.AppendLine("\tADC.w #$0000");
          stringBuilder1.AppendLine("\tXBA");
          if (numArray[index] != -1)
          {
            StringBuilder stringBuilder8 = stringBuilder1;
            string str18 = str1;
            num = numArray[index] & (int) ushort.MaxValue;
            string str19 = num.ToString("X4");
            string str20 = "\tSTA.l $" + str18 + str19;
            stringBuilder8.AppendLine(str20);
          }
          if (numArray[index + 1] != -1)
          {
            if (numArray[index + 2] != -1)
            {
              if (numArray[index] == -1)
                stringBuilder1.AppendLine("\tSTA.b $06");
              if (numArray[index + 3] != -1)
              {
                stringBuilder1.AppendLine("\tCLC : ADC.b $04");
                StringBuilder stringBuilder9 = stringBuilder1;
                string str21 = str1;
                num = numArray[index + 1] & (int) ushort.MaxValue;
                string str22 = num.ToString("X4");
                string str23 = "\tSTA.l $" + str21 + str22;
                stringBuilder9.AppendLine(str23);
                stringBuilder1.AppendLine("\tCLC : ADC.b $02");
                StringBuilder stringBuilder10 = stringBuilder1;
                string str24 = str1;
                num = numArray[index + 3] & (int) ushort.MaxValue;
                string str25 = num.ToString("X4");
                string str26 = "\tSTA.l $" + str24 + str25;
                stringBuilder10.AppendLine(str26);
                if (numArray[index] == -1)
                {
                  stringBuilder1.AppendLine("\tLDA.b $06");
                }
                else
                {
                  StringBuilder stringBuilder11 = stringBuilder1;
                  string str27 = str1;
                  num = numArray[index] & (int) ushort.MaxValue;
                  string str28 = num.ToString("X4");
                  string str29 = "\tLDA.l $" + str27 + str28;
                  stringBuilder11.AppendLine(str29);
                }
                stringBuilder1.AppendLine("\tCLC : ADC.b $02");
                StringBuilder stringBuilder12 = stringBuilder1;
                string str30 = str1;
                num = numArray[index + 2] & (int) ushort.MaxValue;
                string str31 = num.ToString("X4");
                string str32 = "\tSTA.l $" + str30 + str31;
                stringBuilder12.AppendLine(str32);
              }
              else
              {
                stringBuilder1.AppendLine("\tCLC : ADC.b $04");
                StringBuilder stringBuilder13 = stringBuilder1;
                string str33 = str1;
                num = numArray[index + 1] & (int) ushort.MaxValue;
                string str34 = num.ToString("X4");
                string str35 = "\tSTA.l $" + str33 + str34;
                stringBuilder13.AppendLine(str35);
                if (numArray[index] == -1)
                {
                  stringBuilder1.AppendLine("\tLDA.b $06");
                }
                else
                {
                  StringBuilder stringBuilder14 = stringBuilder1;
                  string str36 = str1;
                  num = numArray[index] & (int) ushort.MaxValue;
                  string str37 = num.ToString("X4");
                  string str38 = "\tLDA.l $" + str36 + str37;
                  stringBuilder14.AppendLine(str38);
                }
                stringBuilder1.AppendLine("\tCLC : ADC.b $02");
                StringBuilder stringBuilder15 = stringBuilder1;
                string str39 = str1;
                num = numArray[index + 2] & (int) ushort.MaxValue;
                string str40 = num.ToString("X4");
                string str41 = "\tSTA.l $" + str39 + str40;
                stringBuilder15.AppendLine(str41);
              }
            }
            else if (numArray[index + 3] != -1)
            {
              stringBuilder1.AppendLine("\tCLC : ADC.b $04");
              StringBuilder stringBuilder16 = stringBuilder1;
              string str42 = str1;
              num = numArray[index + 1] & (int) ushort.MaxValue;
              string str43 = num.ToString("X4");
              string str44 = "\tSTA.l $" + str42 + str43;
              stringBuilder16.AppendLine(str44);
              stringBuilder1.AppendLine("\tCLC : ADC.b $02");
              StringBuilder stringBuilder17 = stringBuilder1;
              string str45 = str1;
              num = numArray[index + 3] & (int) ushort.MaxValue;
              string str46 = num.ToString("X4");
              string str47 = "\tSTA.l $" + str45 + str46;
              stringBuilder17.AppendLine(str47);
            }
            else
            {
              stringBuilder1.AppendLine("\tCLC : ADC.b $04");
              StringBuilder stringBuilder18 = stringBuilder1;
              string str48 = str1;
              num = numArray[index + 1] & (int) ushort.MaxValue;
              string str49 = num.ToString("X4");
              string str50 = "\tSTA.l $" + str48 + str49;
              stringBuilder18.AppendLine(str50);
            }
          }
          else if (numArray[index + 2] != -1)
          {
            if (numArray[index + 3] != -1)
            {
              stringBuilder1.AppendLine("\tCLC : ADC.b $02");
              StringBuilder stringBuilder19 = stringBuilder1;
              string str51 = str1;
              num = numArray[index + 2] & (int) ushort.MaxValue;
              string str52 = num.ToString("X4");
              string str53 = "\tSTA.l $" + str51 + str52;
              stringBuilder19.AppendLine(str53);
              stringBuilder1.AppendLine("\tCLC : ADC.b $04");
              StringBuilder stringBuilder20 = stringBuilder1;
              string str54 = str1;
              num = numArray[index + 3] & (int) ushort.MaxValue;
              string str55 = num.ToString("X4");
              string str56 = "\tSTA.l $" + str54 + str55;
              stringBuilder20.AppendLine(str56);
            }
            else
            {
              stringBuilder1.AppendLine("\tCLC : ADC.b $02");
              StringBuilder stringBuilder21 = stringBuilder1;
              string str57 = str1;
              num = numArray[index + 2] & (int) ushort.MaxValue;
              string str58 = num.ToString("X4");
              string str59 = "\tSTA.l $" + str57 + str58;
              stringBuilder21.AppendLine(str59);
            }
          }
          else if (numArray[index + 3] != -1)
          {
            stringBuilder1.AppendLine("\tCLC : ADC.b $02");
            stringBuilder1.AppendLine("\tCLC : ADC.b $04");
            StringBuilder stringBuilder22 = stringBuilder1;
            string str60 = str1;
            num = numArray[index + 3] & (int) ushort.MaxValue;
            string str61 = num.ToString("X4");
            string str62 = "\tSTA.l $" + str60 + str61;
            stringBuilder22.AppendLine(str62);
          }
        }
      }
      if (numArray[512] != -1)
      {
        stringBuilder1.AppendLine("\tLDA.b $00");
        StringBuilder stringBuilder23 = stringBuilder1;
        string str63 = str1;
        num = numArray[512] & (int) ushort.MaxValue;
        string str64 = num.ToString("X4");
        string str65 = "\tSTA.l $" + str63 + str64;
        stringBuilder23.AppendLine(str65);
      }
      return stringBuilder1.ToString();
    }

    public static string multDiv(int multiplierIndex)
    {
      if (multiplierIndex < 2)
        return "\tLSR #" + (object) (3 - multiplierIndex) + "\r\n";
      switch (multiplierIndex)
      {
        case 2:
          return "\tLSR\r\n";
        case 3:
          return "";
        case 4:
          return "\tASL\r\n";
        default:
          return "\tASL #" + (object) (multiplierIndex - 3) + "\r\n";
      }
    }

    public static string stzCode(int address, string reg, bool memoryIs16Bit, bool addressIs16Bit)
    {
      if (CodeGeneration.ramAddressIsWord(address))
      {
        if (memoryIs16Bit && addressIs16Bit || !memoryIs16Bit && !addressIs16Bit)
          return "\tSTZ" + CodeGeneration.ramAddressReferenceCode(address) + "\r\n";
        if (memoryIs16Bit || !addressIs16Bit)
          throw new ArgumentException("Memory cannot be 16-bit while address is 8-bit");
        return "\tSTZ" + CodeGeneration.ramAddressReferenceCode(address) + "\r\n\tSTZ" + CodeGeneration.ramAddressReferenceCode(address & 16711680 | address + 1 & (int) ushort.MaxValue) + "\r\n";
      }
      if (memoryIs16Bit && addressIs16Bit || !memoryIs16Bit && !addressIs16Bit)
        return "\tLD" + reg + ".b #$00\r\n\tST" + reg + CodeGeneration.ramAddressReferenceCode(address) + "\r\n";
      if (memoryIs16Bit || !addressIs16Bit)
        throw new ArgumentException("Memory cannot be 16-bit while address is 8-bit");
      return "\tLD" + reg + ".b #$00\r\n\tST" + reg + CodeGeneration.ramAddressReferenceCode(address) + "\r\n\tST" + reg + CodeGeneration.ramAddressReferenceCode(address & 16711680 | address + 1 & (int) ushort.MaxValue) + "\r\n";
    }

    private static string incrementUpdaterCode16Bit(
      int address,
      int speedIndex,
      int direction,
      bool memoryIs16Bit)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str1 = CodeGeneration.ramAddressReferenceCode(address);
      string str2 = CodeGeneration.ramAddressReferenceCode(address & 16711680 | address + 1 & (int) ushort.MaxValue);
      if (speedIndex < 8)
      {
        stringBuilder.AppendLine("\tLDA.b $14");
        stringBuilder.AppendLine("\tAND." + (memoryIs16Bit ? "w" : "b") + " #%" + Convert.ToString((int) Math.Pow(2.0, (double) (8 - speedIndex)) - 1, 2));
        stringBuilder.AppendLine("\tBNE +");
        if (memoryIs16Bit)
        {
          stringBuilder.AppendLine("\tLDA" + str1);
          if (direction == 0)
            stringBuilder.AppendLine("\tCLC : ADC.w #$01");
          else
            stringBuilder.AppendLine("\tSEC : SBC.w #$01");
          stringBuilder.AppendLine("\tSTA" + str1);
        }
        else
        {
          stringBuilder.AppendLine("\tLDA" + str1);
          if (direction == 0)
            stringBuilder.AppendLine("\tCLC : ADC.b #$01");
          else
            stringBuilder.AppendLine("\tSEC : SBC.b #$01");
          stringBuilder.AppendLine("\tSTA" + str1);
          stringBuilder.AppendLine("\tLDA" + str2);
          if (direction == 0)
            stringBuilder.AppendLine("\tADC.b #$00");
          else
            stringBuilder.AppendLine("\tSBC.b #$00");
          stringBuilder.AppendLine("\tSTA" + str2);
        }
        stringBuilder.Append("+");
      }
      else if (memoryIs16Bit)
      {
        stringBuilder.AppendLine("\tLDA" + str1);
        if (direction == 0)
          stringBuilder.AppendLine("\tCLC : ADC.w #$" + (speedIndex - 7).ToString("X4"));
        else
          stringBuilder.AppendLine("\tSEC : SBC.w #$" + (speedIndex - 7).ToString("X4"));
        stringBuilder.AppendLine("\tSTA" + str1);
      }
      else
      {
        stringBuilder.AppendLine("\tLDA" + str1);
        if (direction == 0)
          stringBuilder.AppendLine("\tCLC : ADC.b #$" + (speedIndex - 7).ToString("X4"));
        else
          stringBuilder.AppendLine("\tSEC : SBC.b #$" + (speedIndex - 7).ToString("X4"));
        stringBuilder.AppendLine("\tSTA" + str1);
        stringBuilder.AppendLine("\tLDA" + str2);
        if (direction == 0)
          stringBuilder.AppendLine("\tADC.b #$00");
        else
          stringBuilder.AppendLine("\tSBC.b #$00");
        stringBuilder.AppendLine("\tSTA" + str2);
      }
      return stringBuilder.ToString();
    }

    private static string incrementUpdaterCode16Bit16BitForWaveIndex(
      int address,
      int speedIndex,
      int direction,
      int wavelength)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str = CodeGeneration.ramAddressReferenceCode(address);
      CodeGeneration.ramAddressReferenceCode(address & 16711680 | (address & (int) ushort.MaxValue) + 1);
      if (speedIndex < 8)
      {
        stringBuilder.AppendLine("\tLDA.b $14");
        stringBuilder.AppendLine("\tAND.w #%" + Convert.ToString((int) Math.Pow(2.0, (double) (8 - speedIndex)) - 1, 2));
        stringBuilder.AppendLine("\tBNE ++");
        stringBuilder.AppendLine("\tLDA" + str);
        if (direction == 0)
        {
          stringBuilder.AppendLine("\tCLC : ADC.w #$0002");
          stringBuilder.AppendLine("\tCMP.w #$" + (wavelength * 2).ToString("X4"));
          stringBuilder.AppendLine("\tBCC +");
          stringBuilder.AppendLine("\tLDA.w #$0000");
          stringBuilder.Append("+");
        }
        else
        {
          stringBuilder.AppendLine("\tSEC : SBC.w #$0002");
          stringBuilder.AppendLine("\tBPL +");
          stringBuilder.AppendLine("\tLDA.w #$" + (wavelength * 2).ToString("X4"));
          stringBuilder.Append("+");
        }
        stringBuilder.AppendLine("\tSTA" + str);
        stringBuilder.Append("++");
      }
      else
      {
        stringBuilder.AppendLine("\tLDA" + str);
        if (direction == 0)
        {
          stringBuilder.AppendLine("\tCLC : ADC.w #$" + ((speedIndex - 7) * 2).ToString("X4"));
          stringBuilder.AppendLine("\tCMP.w #$" + (wavelength * 2).ToString("X4"));
          stringBuilder.AppendLine("\tBCC +");
          stringBuilder.AppendLine("\tSEC : SBC.w #$" + (wavelength * 2).ToString("X4"));
          stringBuilder.Append("+");
        }
        else
        {
          stringBuilder.AppendLine("\tSEC : SBC.w #$" + ((speedIndex - 7) * 2).ToString("X4"));
          stringBuilder.AppendLine("\tBPL +");
          stringBuilder.AppendLine("\tCLC : ADC.w #$" + (wavelength * 2).ToString("X4"));
          stringBuilder.Append("+");
        }
        stringBuilder.AppendLine("\tSTA" + str);
      }
      return stringBuilder.ToString();
    }

    private static string ramAddressReferenceCode(int address)
    {
      if (!CodeGeneration.ramAddressIsWord(address))
        return ".l $" + address.ToString("X6");
      return address < 8257792 ? ".b $" + (address & (int) byte.MaxValue).ToString("X2") : ".w $" + (address & (int) ushort.MaxValue).ToString("X4");
    }

    private static bool ramAddressIsWord(int address) => (address & 16711680) == 8257536 && address < 8265728;

    private static bool ramAddressIsByte(int address) => (address & 16711680) == 8257536 && address < 8257792;

    private static ushort[] getWaveCoordinates(int wavelength, int amplitude, int type)
    {
      ushort[] numArray = new ushort[wavelength];
      switch (type)
      {
        case 0:
          for (int index = 0; index < wavelength; ++index)
            numArray[index] = (ushort) Math.Round(Math.Sin(2.0 * Math.PI * (double) index / (double) wavelength) * (double) amplitude);
          break;
        case 1:
          for (int index = 0; index < wavelength; ++index)
            numArray[index] = (ushort) Math.Round((double) (((double) index >= (double) wavelength / 2.0 ? -1 : 1) * amplitude) * Math.Sqrt(Math.Pow((double) wavelength / 4.0, 2.0) - Math.Pow((double) index % ((double) wavelength / 2.0) - (double) wavelength / 4.0, 2.0)) / ((double) wavelength / 4.0));
          break;
      }
      return numArray;
    }

    private static string ushortArrayToWordTable(ushort[] values)
    {
      StringBuilder stringBuilder = new StringBuilder("\tdw ");
      for (int index = 0; index < values.Length; ++index)
      {
        if (index != 0)
        {
          if (index % 8 == 0)
            stringBuilder.Append("\r\n\tdw ");
          else
            stringBuilder.Append(",");
        }
        stringBuilder.Append("$" + values[index].ToString("X4"));
      }
      stringBuilder.AppendLine();
      return stringBuilder.ToString();
    }

    private struct ScrollingEffectLayerTableEntryAssociation
    {
      private ScrollingEffectLayerTableEntry scrollingEffectLayerTableEntry;
      private ushort destination;
      private bool used;

      public ScrollingEffectLayerTableEntryAssociation(
        ScrollingEffectLayerTableEntry scrollingEffectLayerTableEntry,
        ushort destination)
      {
        this.scrollingEffectLayerTableEntry = scrollingEffectLayerTableEntry;
        this.destination = destination;
        this.used = false;
      }

      public ScrollingEffectLayerTableEntry ScrollingEffectLayerTableEntry
      {
        get => this.scrollingEffectLayerTableEntry;
        set => this.scrollingEffectLayerTableEntry = value;
      }

      public ushort Destination
      {
        get => this.destination;
        set => this.destination = value;
      }

      public bool Used
      {
        get => this.used;
        set => this.used = value;
      }

      public static int FindScrollingEffectLayerTableEntryIndex(
        List<CodeGeneration.ScrollingEffectLayerTableEntryAssociation> scrollingEffectLayerTableAssociations,
        ScrollingEffectLayerTableEntry scrollingEffectLayerTableEntry)
      {
        int num = 0;
        foreach (CodeGeneration.ScrollingEffectLayerTableEntryAssociation tableAssociation in scrollingEffectLayerTableAssociations)
        {
          if (tableAssociation.ScrollingEffectLayerTableEntry == scrollingEffectLayerTableEntry)
            return num;
          ++num;
        }
        return -1;
      }
    }

    private struct WaveTableAssociation
    {
      private int wavelength;
      private int amplitude;
      private int type;

      public WaveTableAssociation(int wavelength, int amplitude, int type)
      {
        this.wavelength = wavelength;
        this.amplitude = amplitude;
        this.type = type;
      }

      public int Wavelength
      {
        get => this.wavelength;
        set => this.wavelength = value;
      }

      public int Amplitude
      {
        get => this.amplitude;
        set => this.amplitude = value;
      }

      public int Type
      {
        get => this.type;
        set => this.type = value;
      }

      public static int FindWaveTableIndex(
        List<CodeGeneration.WaveTableAssociation> waveTableAssociations,
        int wavelength,
        int amplitude,
        int type)
      {
        int num = 0;
        foreach (CodeGeneration.WaveTableAssociation tableAssociation in waveTableAssociations)
        {
          if (tableAssociation.Wavelength == wavelength && tableAssociation.Amplitude == amplitude && tableAssociation.Type == type)
            return num;
          ++num;
        }
        return -1;
      }
    }

    private struct WindOffsetAddressAssociation
    {
      private int speed;
      private int direction;
      private int address;

      public WindOffsetAddressAssociation(int speed, int direction, int address)
      {
        this.speed = speed;
        this.direction = direction;
        this.address = address;
      }

      public int Speed
      {
        get => this.speed;
        set => this.speed = value;
      }

      public int Direction
      {
        get => this.direction;
        set => this.direction = value;
      }

      public int Address
      {
        get => this.address;
        set => this.address = value;
      }

      public static int FindWindOffsetAddressIndex(
        List<CodeGeneration.WindOffsetAddressAssociation> windOffsetAddressAssociations,
        int speed,
        int direction)
      {
        int num = 0;
        foreach (CodeGeneration.WindOffsetAddressAssociation addressAssociation in windOffsetAddressAssociations)
        {
          if (addressAssociation.Speed == speed && addressAssociation.Direction == direction)
            return num;
          ++num;
        }
        return -1;
      }
    }

    private struct WaveOffsetAddressAssociation
    {
      private int wavelength;
      private int offset;
      private int speed;
      private int direction;
      private int address;

      public WaveOffsetAddressAssociation(
        int wavelength,
        int speed,
        int direction,
        int offset,
        int address)
      {
        this.wavelength = wavelength;
        this.offset = offset;
        this.speed = speed;
        this.direction = direction;
        this.address = address;
      }

      public int Wavelength
      {
        get => this.wavelength;
        set => this.wavelength = value;
      }

      public int Offset
      {
        get => this.offset;
        set => this.offset = value;
      }

      public int Speed
      {
        get => this.speed;
        set => this.speed = value;
      }

      public int Direction
      {
        get => this.direction;
        set => this.direction = value;
      }

      public int Address
      {
        get => this.address;
        set => this.address = value;
      }

      public static int FindWaveOffsetAddressIndex(
        List<CodeGeneration.WaveOffsetAddressAssociation> waveOffsetAddressAssociations,
        int wavelength,
        int offset,
        int speed,
        int direction)
      {
        int num = 0;
        foreach (CodeGeneration.WaveOffsetAddressAssociation addressAssociation in waveOffsetAddressAssociations)
        {
          if (addressAssociation.Wavelength == wavelength && addressAssociation.Offset == offset && addressAssociation.Speed == speed && addressAssociation.Direction == direction)
            return num;
          ++num;
        }
        return -1;
      }
    }
  }
}
