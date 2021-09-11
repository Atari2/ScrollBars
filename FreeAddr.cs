// Decompiled with JetBrains decompiler
// Type: ScrollBars.FreeAddr
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.Collections.Generic;

namespace ScrollBars
{
  public struct FreeAddr
  {
    private ushort addr;
    private ushort lengthMinusOne;

    public FreeAddr(ushort addr, ushort lengthMinusOne)
    {
      this.addr = addr;
      this.lengthMinusOne = lengthMinusOne;
    }

    public ushort Addr
    {
      get => this.addr;
      set => this.addr = value;
    }

    public ushort LengthMinusOne
    {
      get => this.lengthMinusOne;
      set => this.lengthMinusOne = value;
    }

    public static FreeAddr GetFreeAddr(ref List<FreeAddr> freeAddrs, ushort minLength)
    {
      int index = 0;
      foreach (FreeAddr freeAddr in freeAddrs)
      {
        if ((int) freeAddr.LengthMinusOne + 1 >= (int) minLength)
        {
          if ((int) freeAddr.LengthMinusOne + 1 == (int) minLength)
            freeAddrs.RemoveAt(index);
          else
            freeAddrs[index] = new FreeAddr((ushort) ((uint) freeAddr.Addr + (uint) minLength), (ushort) ((uint) freeAddr.LengthMinusOne - (uint) minLength));
          return freeAddr;
        }
        ++index;
      }
      throw new FreeAddr.NotEnoughFreeAddrsException();
    }

    public static List<FreeAddr> GenerateOptimizedFreeAddrList(List<FreeAddr> freeAddrs)
    {
      bool[] flagArray = new bool[65536];
      foreach (FreeAddr freeAddr in freeAddrs)
      {
        int num = (int) freeAddr.Addr + (int) freeAddr.LengthMinusOne + 1;
        for (int addr = (int) freeAddr.Addr; addr < num; ++addr)
          flagArray[addr] = true;
      }
      List<FreeAddr> freeAddrList = new List<FreeAddr>();
      for (int index1 = 0; index1 < 65536; ++index1)
      {
        if (flagArray[index1])
        {
          int index2 = index1;
          while (index2 < 65536 && flagArray[index2])
            ++index2;
          freeAddrList.Add(new FreeAddr((ushort) index1, (ushort) (index2 - index1 - 1)));
          index1 = index2;
        }
      }
      return freeAddrList;
    }

    public class NotEnoughFreeAddrsException : Exception
    {
      public NotEnoughFreeAddrsException()
      {
      }

      public NotEnoughFreeAddrsException(string message)
        : base(message)
      {
      }
    }
  }
}
