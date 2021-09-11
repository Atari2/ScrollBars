// Decompiled with JetBrains decompiler
// Type: ScrollBars.SetMultipleWindSpeedsForm
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
  public class SetMultipleWindSpeedsForm : Form
  {
    private IContainer components = (IContainer) null;
    private GroupBox rangeFrame;
    private Label fromLabel;
    private TextBox fromTextBox;
    private Label toLabel;
    private TextBox toTextBox;
    private GroupBox valueFrame;
    private Button okButton;
    private Button cancelButton;
    private Label scanlineWindSpeedLabel;
    private ComboBox scanlineWindSpeedComboBox;
    private int fromScanline;
    private int toScanline;
    private ScrollingEffectLayerElementCollection scrollingEffectLayerElementCollection;
    private int maxScanline;
    private int windSpeed;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.rangeFrame = new GroupBox();
      this.toLabel = new Label();
      this.toTextBox = new TextBox();
      this.fromLabel = new Label();
      this.fromTextBox = new TextBox();
      this.valueFrame = new GroupBox();
      this.scanlineWindSpeedLabel = new Label();
      this.scanlineWindSpeedComboBox = new ComboBox();
      this.okButton = new Button();
      this.cancelButton = new Button();
      this.rangeFrame.SuspendLayout();
      this.valueFrame.SuspendLayout();
      this.SuspendLayout();
      this.rangeFrame.Controls.Add((Control) this.toLabel);
      this.rangeFrame.Controls.Add((Control) this.toTextBox);
      this.rangeFrame.Controls.Add((Control) this.fromLabel);
      this.rangeFrame.Controls.Add((Control) this.fromTextBox);
      this.rangeFrame.Location = new Point(12, 12);
      this.rangeFrame.Name = "rangeFrame";
      this.rangeFrame.Size = new Size(192, 51);
      this.rangeFrame.TabIndex = 0;
      this.rangeFrame.TabStop = false;
      this.rangeFrame.Text = "Scanline Range";
      this.toLabel.AutoSize = true;
      this.toLabel.Location = new Point(109, 22);
      this.toLabel.Name = "toLabel";
      this.toLabel.Size = new Size(23, 13);
      this.toLabel.TabIndex = 6;
      this.toLabel.Text = "To:";
      this.toTextBox.Location = new Point(138, 19);
      this.toTextBox.Name = "toTextBox";
      this.toTextBox.Size = new Size(48, 20);
      this.toTextBox.TabIndex = 7;
      this.toTextBox.KeyPress += new KeyPressEventHandler(this.toTextBox_KeyPress);
      this.toTextBox.Leave += new EventHandler(this.toTextBox_Leave);
      this.fromLabel.AutoSize = true;
      this.fromLabel.Location = new Point(6, 22);
      this.fromLabel.Name = "fromLabel";
      this.fromLabel.Size = new Size(33, 13);
      this.fromLabel.TabIndex = 4;
      this.fromLabel.Text = "From:";
      this.fromTextBox.Location = new Point(45, 19);
      this.fromTextBox.Name = "fromTextBox";
      this.fromTextBox.Size = new Size(48, 20);
      this.fromTextBox.TabIndex = 5;
      this.fromTextBox.KeyPress += new KeyPressEventHandler(this.fromTextBox_KeyPress);
      this.fromTextBox.Leave += new EventHandler(this.fromTextBox_Leave);
      this.valueFrame.Controls.Add((Control) this.scanlineWindSpeedLabel);
      this.valueFrame.Controls.Add((Control) this.scanlineWindSpeedComboBox);
      this.valueFrame.Location = new Point(12, 69);
      this.valueFrame.Name = "valueFrame";
      this.valueFrame.Size = new Size(192, 51);
      this.valueFrame.TabIndex = 8;
      this.valueFrame.TabStop = false;
      this.valueFrame.Text = "Set Values To";
      this.scanlineWindSpeedLabel.AutoSize = true;
      this.scanlineWindSpeedLabel.Location = new Point(6, 22);
      this.scanlineWindSpeedLabel.Name = "scanlineWindSpeedLabel";
      this.scanlineWindSpeedLabel.Size = new Size(69, 13);
      this.scanlineWindSpeedLabel.TabIndex = 12;
      this.scanlineWindSpeedLabel.Text = "Wind Speed:";
      this.scanlineWindSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
      this.scanlineWindSpeedComboBox.Location = new Point(81, 19);
      this.scanlineWindSpeedComboBox.Name = "scanlineWindSpeedComboBox";
      this.scanlineWindSpeedComboBox.Size = new Size(48, 21);
      this.scanlineWindSpeedComboBox.TabIndex = 13;
      this.scanlineWindSpeedComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWindSpeedComboBox_SelectedIndexChanged);
      this.okButton.Location = new Point(12, 126);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(93, 23);
      this.okButton.TabIndex = 9;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new EventHandler(this.okButton_Click);
      this.cancelButton.Location = new Point(111, 126);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new Size(93, 23);
      this.cancelButton.TabIndex = 10;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(216, 161);
      this.Controls.Add((Control) this.cancelButton);
      this.Controls.Add((Control) this.okButton);
      this.Controls.Add((Control) this.valueFrame);
      this.Controls.Add((Control) this.rangeFrame);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (SetMultipleWindSpeedsForm);
      this.Text = "Set Multiple Wind Speeds";
      this.FormClosing += new FormClosingEventHandler(this.SetMultipleGroupsForm_FormClosing);
      this.rangeFrame.ResumeLayout(false);
      this.rangeFrame.PerformLayout();
      this.valueFrame.ResumeLayout(false);
      this.valueFrame.PerformLayout();
      this.ResumeLayout(false);
    }

    public SetMultipleWindSpeedsForm(
      int fromScanline,
      int toScanline,
      ScrollingEffectLayerElementCollection scrollingEffectLayerElementCollection)
    {
      this.InitializeComponent();
      this.maxScanline = (int) scrollingEffectLayerElementCollection.LayerData.GetRealTableLength() - 1;
      this.fromScanline = Numbers.Bound(fromScanline, 0, this.maxScanline);
      this.toScanline = Numbers.Bound(toScanline, 0, this.maxScanline);
      this.scrollingEffectLayerElementCollection = scrollingEffectLayerElementCollection;
      this.fromTextBox.Text = this.fromScanline.ToString("X");
      this.toTextBox.Text = this.toScanline.ToString("X");
      this.windSpeed = fromScanline != -1 ? scrollingEffectLayerElementCollection.LayerData.Table[this.fromScanline].WindSpeedIndex : 8;
      this.scanlineWindSpeedComboBox.SelectedIndex = this.windSpeed;
    }

    private void SetMultipleGroupsForm_FormClosing(object sender, FormClosingEventArgs e) => this.Owner.Enabled = true;

    private void okButton_Click(object sender, EventArgs e)
    {
      int num1 = Math.Min(this.fromScanline, this.toScanline);
      int num2 = Math.Max(this.fromScanline, this.toScanline);
      for (int index = num1; index <= num2; ++index)
        this.scrollingEffectLayerElementCollection.LayerData.Table[index].WindSpeedIndex = this.windSpeed;
      this.scrollingEffectLayerElementCollection.LoadTable();
      this.Close();
    }

    private void cancelButton_Click(object sender, EventArgs e) => this.Close();

    private void fromTextBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      this.fromScanline = Numbers.Bound(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 0, this.maxScanline);
      textBox.Text = this.fromScanline.ToString("X");
    }

    private void fromTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.fromTextBox_Leave(sender, (EventArgs) e);
    }

    private void toTextBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      this.toScanline = Numbers.Bound(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 0, this.maxScanline);
      textBox.Text = this.toScanline.ToString("X");
    }

    private void toTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.toTextBox_Leave(sender, (EventArgs) e);
    }

    private void scanlineWindSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e) => this.windSpeed = ((ListControl) sender).SelectedIndex;
  }
}
