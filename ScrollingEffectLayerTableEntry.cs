// Decompiled with JetBrains decompiler
// Type: ScrollBars.ScrollingEffectLayerTableEntry
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

namespace ScrollBars
{
  public struct ScrollingEffectLayerTableEntry
  {
    public const int NUMGROUPS = 2;
    public const int MAXSCROLLSPEED = 512;
    public const int NUMWINDDIRECTIONS = 2;
    public const int MAXWAVELENGTH = 512;
    public const int MAXWAVEAMPLITUDE = 65535;
    public const int NUMWAVEDIRECTIONS = 2;
    public const int WINDLEFT = 0;
    public const int WINDRIGHT = 1;
    public const int WAVEUP = 0;
    public const int WAVEDOWN = 1;
    public const int DEFAULTGROUP = 0;
    public const int DEFAULTMULTIPLIERINDEX = 3;
    public const int DEFAULTSCROLLSPEED = 512;
    public const bool DEFAULTWINDENABLED = false;
    public const int DEFAULTWINDSPEEDINDEX = 8;
    public const int DEFAULTWINDDIRECTION = 0;
    public const bool DEFAULTWAVEENABLED = false;
    public const int DEFAULTWAVELENGTH = 0;
    public const int DEFAULTWAVEAMPLITUDE = 0;
    public const int DEFAULTWAVEPOSITION = 0;
    public const int DEFAULTWAVESPEEDINDEX = 8;
    public const int DEFAULTWAVEDIRECTION = 0;
    public const int DEFAULTWAVETYPEINDEX = 0;
    public static readonly string[] MULTIPLIERVALUES = new string[8]
    {
      "1/8",
      "1/4",
      "1/2",
      "1",
      "2",
      "4",
      "8",
      "16"
    };
    public static readonly string[] WINDSPEEDVALUES = new string[72]
    {
      "1/256",
      "1/128",
      "1/64",
      "1/32",
      "1/16",
      "1/8",
      "1/4",
      "1/2",
      "1",
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9",
      "10",
      "11",
      "12",
      "13",
      "14",
      "15",
      "16",
      "17",
      "18",
      "19",
      "20",
      "21",
      "22",
      "23",
      "24",
      "25",
      "26",
      "27",
      "28",
      "29",
      "30",
      "31",
      "32",
      "33",
      "34",
      "35",
      "36",
      "37",
      "38",
      "39",
      "40",
      "41",
      "42",
      "43",
      "44",
      "45",
      "46",
      "47",
      "48",
      "49",
      "50",
      "51",
      "52",
      "53",
      "54",
      "55",
      "56",
      "57",
      "58",
      "59",
      "60",
      "61",
      "62",
      "63",
      "64"
    };
    public static readonly string[] WINDDIRVALUES = new string[2]
    {
      "Left",
      "Right"
    };
    public static readonly string[] WAVESPEEDVALUES = ScrollingEffectLayerTableEntry.WINDSPEEDVALUES;
    public static readonly string[] WAVEDIRVALUES = new string[2]
    {
      "Up",
      "Down"
    };
    public static readonly string[] WAVETYPEVALUES = new string[2]
    {
      "Sine",
      "Round"
    };
    public static readonly int[] DEFAULTHORIZONTALSCROLLADDRS = new int[4]
    {
      8257562,
      8257566,
      8257570,
      8257536
    };
    private int group;
    private int horizontalScrollAddress;
    private int multiplierIndex;
    private int scrollSpeed;
    private bool windEnabled;
    private int windSpeedIndex;
    private int windDirection;
    private bool waveEnabled;
    private int wavelength;
    private int waveAmplitude;
    private int wavePosition;
    private int waveSpeedIndex;
    private int waveDirection;
    private int waveTypeIndex;

    public ScrollingEffectLayerTableEntry(
      int group,
      int horizontalScrollAddress,
      int multiplierIndex,
      int scrollSpeed,
      bool windEnabled,
      int windSpeedIndex,
      int windDirection,
      bool waveEnabled,
      int wavelength,
      int waveAmplitude,
      int wavePosition,
      int waveSpeedIndex,
      int waveDirection,
      int waveTypeIndex)
      : this()
    {
      this.group = group;
      this.horizontalScrollAddress = horizontalScrollAddress;
      this.multiplierIndex = multiplierIndex;
      this.scrollSpeed = scrollSpeed;
      this.windEnabled = windEnabled;
      this.windSpeedIndex = windSpeedIndex;
      this.windDirection = windDirection;
      this.waveEnabled = waveEnabled;
      this.wavelength = wavelength;
      this.waveAmplitude = waveAmplitude;
      this.wavePosition = wavePosition;
      this.waveSpeedIndex = waveSpeedIndex;
      this.waveDirection = waveDirection;
      this.waveTypeIndex = waveTypeIndex;
    }

    public ScrollingEffectLayerTableEntry(int layerNum, int scanlineNum)
    {
      this.group = 0;
      this.horizontalScrollAddress = ScrollingEffectLayerTableEntry.DEFAULTHORIZONTALSCROLLADDRS[layerNum];
      this.multiplierIndex = 3;
      this.scrollSpeed = 512;
      this.windEnabled = false;
      this.windSpeedIndex = 8;
      this.windDirection = 0;
      this.waveEnabled = false;
      this.wavelength = 0;
      this.waveAmplitude = 0;
      this.wavePosition = 0;
      this.waveSpeedIndex = 8;
      this.waveDirection = 0;
      this.waveTypeIndex = 0;
    }

    public int Group
    {
      get => this.group;
      set => this.group = value;
    }

    public int HorizontalScrollAddress
    {
      get => this.horizontalScrollAddress;
      set => this.horizontalScrollAddress = value;
    }

    public int MultiplierIndex
    {
      get => this.multiplierIndex;
      set => this.multiplierIndex = value;
    }

    public int ScrollSpeed
    {
      get => this.scrollSpeed;
      set => this.scrollSpeed = value;
    }

    public bool WindEnabled
    {
      get => this.windEnabled;
      set => this.windEnabled = value;
    }

    public int WindSpeedIndex
    {
      get => this.windSpeedIndex;
      set => this.windSpeedIndex = value;
    }

    public int WindDirection
    {
      get => this.windDirection;
      set => this.windDirection = value;
    }

    public bool WaveEnabled
    {
      get => this.waveEnabled;
      set => this.waveEnabled = value;
    }

    public int Wavelength
    {
      get => this.wavelength;
      set => this.wavelength = value;
    }

    public int WaveAmplitude
    {
      get => this.waveAmplitude;
      set => this.waveAmplitude = value;
    }

    public int WavePosition
    {
      get => this.wavePosition;
      set => this.wavePosition = value;
    }

    public int WaveSpeedIndex
    {
      get => this.waveSpeedIndex;
      set => this.waveSpeedIndex = value;
    }

    public int WaveDirection
    {
      get => this.waveDirection;
      set => this.waveDirection = value;
    }

    public int WaveTypeIndex
    {
      get => this.waveTypeIndex;
      set => this.waveTypeIndex = value;
    }

    public bool InSameSetAs(ScrollingEffectLayerTableEntry b) => this.group == b.group && this.horizontalScrollAddress == b.horizontalScrollAddress && this.multiplierIndex == b.multiplierIndex && this.windEnabled == b.windEnabled && (this.windEnabled && this.windSpeedIndex == b.windSpeedIndex && this.windDirection == b.windDirection || !this.windEnabled) && this.waveEnabled == b.waveEnabled && (this.waveEnabled && this.wavelength == b.wavelength && this.waveAmplitude == b.waveAmplitude && this.wavePosition % this.wavelength == b.wavePosition % b.wavelength && this.waveSpeedIndex == b.waveSpeedIndex && this.waveDirection == b.waveDirection && this.waveTypeIndex == b.waveTypeIndex || !this.waveEnabled);

    public override bool Equals(object obj) => obj.GetType() == typeof (ScrollingEffectLayerTableEntry) && this == (ScrollingEffectLayerTableEntry) obj;

    public override int GetHashCode() => this.scrollSpeed == 0 ? this.scrollSpeed.GetHashCode() : this.group.GetHashCode() ^ this.horizontalScrollAddress.GetHashCode() ^ this.multiplierIndex.GetHashCode() ^ this.scrollSpeed.GetHashCode() ^ this.windEnabled.GetHashCode() ^ (this.windEnabled ? this.windSpeedIndex.GetHashCode() ^ this.windDirection.GetHashCode() : 0) ^ this.waveEnabled.GetHashCode() ^ (this.waveEnabled ? this.wavelength.GetHashCode() ^ this.waveAmplitude.GetHashCode() ^ (this.wavePosition % this.wavelength).GetHashCode() ^ this.waveSpeedIndex.GetHashCode() ^ this.waveDirection.GetHashCode() ^ this.waveTypeIndex.GetHashCode() : 0);

    public static bool operator ==(
      ScrollingEffectLayerTableEntry a,
      ScrollingEffectLayerTableEntry b)
    {
      return a.scrollSpeed == 0 && b.scrollSpeed == 0 || a.group == b.group && a.horizontalScrollAddress == b.horizontalScrollAddress && a.multiplierIndex == b.multiplierIndex && a.scrollSpeed == b.scrollSpeed && a.windEnabled == b.windEnabled && (a.windEnabled && a.windSpeedIndex == b.windSpeedIndex && a.windDirection == b.windDirection || !a.windEnabled) && a.waveEnabled == b.waveEnabled && (a.waveEnabled && a.wavelength == b.wavelength && a.waveAmplitude == b.waveAmplitude && a.wavePosition % a.wavelength == b.wavePosition % b.wavelength && a.waveSpeedIndex == b.waveSpeedIndex && a.waveDirection == b.waveDirection && a.waveTypeIndex == b.waveTypeIndex || !a.waveEnabled);
    }

    public static bool operator !=(
      ScrollingEffectLayerTableEntry a,
      ScrollingEffectLayerTableEntry b)
    {
      return !(a == b);
    }
  }
}
