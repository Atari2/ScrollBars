// Decompiled with JetBrains decompiler
// Type: ScrollBars.ScrollingEffectLayerElementCollection
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ScrollBars
{
  public class ScrollingEffectLayerElementCollection : UserControl
  {
    private IContainer components = (IContainer) null;
    private ListView hdmaTableListView;
    private ColumnHeader blankColumnHeader;
    private ColumnHeader numberColumnHeader;
    private ColumnHeader groupColumnHeader;
    private ColumnHeader sourceColumnHeader;
    private ColumnHeader multiplierColumnHeader;
    private ColumnHeader scrollSpeedColumnHeader;
    private ColumnHeader windEnabledColummHeader;
    private ColumnHeader windSpeedColumnHeader;
    private ColumnHeader windDirectionColumnHeader;
    private ColumnHeader waveEnabledColumnHeader;
    private ColumnHeader waveLengthColumnHeader;
    private ColumnHeader waveAmplitudeColumnHeader;
    private ColumnHeader wavePositionColumnHeader;
    private ColumnHeader waveSpeedColummHeader;
    private ColumnHeader waveDirectionColumnHeader;
    private ColumnHeader waveTypeColumnHeader;
    private GroupBox currentScanlineGroupBox;
    private Label scanlineWaveTypeLabel;
    private ComboBox scanlineWaveTypeComboBox;
    private Label scanlineWaveOffsetLabel;
    private Label scanlineWaveAmplitudeLabel;
    private TextBox scanlineWaveOffsetTextBox;
    private TextBox scanlineWaveAmplitudeTextBox;
    private Label scanlineWavelengthLabel;
    private TextBox scanlineWavelengthTextBox;
    private CheckBox scanlineWaveCheckBox;
    private Label scanlineWaveLabel;
    private Label scanlineWaveDirectionLabel;
    private Label scanlineWindDirectionLabel;
    private ComboBox scanlineWaveDirectionComboBox;
    private ComboBox scanlineWindDirectionComboBox;
    private CheckBox scanlineWindCheckBox;
    private Label scanlineWaveSpeedLabel;
    private Label scanlineWindSpeedLabel;
    private Label scanlineWindLabel;
    private Label scanlineScrollSpeedLabel;
    private TextBox scanlineScrollSpeedTextBox;
    private Label scanlineGroupLabel;
    private ComboBox scanlineWaveSpeedComboBox;
    private ComboBox scanlineWindSpeedComboBox;
    private ComboBox scanlineMultiplierComboBox;
    private ComboBox scanlineGroupComboBox;
    private Label scanlineMultiplierLabel;
    private Label scanlineSourceLabel;
    private TextBox scanlineSourceTextBox;
    private GroupBox settingsGroupBox;
    private ComboBox hdmaChannelComboBox;
    private Label hdmaChannelLabel;
    private CheckBox enableCheckBox;
    private CheckBox enableVerticalScrollCheckBox;
    private CheckBox enableCompressionCheckBox;
    private CheckBox enableVerticalWrapCheckBox;
    private Label verticalScrollAddressLabel;
    private TextBox verticalScrollAddressTextBox;
    private bool tempDisableChange = false;
    private int currentScanline = -1;
    private bool beenModified = false;
    public ListView HdmaTableListView;
    public GroupBox SettingsGroupBox;
    public GroupBox CurrentScanlineGroupBox;
    public CheckBox EnableCheckBox;
    public CheckBox EnableVerticalScrollCheckBox;
    public CheckBox EnableVerticalWrapCheckBox;
    public CheckBox EnableCompressionCheckBox;
    public TextBox VerticalScrollAddressTextBox;
    public ComboBox HdmaChannelComboBox;
    public ComboBox ScanlineGroupComboBox;
    public TextBox ScanlineSourceTextBox;
    public ComboBox ScanlineMultiplierComboBox;
    public TextBox ScanlineScrollSpeedTextBox;
    public CheckBox ScanlineWindCheckBox;
    public ComboBox ScanlineWindSpeedComboBox;
    public ComboBox ScanlineWindDirectionComboBox;
    public CheckBox ScanlineWaveCheckBox;
    public TextBox ScanlineWavelengthTextBox;
    public TextBox ScanlineWaveAmplitudeTextBox;
    public TextBox ScanlineWaveOffsetTextBox;
    public ComboBox ScanlineWaveSpeedComboBox;
    public ComboBox ScanlineWaveDirectionComboBox;
    public ComboBox ScanlineWaveTypeComboBox;
    private ScrollingEffectLayer layerData;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.hdmaTableListView = new ListView();
      this.blankColumnHeader = new ColumnHeader();
      this.numberColumnHeader = new ColumnHeader();
      this.groupColumnHeader = new ColumnHeader();
      this.sourceColumnHeader = new ColumnHeader();
      this.multiplierColumnHeader = new ColumnHeader();
      this.scrollSpeedColumnHeader = new ColumnHeader();
      this.windEnabledColummHeader = new ColumnHeader();
      this.windSpeedColumnHeader = new ColumnHeader();
      this.windDirectionColumnHeader = new ColumnHeader();
      this.waveEnabledColumnHeader = new ColumnHeader();
      this.waveLengthColumnHeader = new ColumnHeader();
      this.waveAmplitudeColumnHeader = new ColumnHeader();
      this.wavePositionColumnHeader = new ColumnHeader();
      this.waveSpeedColummHeader = new ColumnHeader();
      this.waveDirectionColumnHeader = new ColumnHeader();
      this.waveTypeColumnHeader = new ColumnHeader();
      this.currentScanlineGroupBox = new GroupBox();
      this.scanlineWaveTypeLabel = new Label();
      this.scanlineWaveTypeComboBox = new ComboBox();
      this.scanlineWaveOffsetLabel = new Label();
      this.scanlineWaveAmplitudeLabel = new Label();
      this.scanlineWaveOffsetTextBox = new TextBox();
      this.scanlineWaveAmplitudeTextBox = new TextBox();
      this.scanlineWavelengthLabel = new Label();
      this.scanlineWavelengthTextBox = new TextBox();
      this.scanlineWaveCheckBox = new CheckBox();
      this.scanlineWaveLabel = new Label();
      this.scanlineWaveDirectionLabel = new Label();
      this.scanlineWindDirectionLabel = new Label();
      this.scanlineWaveDirectionComboBox = new ComboBox();
      this.scanlineWindDirectionComboBox = new ComboBox();
      this.scanlineWindCheckBox = new CheckBox();
      this.scanlineWaveSpeedLabel = new Label();
      this.scanlineWindSpeedLabel = new Label();
      this.scanlineWindLabel = new Label();
      this.scanlineScrollSpeedLabel = new Label();
      this.scanlineScrollSpeedTextBox = new TextBox();
      this.scanlineGroupLabel = new Label();
      this.scanlineWaveSpeedComboBox = new ComboBox();
      this.scanlineWindSpeedComboBox = new ComboBox();
      this.scanlineMultiplierComboBox = new ComboBox();
      this.scanlineGroupComboBox = new ComboBox();
      this.scanlineMultiplierLabel = new Label();
      this.scanlineSourceLabel = new Label();
      this.scanlineSourceTextBox = new TextBox();
      this.settingsGroupBox = new GroupBox();
      this.hdmaChannelComboBox = new ComboBox();
      this.hdmaChannelLabel = new Label();
      this.enableCheckBox = new CheckBox();
      this.enableVerticalScrollCheckBox = new CheckBox();
      this.enableCompressionCheckBox = new CheckBox();
      this.enableVerticalWrapCheckBox = new CheckBox();
      this.verticalScrollAddressLabel = new Label();
      this.verticalScrollAddressTextBox = new TextBox();
      this.currentScanlineGroupBox.SuspendLayout();
      this.settingsGroupBox.SuspendLayout();
      this.SuspendLayout();
      this.hdmaTableListView.Columns.AddRange(new ColumnHeader[16]
      {
        this.blankColumnHeader,
        this.numberColumnHeader,
        this.groupColumnHeader,
        this.sourceColumnHeader,
        this.multiplierColumnHeader,
        this.scrollSpeedColumnHeader,
        this.windEnabledColummHeader,
        this.windSpeedColumnHeader,
        this.windDirectionColumnHeader,
        this.waveEnabledColumnHeader,
        this.waveLengthColumnHeader,
        this.waveAmplitudeColumnHeader,
        this.wavePositionColumnHeader,
        this.waveSpeedColummHeader,
        this.waveDirectionColumnHeader,
        this.waveTypeColumnHeader
      });
      this.hdmaTableListView.Enabled = false;
      this.hdmaTableListView.FullRowSelect = true;
      this.hdmaTableListView.HideSelection = false;
      this.hdmaTableListView.Location = new Point(3, 3);
      this.hdmaTableListView.MultiSelect = false;
      this.hdmaTableListView.Name = "hdmaTableListView";
      this.hdmaTableListView.Size = new Size(916, 375);
      this.hdmaTableListView.TabIndex = 0;
      this.hdmaTableListView.UseCompatibleStateImageBehavior = false;
      this.hdmaTableListView.View = View.Details;
      this.hdmaTableListView.ColumnClick += new ColumnClickEventHandler(this.hdmaTableListView_ColumnClick);
      this.hdmaTableListView.ColumnWidthChanging += new ColumnWidthChangingEventHandler(this.hdmaTableListView_ColumnWidthChanging);
      this.hdmaTableListView.SelectedIndexChanged += new EventHandler(this.hdmaTableListView_SelectedIndexChanged);
      this.blankColumnHeader.Width = 0;
      this.numberColumnHeader.Text = "#";
      this.numberColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.numberColumnHeader.Width = 34;
      this.groupColumnHeader.Text = "Group";
      this.groupColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.groupColumnHeader.Width = 41;
      this.sourceColumnHeader.Text = "Source";
      this.sourceColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.sourceColumnHeader.Width = 66;
      this.multiplierColumnHeader.Text = "Multiplier";
      this.multiplierColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.multiplierColumnHeader.Width = 54;
      this.scrollSpeedColumnHeader.Text = "Scroll Speed";
      this.scrollSpeedColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.scrollSpeedColumnHeader.Width = 73;
      this.windEnabledColummHeader.Text = "Wind";
      this.windEnabledColummHeader.TextAlign = HorizontalAlignment.Center;
      this.windEnabledColummHeader.Width = 38;
      this.windSpeedColumnHeader.Text = "Wind Speed";
      this.windSpeedColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.windSpeedColumnHeader.Width = 72;
      this.windDirectionColumnHeader.Text = "Wind Dir.";
      this.windDirectionColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.windDirectionColumnHeader.Width = 57;
      this.waveEnabledColumnHeader.Text = "Wave";
      this.waveEnabledColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.waveEnabledColumnHeader.Width = 42;
      this.waveLengthColumnHeader.Text = "Wavelength";
      this.waveLengthColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.waveLengthColumnHeader.Width = 71;
      this.waveAmplitudeColumnHeader.Text = "Wave Ampl.";
      this.waveAmplitudeColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.waveAmplitudeColumnHeader.Width = 70;
      this.wavePositionColumnHeader.Text = "Wave Offset";
      this.wavePositionColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.wavePositionColumnHeader.Width = 72;
      this.waveSpeedColummHeader.Text = "Wave Speed";
      this.waveSpeedColummHeader.TextAlign = HorizontalAlignment.Center;
      this.waveSpeedColummHeader.Width = 76;
      this.waveDirectionColumnHeader.Text = "Wave Dir.";
      this.waveDirectionColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.waveTypeColumnHeader.Text = "Wave Type";
      this.waveTypeColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.waveTypeColumnHeader.Width = 69;
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveTypeLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveTypeComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveOffsetLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveAmplitudeLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveOffsetTextBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveAmplitudeTextBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWavelengthLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWavelengthTextBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveCheckBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveDirectionLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWindDirectionLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveDirectionComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWindDirectionComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWindCheckBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveSpeedLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWindSpeedLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWindLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineScrollSpeedLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineScrollSpeedTextBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineGroupLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWaveSpeedComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineWindSpeedComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineMultiplierComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineGroupComboBox);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineMultiplierLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineSourceLabel);
      this.currentScanlineGroupBox.Controls.Add((Control) this.scanlineSourceTextBox);
      this.currentScanlineGroupBox.Location = new Point(925, 174);
      this.currentScanlineGroupBox.Name = "currentScanlineGroupBox";
      this.currentScanlineGroupBox.Size = new Size(314, 204);
      this.currentScanlineGroupBox.TabIndex = 2;
      this.currentScanlineGroupBox.TabStop = false;
      this.currentScanlineGroupBox.Text = "Edit Scanline";
      this.scanlineWaveTypeLabel.AutoSize = true;
      this.scanlineWaveTypeLabel.Location = new Point(167, 179);
      this.scanlineWaveTypeLabel.Name = "scanlineWaveTypeLabel";
      this.scanlineWaveTypeLabel.Size = new Size(66, 13);
      this.scanlineWaveTypeLabel.TabIndex = 26;
      this.scanlineWaveTypeLabel.Text = "Wave Type:";
      this.scanlineWaveTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineWaveTypeComboBox.Enabled = false;
      this.scanlineWaveTypeComboBox.FormattingEnabled = true;
      this.scanlineWaveTypeComboBox.Items.AddRange(new object[2]
      {
        (object) "Sine",
        (object) "Round"
      });
      this.scanlineWaveTypeComboBox.Location = new Point(260, 176);
      this.scanlineWaveTypeComboBox.Name = "scanlineWaveTypeComboBox";
      this.scanlineWaveTypeComboBox.Size = new Size(48, 21);
      this.scanlineWaveTypeComboBox.TabIndex = 27;
      this.scanlineWaveTypeComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWaveTypeComboBox_SelectedIndexChanged);
      this.scanlineWaveOffsetLabel.AutoSize = true;
      this.scanlineWaveOffsetLabel.Location = new Point(167, 101);
      this.scanlineWaveOffsetLabel.Name = "scanlineWaveOffsetLabel";
      this.scanlineWaveOffsetLabel.Size = new Size(70, 13);
      this.scanlineWaveOffsetLabel.TabIndex = 20;
      this.scanlineWaveOffsetLabel.Text = "Wave Offset:";
      this.scanlineWaveAmplitudeLabel.AutoSize = true;
      this.scanlineWaveAmplitudeLabel.Location = new Point(167, 75);
      this.scanlineWaveAmplitudeLabel.Name = "scanlineWaveAmplitudeLabel";
      this.scanlineWaveAmplitudeLabel.Size = new Size(88, 13);
      this.scanlineWaveAmplitudeLabel.TabIndex = 18;
      this.scanlineWaveAmplitudeLabel.Text = "Wave Amplitude:";
      this.scanlineWaveOffsetTextBox.Enabled = false;
      this.scanlineWaveOffsetTextBox.Location = new Point(260, 98);
      this.scanlineWaveOffsetTextBox.Name = "scanlineWaveOffsetTextBox";
      this.scanlineWaveOffsetTextBox.Size = new Size(48, 20);
      this.scanlineWaveOffsetTextBox.TabIndex = 21;
      this.scanlineWaveOffsetTextBox.KeyPress += new KeyPressEventHandler(this.scanlineWaveOffsetTextBox_KeyPress);
      this.scanlineWaveOffsetTextBox.Leave += new EventHandler(this.scanlineWaveOffsetTextBox_Leave);
      this.scanlineWaveAmplitudeTextBox.Enabled = false;
      this.scanlineWaveAmplitudeTextBox.Location = new Point(260, 72);
      this.scanlineWaveAmplitudeTextBox.Name = "scanlineWaveAmplitudeTextBox";
      this.scanlineWaveAmplitudeTextBox.Size = new Size(48, 20);
      this.scanlineWaveAmplitudeTextBox.TabIndex = 19;
      this.scanlineWaveAmplitudeTextBox.KeyPress += new KeyPressEventHandler(this.scanlineWaveAmplitudeTextBox_KeyPress);
      this.scanlineWaveAmplitudeTextBox.Leave += new EventHandler(this.scanlineWaveAmplitudeTextBox_Leave);
      this.scanlineWavelengthLabel.AutoSize = true;
      this.scanlineWavelengthLabel.Location = new Point(167, 49);
      this.scanlineWavelengthLabel.Name = "scanlineWavelengthLabel";
      this.scanlineWavelengthLabel.Size = new Size(68, 13);
      this.scanlineWavelengthLabel.TabIndex = 16;
      this.scanlineWavelengthLabel.Text = "Wavelength:";
      this.scanlineWavelengthTextBox.Enabled = false;
      this.scanlineWavelengthTextBox.Location = new Point(260, 46);
      this.scanlineWavelengthTextBox.Name = "scanlineWavelengthTextBox";
      this.scanlineWavelengthTextBox.Size = new Size(48, 20);
      this.scanlineWavelengthTextBox.TabIndex = 17;
      this.scanlineWavelengthTextBox.KeyPress += new KeyPressEventHandler(this.scanlineWavelengthTextBox_KeyPress);
      this.scanlineWavelengthTextBox.Leave += new EventHandler(this.scanlineWavelengthTextBox_Leave);
      this.scanlineWaveCheckBox.AutoSize = true;
      this.scanlineWaveCheckBox.Enabled = false;
      this.scanlineWaveCheckBox.Location = new Point(260, 22);
      this.scanlineWaveCheckBox.Name = "scanlineWaveCheckBox";
      this.scanlineWaveCheckBox.Size = new Size(15, 14);
      this.scanlineWaveCheckBox.TabIndex = 15;
      this.scanlineWaveCheckBox.UseVisualStyleBackColor = true;
      this.scanlineWaveCheckBox.CheckedChanged += new EventHandler(this.scanlineWaveCheckBox_CheckedChanged);
      this.scanlineWaveLabel.AutoSize = true;
      this.scanlineWaveLabel.Location = new Point(167, 22);
      this.scanlineWaveLabel.Name = "scanlineWaveLabel";
      this.scanlineWaveLabel.Size = new Size(75, 13);
      this.scanlineWaveLabel.TabIndex = 14;
      this.scanlineWaveLabel.Text = "Enable Wave:";
      this.scanlineWaveDirectionLabel.AutoSize = true;
      this.scanlineWaveDirectionLabel.Location = new Point(167, 153);
      this.scanlineWaveDirectionLabel.Name = "scanlineWaveDirectionLabel";
      this.scanlineWaveDirectionLabel.Size = new Size(84, 13);
      this.scanlineWaveDirectionLabel.TabIndex = 24;
      this.scanlineWaveDirectionLabel.Text = "Wave Direction:";
      this.scanlineWindDirectionLabel.AutoSize = true;
      this.scanlineWindDirectionLabel.Location = new Point(6, 179);
      this.scanlineWindDirectionLabel.Name = "scanlineWindDirectionLabel";
      this.scanlineWindDirectionLabel.Size = new Size(80, 13);
      this.scanlineWindDirectionLabel.TabIndex = 12;
      this.scanlineWindDirectionLabel.Text = "Wind Direction:";
      this.scanlineWaveDirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineWaveDirectionComboBox.Enabled = false;
      this.scanlineWaveDirectionComboBox.FormattingEnabled = true;
      this.scanlineWaveDirectionComboBox.Items.AddRange(new object[2]
      {
        (object) "Up",
        (object) "Down"
      });
      this.scanlineWaveDirectionComboBox.Location = new Point(260, 150);
      this.scanlineWaveDirectionComboBox.Name = "scanlineWaveDirectionComboBox";
      this.scanlineWaveDirectionComboBox.Size = new Size(48, 21);
      this.scanlineWaveDirectionComboBox.TabIndex = 25;
      this.scanlineWaveDirectionComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWaveDirectionComboBox_SelectedIndexChanged);
      this.scanlineWindDirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineWindDirectionComboBox.Enabled = false;
      this.scanlineWindDirectionComboBox.FormattingEnabled = true;
      this.scanlineWindDirectionComboBox.Items.AddRange(new object[2]
      {
        (object) "Left",
        (object) "Right"
      });
      this.scanlineWindDirectionComboBox.Location = new Point(99, 177);
      this.scanlineWindDirectionComboBox.Name = "scanlineWindDirectionComboBox";
      this.scanlineWindDirectionComboBox.Size = new Size(48, 21);
      this.scanlineWindDirectionComboBox.TabIndex = 13;
      this.scanlineWindDirectionComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWindDirectionComboBox_SelectedIndexChanged);
      this.scanlineWindCheckBox.AutoSize = true;
      this.scanlineWindCheckBox.Enabled = false;
      this.scanlineWindCheckBox.Location = new Point(99, (int) sbyte.MaxValue);
      this.scanlineWindCheckBox.Name = "scanlineWindCheckBox";
      this.scanlineWindCheckBox.Size = new Size(15, 14);
      this.scanlineWindCheckBox.TabIndex = 9;
      this.scanlineWindCheckBox.UseVisualStyleBackColor = true;
      this.scanlineWindCheckBox.CheckedChanged += new EventHandler(this.scanlineWindCheckBox_CheckedChanged);
      this.scanlineWaveSpeedLabel.AutoSize = true;
      this.scanlineWaveSpeedLabel.Location = new Point(167, (int) sbyte.MaxValue);
      this.scanlineWaveSpeedLabel.Name = "scanlineWaveSpeedLabel";
      this.scanlineWaveSpeedLabel.Size = new Size(73, 13);
      this.scanlineWaveSpeedLabel.TabIndex = 22;
      this.scanlineWaveSpeedLabel.Text = "Wave Speed:";
      this.scanlineWindSpeedLabel.AutoSize = true;
      this.scanlineWindSpeedLabel.Location = new Point(6, 153);
      this.scanlineWindSpeedLabel.Name = "scanlineWindSpeedLabel";
      this.scanlineWindSpeedLabel.Size = new Size(69, 13);
      this.scanlineWindSpeedLabel.TabIndex = 10;
      this.scanlineWindSpeedLabel.Text = "Wind Speed:";
      this.scanlineWindLabel.AutoSize = true;
      this.scanlineWindLabel.Location = new Point(6, (int) sbyte.MaxValue);
      this.scanlineWindLabel.Name = "scanlineWindLabel";
      this.scanlineWindLabel.Size = new Size(71, 13);
      this.scanlineWindLabel.TabIndex = 8;
      this.scanlineWindLabel.Text = "Enable Wind:";
      this.scanlineScrollSpeedLabel.AutoSize = true;
      this.scanlineScrollSpeedLabel.Location = new Point(6, 101);
      this.scanlineScrollSpeedLabel.Name = "scanlineScrollSpeedLabel";
      this.scanlineScrollSpeedLabel.Size = new Size(70, 13);
      this.scanlineScrollSpeedLabel.TabIndex = 6;
      this.scanlineScrollSpeedLabel.Text = "Scroll Speed:";
      this.scanlineScrollSpeedTextBox.Enabled = false;
      this.scanlineScrollSpeedTextBox.Location = new Point(99, 98);
      this.scanlineScrollSpeedTextBox.Name = "scanlineScrollSpeedTextBox";
      this.scanlineScrollSpeedTextBox.Size = new Size(48, 20);
      this.scanlineScrollSpeedTextBox.TabIndex = 7;
      this.scanlineScrollSpeedTextBox.KeyPress += new KeyPressEventHandler(this.scanlineScrollSpeedTextBox_KeyPress);
      this.scanlineScrollSpeedTextBox.Leave += new EventHandler(this.scanlineScrollSpeedTextBox_Leave);
      this.scanlineGroupLabel.AutoSize = true;
      this.scanlineGroupLabel.Location = new Point(6, 22);
      this.scanlineGroupLabel.Name = "scanlineGroupLabel";
      this.scanlineGroupLabel.Size = new Size(67, 13);
      this.scanlineGroupLabel.TabIndex = 0;
      this.scanlineGroupLabel.Text = "Code Group:";
      this.scanlineWaveSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineWaveSpeedComboBox.Enabled = false;
      this.scanlineWaveSpeedComboBox.FormattingEnabled = true;
      this.scanlineWaveSpeedComboBox.Items.AddRange(new object[72]
      {
        (object) "1/256",
        (object) "1/128",
        (object) "1/64",
        (object) "1/32",
        (object) "1/16",
        (object) "1/8",
        (object) "1/4",
        (object) "1/2",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20",
        (object) "21",
        (object) "22",
        (object) "23",
        (object) "24",
        (object) "25",
        (object) "26",
        (object) "27",
        (object) "28",
        (object) "29",
        (object) "30",
        (object) "31",
        (object) "32",
        (object) "33",
        (object) "34",
        (object) "35",
        (object) "36",
        (object) "37",
        (object) "38",
        (object) "39",
        (object) "40",
        (object) "41",
        (object) "42",
        (object) "43",
        (object) "44",
        (object) "45",
        (object) "46",
        (object) "47",
        (object) "48",
        (object) "49",
        (object) "50",
        (object) "51",
        (object) "52",
        (object) "53",
        (object) "54",
        (object) "55",
        (object) "56",
        (object) "57",
        (object) "58",
        (object) "59",
        (object) "60",
        (object) "61",
        (object) "62",
        (object) "63",
        (object) "64"
      });
      this.scanlineWaveSpeedComboBox.Location = new Point(260, 124);
      this.scanlineWaveSpeedComboBox.Name = "scanlineWaveSpeedComboBox";
      this.scanlineWaveSpeedComboBox.Size = new Size(48, 21);
      this.scanlineWaveSpeedComboBox.TabIndex = 23;
      this.scanlineWaveSpeedComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWaveSpeedComboBox_SelectedIndexChanged);
      this.scanlineWindSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineWindSpeedComboBox.Enabled = false;
      this.scanlineWindSpeedComboBox.FormattingEnabled = true;
      this.scanlineWindSpeedComboBox.Items.AddRange(new object[72]
      {
        (object) "1/256",
        (object) "1/128",
        (object) "1/64",
        (object) "1/32",
        (object) "1/16",
        (object) "1/8",
        (object) "1/4",
        (object) "1/2",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20",
        (object) "21",
        (object) "22",
        (object) "23",
        (object) "24",
        (object) "25",
        (object) "26",
        (object) "27",
        (object) "28",
        (object) "29",
        (object) "30",
        (object) "31",
        (object) "32",
        (object) "33",
        (object) "34",
        (object) "35",
        (object) "36",
        (object) "37",
        (object) "38",
        (object) "39",
        (object) "40",
        (object) "41",
        (object) "42",
        (object) "43",
        (object) "44",
        (object) "45",
        (object) "46",
        (object) "47",
        (object) "48",
        (object) "49",
        (object) "50",
        (object) "51",
        (object) "52",
        (object) "53",
        (object) "54",
        (object) "55",
        (object) "56",
        (object) "57",
        (object) "58",
        (object) "59",
        (object) "60",
        (object) "61",
        (object) "62",
        (object) "63",
        (object) "64"
      });
      this.scanlineWindSpeedComboBox.Location = new Point(99, 150);
      this.scanlineWindSpeedComboBox.Name = "scanlineWindSpeedComboBox";
      this.scanlineWindSpeedComboBox.Size = new Size(48, 21);
      this.scanlineWindSpeedComboBox.TabIndex = 11;
      this.scanlineWindSpeedComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWindSpeedComboBox_SelectedIndexChanged);
      this.scanlineMultiplierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineMultiplierComboBox.Enabled = false;
      this.scanlineMultiplierComboBox.FormattingEnabled = true;
      this.scanlineMultiplierComboBox.Items.AddRange(new object[8]
      {
        (object) "1/8",
        (object) "1/4",
        (object) "1/2",
        (object) "1",
        (object) "2",
        (object) "4",
        (object) "8",
        (object) "16"
      });
      this.scanlineMultiplierComboBox.Location = new Point(99, 71);
      this.scanlineMultiplierComboBox.Name = "scanlineMultiplierComboBox";
      this.scanlineMultiplierComboBox.Size = new Size(48, 21);
      this.scanlineMultiplierComboBox.TabIndex = 5;
      this.scanlineMultiplierComboBox.SelectedIndexChanged += new EventHandler(this.scanlineMultiplierComboBox_SelectedIndexChanged);
      this.scanlineGroupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineGroupComboBox.Enabled = false;
      this.scanlineGroupComboBox.FormattingEnabled = true;
      this.scanlineGroupComboBox.Items.AddRange(new object[2]
      {
        (object) "1",
        (object) "2"
      });
      this.scanlineGroupComboBox.Location = new Point(99, 19);
      this.scanlineGroupComboBox.Name = "scanlineGroupComboBox";
      this.scanlineGroupComboBox.Size = new Size(48, 21);
      this.scanlineGroupComboBox.TabIndex = 1;
      this.scanlineGroupComboBox.SelectedIndexChanged += new EventHandler(this.scanlineGroupComboBox_SelectedIndexChanged);
      this.scanlineMultiplierLabel.AutoSize = true;
      this.scanlineMultiplierLabel.Location = new Point(6, 74);
      this.scanlineMultiplierLabel.Name = "scanlineMultiplierLabel";
      this.scanlineMultiplierLabel.Size = new Size(51, 13);
      this.scanlineMultiplierLabel.TabIndex = 4;
      this.scanlineMultiplierLabel.Text = "Multiplier:";
      this.scanlineSourceLabel.AutoSize = true;
      this.scanlineSourceLabel.Location = new Point(6, 49);
      this.scanlineSourceLabel.Name = "scanlineSourceLabel";
      this.scanlineSourceLabel.Size = new Size(84, 13);
      this.scanlineSourceLabel.TabIndex = 2;
      this.scanlineSourceLabel.Text = "H-Scroll Source:";
      this.scanlineSourceTextBox.Enabled = false;
      this.scanlineSourceTextBox.Location = new Point(99, 46);
      this.scanlineSourceTextBox.Name = "scanlineSourceTextBox";
      this.scanlineSourceTextBox.Size = new Size(48, 20);
      this.scanlineSourceTextBox.TabIndex = 3;
      this.scanlineSourceTextBox.KeyPress += new KeyPressEventHandler(this.scanlineSourceTextBox_KeyPress);
      this.scanlineSourceTextBox.Leave += new EventHandler(this.scanlineSourceTextBox_Leave);
      this.settingsGroupBox.Controls.Add((Control) this.hdmaChannelComboBox);
      this.settingsGroupBox.Controls.Add((Control) this.hdmaChannelLabel);
      this.settingsGroupBox.Controls.Add((Control) this.enableCheckBox);
      this.settingsGroupBox.Controls.Add((Control) this.enableVerticalScrollCheckBox);
      this.settingsGroupBox.Controls.Add((Control) this.enableCompressionCheckBox);
      this.settingsGroupBox.Controls.Add((Control) this.enableVerticalWrapCheckBox);
      this.settingsGroupBox.Controls.Add((Control) this.verticalScrollAddressLabel);
      this.settingsGroupBox.Controls.Add((Control) this.verticalScrollAddressTextBox);
      this.settingsGroupBox.Location = new Point(925, 3);
      this.settingsGroupBox.Name = "settingsGroupBox";
      this.settingsGroupBox.Size = new Size(314, 165);
      this.settingsGroupBox.TabIndex = 1;
      this.settingsGroupBox.TabStop = false;
      this.settingsGroupBox.Text = "Settings";
      this.hdmaChannelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.hdmaChannelComboBox.Enabled = false;
      this.hdmaChannelComboBox.FormattingEnabled = true;
      this.hdmaChannelComboBox.Items.AddRange(new object[8]
      {
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7"
      });
      this.hdmaChannelComboBox.Location = new Point(99, 138);
      this.hdmaChannelComboBox.Name = "hdmaChannelComboBox";
      this.hdmaChannelComboBox.Size = new Size(48, 21);
      this.hdmaChannelComboBox.TabIndex = 7;
      this.hdmaChannelComboBox.SelectedIndexChanged += new EventHandler(this.hdmaChannelComboBox_SelectedIndexChanged);
      this.hdmaChannelLabel.AutoSize = true;
      this.hdmaChannelLabel.Location = new Point(6, 141);
      this.hdmaChannelLabel.Name = "hdmaChannelLabel";
      this.hdmaChannelLabel.Size = new Size(84, 13);
      this.hdmaChannelLabel.TabIndex = 6;
      this.hdmaChannelLabel.Text = "HDMA Channel:";
      this.enableCheckBox.AutoSize = true;
      this.enableCheckBox.Enabled = false;
      this.enableCheckBox.Location = new Point(6, 19);
      this.enableCheckBox.Name = "enableCheckBox";
      this.enableCheckBox.Size = new Size(193, 17);
      this.enableCheckBox.TabIndex = 0;
      this.enableCheckBox.Text = "Enable Parallax HDMA for this layer";
      this.enableCheckBox.UseVisualStyleBackColor = true;
      this.enableCheckBox.CheckedChanged += new EventHandler(this.enableCheckBox_CheckedChanged);
      this.enableVerticalScrollCheckBox.AutoSize = true;
      this.enableVerticalScrollCheckBox.Checked = true;
      this.enableVerticalScrollCheckBox.CheckState = CheckState.Checked;
      this.enableVerticalScrollCheckBox.Enabled = false;
      this.enableVerticalScrollCheckBox.Location = new Point(6, 42);
      this.enableVerticalScrollCheckBox.Name = "enableVerticalScrollCheckBox";
      this.enableVerticalScrollCheckBox.Size = new Size(248, 17);
      this.enableVerticalScrollCheckBox.TabIndex = 1;
      this.enableVerticalScrollCheckBox.Text = "Enable Vertical Scrolling (takes up more space)";
      this.enableVerticalScrollCheckBox.UseVisualStyleBackColor = true;
      this.enableVerticalScrollCheckBox.CheckedChanged += new EventHandler(this.enableVerticalScrollCheckBox_CheckedChanged);
      this.enableCompressionCheckBox.AutoSize = true;
      this.enableCompressionCheckBox.Checked = true;
      this.enableCompressionCheckBox.CheckState = CheckState.Checked;
      this.enableCompressionCheckBox.Enabled = false;
      this.enableCompressionCheckBox.Location = new Point(6, 89);
      this.enableCompressionCheckBox.Name = "enableCompressionCheckBox";
      this.enableCompressionCheckBox.Size = new Size(225, 17);
      this.enableCompressionCheckBox.TabIndex = 3;
      this.enableCompressionCheckBox.Text = "Enable Compression (not implemented yet)";
      this.enableCompressionCheckBox.UseVisualStyleBackColor = true;
      this.enableCompressionCheckBox.CheckedChanged += new EventHandler(this.enableCompressionCheckBox_CheckedChanged);
      this.enableVerticalWrapCheckBox.AutoSize = true;
      this.enableVerticalWrapCheckBox.Enabled = false;
      this.enableVerticalWrapCheckBox.Location = new Point(6, 66);
      this.enableVerticalWrapCheckBox.Name = "enableVerticalWrapCheckBox";
      this.enableVerticalWrapCheckBox.Size = new Size(261, 17);
      this.enableVerticalWrapCheckBox.TabIndex = 2;
      this.enableVerticalWrapCheckBox.Text = "Enable Vertical Wrap (takes up even more space)";
      this.enableVerticalWrapCheckBox.UseVisualStyleBackColor = true;
      this.enableVerticalWrapCheckBox.CheckedChanged += new EventHandler(this.enableVerticalWrapCheckBox_CheckedChanged);
      this.verticalScrollAddressLabel.AutoSize = true;
      this.verticalScrollAddressLabel.Location = new Point(6, 115);
      this.verticalScrollAddressLabel.Name = "verticalScrollAddressLabel";
      this.verticalScrollAddressLabel.Size = new Size(83, 13);
      this.verticalScrollAddressLabel.TabIndex = 4;
      this.verticalScrollAddressLabel.Text = "V-Scroll Source:";
      this.verticalScrollAddressTextBox.Enabled = false;
      this.verticalScrollAddressTextBox.Location = new Point(99, 112);
      this.verticalScrollAddressTextBox.Name = "verticalScrollAddressTextBox";
      this.verticalScrollAddressTextBox.Size = new Size(48, 20);
      this.verticalScrollAddressTextBox.TabIndex = 5;
      this.verticalScrollAddressTextBox.Text = "7E001C";
      this.verticalScrollAddressTextBox.KeyPress += new KeyPressEventHandler(this.verticalScrollAddressTextBox_KeyPress);
      this.verticalScrollAddressTextBox.Leave += new EventHandler(this.verticalScrollAddressTextBox_Leave);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.hdmaTableListView);
      this.Controls.Add((Control) this.currentScanlineGroupBox);
      this.Controls.Add((Control) this.settingsGroupBox);
      this.Name = nameof (ScrollingEffectLayerElementCollection);
      this.Size = new Size(1242, 381);
      this.Resize += new EventHandler(this.ScrollingEffectLayerElementCollection_Resize);
      this.currentScanlineGroupBox.ResumeLayout(false);
      this.currentScanlineGroupBox.PerformLayout();
      this.settingsGroupBox.ResumeLayout(false);
      this.settingsGroupBox.PerformLayout();
      this.ResumeLayout(false);
    }

    public ScrollingEffectLayerElementCollection()
    {
      this.InitializeComponent();
      this.HdmaTableListView = this.hdmaTableListView;
      this.SettingsGroupBox = this.settingsGroupBox;
      this.CurrentScanlineGroupBox = this.currentScanlineGroupBox;
      this.EnableCheckBox = this.enableCheckBox;
      this.EnableVerticalScrollCheckBox = this.enableVerticalScrollCheckBox;
      this.EnableVerticalWrapCheckBox = this.enableVerticalWrapCheckBox;
      this.EnableCompressionCheckBox = this.enableCompressionCheckBox;
      this.VerticalScrollAddressTextBox = this.verticalScrollAddressTextBox;
      this.HdmaChannelComboBox = this.hdmaChannelComboBox;
      this.ScanlineGroupComboBox = this.scanlineGroupComboBox;
      this.ScanlineSourceTextBox = this.scanlineSourceTextBox;
      this.ScanlineMultiplierComboBox = this.scanlineMultiplierComboBox;
      this.ScanlineScrollSpeedTextBox = this.scanlineScrollSpeedTextBox;
      this.ScanlineWindCheckBox = this.scanlineWindCheckBox;
      this.ScanlineWindSpeedComboBox = this.scanlineWindSpeedComboBox;
      this.ScanlineWindDirectionComboBox = this.scanlineWindDirectionComboBox;
      this.ScanlineWaveCheckBox = this.scanlineWaveCheckBox;
      this.ScanlineWavelengthTextBox = this.scanlineWavelengthTextBox;
      this.ScanlineWaveAmplitudeTextBox = this.scanlineWaveAmplitudeTextBox;
      this.ScanlineWaveOffsetTextBox = this.scanlineWaveOffsetTextBox;
      this.ScanlineWaveSpeedComboBox = this.scanlineWaveSpeedComboBox;
      this.ScanlineWaveDirectionComboBox = this.scanlineWaveDirectionComboBox;
      this.ScanlineWaveTypeComboBox = this.scanlineWaveTypeComboBox;
    }

    public void LoadTable() => this.loadTable();

    internal ScrollingEffectLayer LayerData
    {
      get => this.layerData;
      set
      {
        this.layerData = value;
        this.loadLayer();
      }
    }

    internal bool BeenModified
    {
      get => this.beenModified;
      set => this.beenModified = value;
    }

    private void loadLayer()
    {
      this.currentScanline = -1;
      this.loadTable();
      bool tempDisableChange = this.tempDisableChange;
      this.tempDisableChange = true;
      this.EnableCheckBox.Checked = this.layerData.Enabled;
      this.EnableVerticalScrollCheckBox.Checked = this.layerData.VerticalScrollEnabled;
      this.EnableVerticalWrapCheckBox.Checked = this.layerData.VerticalWrapEnabled;
      this.EnableCompressionCheckBox.Checked = this.layerData.CompressionEnabled;
      this.VerticalScrollAddressTextBox.Text = this.layerData.VerticalScrollAddress.ToString("X6");
      this.HdmaChannelComboBox.SelectedIndex = this.layerData.Channel;
      this.tempDisableChange = tempDisableChange;
      this.updateElementEnableStates();
      this.beenModified = false;
    }

    private void loadTable()
    {
      int realTableLength = (int) this.layerData.GetRealTableLength();
      bool tempDisableChange = this.tempDisableChange;
      this.tempDisableChange = true;
      this.hdmaTableListView.Items.Clear();
      int num = Math.Min(this.layerData.Table.Length, realTableLength);
      for (int scanlineNum = 0; scanlineNum < num; ++scanlineNum)
        this.HdmaTableListView.Items.Add(this.generateScanlineListViewItem(this.layerData.Table[scanlineNum], scanlineNum));
      if (this.currentScanline >= realTableLength)
        this.currentScanline = -1;
      else if (this.currentScanline > -1)
        this.hdmaTableListView.SelectedIndices.Add(this.currentScanline);
      this.tempDisableChange = tempDisableChange;
    }

    private void loadScanline(ScrollingEffectLayerTableEntry scanline, int scanlineNum)
    {
      bool flag = this.hdmaTableListView.SelectedIndices.Contains(scanlineNum);
      this.hdmaTableListView.Items[scanlineNum] = this.generateScanlineListViewItem(scanline, scanlineNum);
      this.tempDisableChange = true;
      this.hdmaTableListView.Items[scanlineNum].Selected = flag;
      this.tempDisableChange = false;
    }

    private void reloadScanline(int scanlineNum) => this.loadScanline(this.layerData.Table[scanlineNum], scanlineNum);

    private ListViewItem generateScanlineListViewItem(
      ScrollingEffectLayerTableEntry scanline,
      int scanlineNum)
    {
      string[] items = new string[16]
      {
        "",
        scanlineNum.ToString("X"),
        (scanline.Group + 1).ToString(),
        "$" + scanline.HorizontalScrollAddress.ToString("X6"),
        ScrollingEffectLayerTableEntry.MULTIPLIERVALUES[scanline.MultiplierIndex],
        "0x" + scanline.ScrollSpeed.ToString("X3"),
        scanline.WindEnabled ? "On" : "Off",
        ScrollingEffectLayerTableEntry.WINDSPEEDVALUES[scanline.WindSpeedIndex],
        ScrollingEffectLayerTableEntry.WINDDIRVALUES[scanline.WindDirection],
        scanline.WaveEnabled ? "On" : "Off",
        null,
        null,
        null,
        null,
        null,
        null
      };
      string[] strArray1 = items;
      int num = scanline.Wavelength;
      string str1 = "0x" + num.ToString("X");
      strArray1[10] = str1;
      string[] strArray2 = items;
      num = scanline.WaveAmplitude;
      string str2 = "0x" + num.ToString("X");
      strArray2[11] = str2;
      string[] strArray3 = items;
      num = scanline.WavePosition;
      string str3 = "0x" + num.ToString("X");
      strArray3[12] = str3;
      items[13] = ScrollingEffectLayerTableEntry.WAVESPEEDVALUES[scanline.WaveSpeedIndex];
      items[14] = ScrollingEffectLayerTableEntry.WAVEDIRVALUES[scanline.WaveDirection];
      items[15] = ScrollingEffectLayerTableEntry.WAVETYPEVALUES[scanline.WaveTypeIndex];
      return new ListViewItem(items);
    }

    private void updateElementEnableStates()
    {
      this.EnableCheckBox.Enabled = true;
      if (this.EnableCheckBox.Checked)
      {
        this.setScanlineEditEnabled(this.currentScanline > -1);
        this.HdmaTableListView.Enabled = true;
        this.EnableVerticalScrollCheckBox.Enabled = true;
        this.EnableVerticalWrapCheckBox.Enabled = this.EnableVerticalScrollCheckBox.Checked;
        this.EnableCompressionCheckBox.Enabled = !this.EnableVerticalScrollCheckBox.Checked;
        this.VerticalScrollAddressTextBox.Enabled = this.EnableVerticalScrollCheckBox.Checked;
        this.HdmaChannelComboBox.Enabled = true;
      }
      else
      {
        this.setScanlineEditEnabled(false);
        this.HdmaTableListView.Enabled = false;
        this.EnableVerticalScrollCheckBox.Enabled = false;
        this.EnableVerticalWrapCheckBox.Enabled = false;
        this.EnableCompressionCheckBox.Enabled = false;
        this.VerticalScrollAddressTextBox.Enabled = false;
        this.HdmaChannelComboBox.Enabled = false;
      }
    }

    private void selectScanline(int scanlineNum)
    {
      this.currentScanline = scanlineNum;
      this.setScanlineEditEnabled(scanlineNum > -1);
      if (scanlineNum < 0)
        return;
      ScrollingEffectLayerTableEntry effectLayerTableEntry = this.layerData.Table[scanlineNum];
      this.tempDisableChange = true;
      this.ScanlineGroupComboBox.SelectedIndex = effectLayerTableEntry.Group;
      this.ScanlineSourceTextBox.Text = effectLayerTableEntry.HorizontalScrollAddress.ToString("X6");
      this.ScanlineMultiplierComboBox.SelectedIndex = effectLayerTableEntry.MultiplierIndex;
      this.ScanlineScrollSpeedTextBox.Text = effectLayerTableEntry.ScrollSpeed.ToString("X");
      this.ScanlineWindCheckBox.Checked = effectLayerTableEntry.WindEnabled;
      this.ScanlineWindSpeedComboBox.SelectedIndex = effectLayerTableEntry.WindSpeedIndex;
      this.ScanlineWindDirectionComboBox.SelectedIndex = effectLayerTableEntry.WindDirection;
      this.ScanlineWaveCheckBox.Checked = effectLayerTableEntry.WaveEnabled;
      TextBox wavelengthTextBox = this.ScanlineWavelengthTextBox;
      int num = effectLayerTableEntry.Wavelength;
      string str1 = num.ToString("X");
      wavelengthTextBox.Text = str1;
      TextBox amplitudeTextBox = this.ScanlineWaveAmplitudeTextBox;
      num = effectLayerTableEntry.WaveAmplitude;
      string str2 = num.ToString("X");
      amplitudeTextBox.Text = str2;
      TextBox waveOffsetTextBox = this.ScanlineWaveOffsetTextBox;
      num = effectLayerTableEntry.WavePosition;
      string str3 = num.ToString("X");
      waveOffsetTextBox.Text = str3;
      this.ScanlineWaveSpeedComboBox.SelectedIndex = effectLayerTableEntry.WaveSpeedIndex;
      this.ScanlineWaveDirectionComboBox.SelectedIndex = effectLayerTableEntry.WaveDirection;
      this.ScanlineWaveTypeComboBox.SelectedIndex = effectLayerTableEntry.WaveTypeIndex;
      this.tempDisableChange = false;
    }

    private void setScanlineEditEnabled(bool enabled)
    {
      this.ScanlineGroupComboBox.Enabled = enabled;
      this.ScanlineSourceTextBox.Enabled = enabled;
      this.ScanlineMultiplierComboBox.Enabled = enabled;
      this.ScanlineScrollSpeedTextBox.Enabled = enabled;
      this.ScanlineWindCheckBox.Enabled = enabled;
      this.ScanlineWindSpeedComboBox.Enabled = enabled;
      this.ScanlineWindDirectionComboBox.Enabled = enabled;
      this.ScanlineWaveCheckBox.Enabled = enabled;
      this.ScanlineWavelengthTextBox.Enabled = enabled;
      this.ScanlineWaveAmplitudeTextBox.Enabled = enabled;
      this.ScanlineWaveOffsetTextBox.Enabled = enabled;
      this.ScanlineWaveSpeedComboBox.Enabled = enabled;
      this.ScanlineWaveDirectionComboBox.Enabled = enabled;
      this.ScanlineWaveTypeComboBox.Enabled = enabled;
    }

    private void hdmaTableListView_ColumnWidthChanging(
      object sender,
      ColumnWidthChangingEventArgs e)
    {
      e.NewWidth = ((ListView) sender).Columns[e.ColumnIndex].Width;
      e.Cancel = true;
    }

    private void ScrollingEffectLayerElementCollection_Resize(object sender, EventArgs e)
    {
      this.hdmaTableListView.Width = this.Width - 326;
      this.settingsGroupBox.Location = new Point(this.Width - 317, this.settingsGroupBox.Location.Y);
      this.currentScanlineGroupBox.Location = new Point(this.Width - 317, this.currentScanlineGroupBox.Location.Y);
    }

    private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Enabled = ((CheckBox) sender).Checked;
      this.updateElementEnableStates();
      this.beenModified = true;
    }

    private void enableVerticalScrollCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.VerticalScrollEnabled = ((CheckBox) sender).Checked;
      this.loadTable();
      this.updateElementEnableStates();
      this.beenModified = true;
    }

    private void enableVerticalWrapCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.VerticalWrapEnabled = ((CheckBox) sender).Checked;
      this.beenModified = true;
    }

    private void enableCompressionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.CompressionEnabled = ((CheckBox) sender).Checked;
      this.beenModified = true;
    }

    private void verticalScrollAddressTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      textBox.Text = Numbers.FixAddressString(textBox.Text, "7E001C");
      this.layerData.VerticalScrollAddress = Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 8257562);
      this.beenModified = true;
    }

    private void verticalScrollAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.verticalScrollAddressTextBox_Leave(sender, (EventArgs) e);
    }

    private void hdmaChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Channel = ((ListControl) sender).SelectedIndex;
      this.beenModified = true;
    }

    private void hdmaTableListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      ListView.SelectedIndexCollection selectedIndices = ((ListView) sender).SelectedIndices;
      if (selectedIndices.Count <= 0)
        return;
      this.selectScanline(selectedIndices[0]);
    }

    private void scanlineGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].Group = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineSourceTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      textBox.Text = Numbers.FixAddressString(textBox.Text, ScrollingEffectLayerTableEntry.DEFAULTHORIZONTALSCROLLADDRS[this.layerData.LayerNum].ToString("X6"));
      this.layerData.Table[this.currentScanline].HorizontalScrollAddress = Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, ScrollingEffectLayerTableEntry.DEFAULTHORIZONTALSCROLLADDRS[this.layerData.LayerNum]);
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineSourceTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.scanlineSourceTextBox_Leave(sender, (EventArgs) e);
    }

    private void scanlineMultiplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].MultiplierIndex = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineScrollSpeedTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int num = Math.Min(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 512);
      textBox.Text = num.ToString("X");
      this.layerData.Table[this.currentScanline].ScrollSpeed = num;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineScrollSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.scanlineScrollSpeedTextBox_Leave(sender, (EventArgs) e);
    }

    private void scanlineWindCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WindEnabled = ((CheckBox) sender).Checked;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWindSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WindSpeedIndex = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWindDirectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WindDirection = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWaveCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WaveEnabled = ((CheckBox) sender).Checked;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWavelengthTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int num = Math.Min(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 512);
      textBox.Text = num.ToString("X");
      this.layerData.Table[this.currentScanline].Wavelength = num;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWavelengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.scanlineWavelengthTextBox_KeyPress(sender, e);
    }

    private void scanlineWaveAmplitudeTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int num = Math.Min(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), (int) ushort.MaxValue);
      textBox.Text = num.ToString("X");
      this.layerData.Table[this.currentScanline].WaveAmplitude = num;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWaveAmplitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.scanlineWaveAmplitudeTextBox_Leave(sender, (EventArgs) e);
    }

    private void scanlineWaveOffsetTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int safe = Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0);
      textBox.Text = safe.ToString("X");
      this.layerData.Table[this.currentScanline].WavePosition = safe;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWaveOffsetTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.scanlineWaveOffsetTextBox_Leave(sender, (EventArgs) e);
    }

    private void scanlineWaveSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WaveSpeedIndex = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWaveDirectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WaveDirection = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void scanlineWaveTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      this.layerData.Table[this.currentScanline].WaveTypeIndex = ((ListControl) sender).SelectedIndex;
      this.reloadScanline(this.currentScanline);
      this.beenModified = true;
    }

    private void hdmaTableListView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column == 2)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleGroupsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 3)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleSourcesForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 4)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleMultipliersForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 5)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleScrollSpeedsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 6)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWindEnabledForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 7)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWindSpeedsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 8)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWindDirectionsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 9)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWaveEnabledForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 10)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWavelengthsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 11)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWaveAmplitudesForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 12)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWaveOffsetsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 13)
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWaveSpeedsForm(this.currentScanline, this.currentScanline, this));
      else if (e.Column == 14)
      {
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWaveDirectionsForm(this.currentScanline, this.currentScanline, this));
      }
      else
      {
        if (e.Column != 15)
          return;
        FormSupport.OpenFormAsDialog(this.ParentForm, (Form) new SetMultipleWaveTypesForm(this.currentScanline, this.currentScanline, this));
      }
    }
  }
}
