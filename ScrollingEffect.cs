// Decompiled with JetBrains decompiler
// Type: ScrollBars.ScrollingEffect
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.Collections.Generic;

namespace ScrollBars
{
  public class ScrollingEffect : HdmaEffect
  {
    public const int NUMLAYERS = 4;
    public const byte DEFAULTBANK = 127;
    private ScrollingEffectLayer[] layers;
    private byte bank;
    private List<FreeAddr> freeAddrs;

    public static List<FreeAddr> DEFAULTFREEADDRS => new List<FreeAddr>()
    {
      new FreeAddr((ushort) 45056, (ushort) 3071)
    };

    public ScrollingEffect(ScrollingEffectLayer[] layers, byte bank, List<FreeAddr> freeAddrs)
    {
      this.layers = layers.Length == 4 ? layers : throw new ArgumentException("'ScrollingEffectLayer[] layers' must have a length of " + (object) 4);
      this.bank = bank;
      this.freeAddrs = freeAddrs;
    }

    public ScrollingEffect()
    {
      this.layers = new ScrollingEffectLayer[4];
      for (int layerNum = 0; layerNum < 4; ++layerNum)
        this.layers[layerNum] = new ScrollingEffectLayer(layerNum);
      this.bank = (byte) 127;
      this.freeAddrs = ScrollingEffect.DEFAULTFREEADDRS;
    }

    public override byte Type => 0;

    public ScrollingEffectLayer[] Layers
    {
      get => this.layers;
      set => this.layers = value;
    }

    public byte Bank
    {
      get => this.bank;
      set => this.bank = value;
    }

    public List<FreeAddr> FreeAddrs
    {
      get => this.freeAddrs;
      set => this.freeAddrs = value;
    }
  }
}
