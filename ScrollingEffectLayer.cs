// Decompiled with JetBrains decompiler
// Type: ScrollBars.ScrollingEffectLayer
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;

namespace ScrollBars
{
  public class ScrollingEffectLayer
  {
    public const int MAXCHANNEL = 7;
    public const ushort VERTICALWRAPENABLEDSCANLINECOUNT = 512;
    public const ushort VERTICALWRAPDISABLEDSCANLINECOUNT = 224;
    public const bool DEFAULTENABLED = false;
    public const bool DEFAULTVERTICALSCROLLENABLED = true;
    public const bool DEFAULTVERTICALWRAPENABLED = false;
    public const bool DEFAULTCOMPRESSIONENABLED = true;
    public const ushort TABLEARRAYLENGTH = 512;
    public static readonly byte[] DEFAULTCHANNELS = new byte[4]
    {
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6
    };
    public static readonly int[] DEFAULTVERTICALSCROLLADDRS = new int[4]
    {
      8257564,
      8257568,
      8257572,
      8257536
    };
    private int layerNum;
    private ScrollingEffectLayerTableEntry[] table;
    private bool enabled;
    private bool verticalScrollEnabled;
    private bool verticalWrapEnabled;
    private bool compressionEnabled;
    private int channel;
    private int verticalScrollAddress;

    public ScrollingEffectLayer(
      int layerNum,
      ScrollingEffectLayerTableEntry[] table,
      bool enabled,
      bool verticalScrollEnabled,
      bool verticalWrapEnabled,
      bool compressionEnabled,
      int channel,
      int verticalScrollAddress)
    {
      this.layerNum = layerNum;
      if (layerNum >= 4)
        throw new ArgumentException("int layerNum must be between 0 and " + (object) 3);
      this.table = table.Length == 512 ? table : throw new ArgumentException("ScrollingEffectLayerTableEntry[] table must have a length of " + (object) (ushort) 512);
      this.enabled = enabled;
      this.verticalScrollEnabled = verticalScrollEnabled;
      this.verticalWrapEnabled = verticalWrapEnabled;
      this.compressionEnabled = compressionEnabled;
      this.channel = channel;
      this.verticalScrollAddress = verticalScrollAddress;
    }

    public ScrollingEffectLayer(int layerNum)
    {
      this.layerNum = layerNum;
      ScrollingEffectLayerTableEntry[] effectLayerTableEntryArray = new ScrollingEffectLayerTableEntry[512];
      for (int scanlineNum = 0; scanlineNum < 512; ++scanlineNum)
        effectLayerTableEntryArray[scanlineNum] = new ScrollingEffectLayerTableEntry(layerNum, scanlineNum);
      this.table = effectLayerTableEntryArray;
      this.enabled = false;
      this.verticalScrollEnabled = true;
      this.verticalWrapEnabled = false;
      this.compressionEnabled = true;
      this.channel = (int) ScrollingEffectLayer.DEFAULTCHANNELS[layerNum];
      this.verticalScrollAddress = ScrollingEffectLayer.DEFAULTVERTICALSCROLLADDRS[layerNum];
    }

    public ushort GetRealTableLength() => this.verticalScrollEnabled ? (ushort) 512 : (ushort) 224;

    public int LayerNum => this.layerNum;

    public ScrollingEffectLayerTableEntry[] Table
    {
      get => this.table;
      set => this.table = value;
    }

    public bool Enabled
    {
      get => this.enabled;
      set => this.enabled = value;
    }

    public bool VerticalScrollEnabled
    {
      get => this.verticalScrollEnabled;
      set => this.verticalScrollEnabled = value;
    }

    public bool VerticalWrapEnabled
    {
      get => this.verticalWrapEnabled;
      set => this.verticalWrapEnabled = value;
    }

    public bool CompressionEnabled
    {
      get => this.compressionEnabled;
      set => this.compressionEnabled = value;
    }

    public int Channel
    {
      get => this.channel;
      set => this.channel = value;
    }

    public int VerticalScrollAddress
    {
      get => this.verticalScrollAddress;
      set => this.verticalScrollAddress = value;
    }
  }
}
