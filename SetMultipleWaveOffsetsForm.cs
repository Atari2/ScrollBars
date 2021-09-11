// Decompiled with JetBrains decompiler
// Type: ScrollBars.SetMultipleWaveOffsetsForm
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
  public class SetMultipleWaveOffsetsForm : Form
  {
    private int fromScanline;
    private int toScanline;
    private ScrollingEffectLayerElementCollection scrollingEffectLayerElementCollection;
    private int maxScanline;
    private int waveOffset;
    private int incDecConst = 0;
    private int by;
    private bool wrapToLength = false;
    private IContainer components = (IContainer) null;
    private Button cancelButton;
    private Button okButton;
    private GroupBox valueFrame;
    private GroupBox rangeFrame;
    private Label toLabel;
    private TextBox toTextBox;
    private Label fromLabel;
    private TextBox fromTextBox;
    private Label scanlineWaveOffsetLabel;
    private TextBox scanlineWaveOffsetTextBox;
    private CheckBox wrapCheckBox;
    private RadioButton constantRadioButton;
    private RadioButton decRadioButton;
    private RadioButton incRadioButton;
    private Label label1;
    private TextBox byTextBox;

    public SetMultipleWaveOffsetsForm(
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
      this.waveOffset = fromScanline != -1 ? scrollingEffectLayerElementCollection.LayerData.Table[this.fromScanline].WavePosition : 0;
      this.scanlineWaveOffsetTextBox.Text = this.waveOffset.ToString("X");
      this.by = 1;
      this.byTextBox.Text = this.by.ToString("X");
    }

    private void SetMultipleSourcesForm_FormClosing(object sender, FormClosingEventArgs e) => this.Owner.Enabled = true;

    private void okButton_Click(object sender, EventArgs e)
    {
      int waveOffset = this.waveOffset;
      if (this.toScanline >= this.fromScanline)
      {
        for (int fromScanline = this.fromScanline; fromScanline <= this.toScanline; ++fromScanline)
        {
          this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].WavePosition = !this.wrapToLength ? waveOffset : (waveOffset % this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].Wavelength + this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].Wavelength) % this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].Wavelength;
          if (this.incDecConst == 0)
            waveOffset += this.by;
          else if (this.incDecConst == 1)
            waveOffset -= this.by;
        }
      }
      else
      {
        for (int fromScanline = this.fromScanline; fromScanline >= this.toScanline; --fromScanline)
        {
          this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].WavePosition = !this.wrapToLength ? waveOffset : (waveOffset % this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].Wavelength + this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].Wavelength) % this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].Wavelength;
          if (this.incDecConst == 0)
            waveOffset += this.by;
          else if (this.incDecConst == 1)
            waveOffset -= this.by;
        }
      }
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

    private void scanlineWaveOffsetTextBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      this.waveOffset = Math.Min(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 0);
      textBox.Text = this.waveOffset.ToString("X");
    }

    private void scanlineWaveOffsetTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.scanlineWaveOffsetTextBox_Leave(sender, (EventArgs) e);
    }

    private void incRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (!((RadioButton) sender).Checked)
        return;
      this.incDecConst = 0;
      this.byTextBox.Enabled = this.wrapCheckBox.Enabled = true;
    }

    private void decRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (!((RadioButton) sender).Checked)
        return;
      this.incDecConst = 1;
      this.byTextBox.Enabled = this.wrapCheckBox.Enabled = true;
    }

    private void constantRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (!((RadioButton) sender).Checked)
        return;
      this.incDecConst = 2;
      this.byTextBox.Enabled = this.wrapCheckBox.Enabled = false;
    }

    private void byTextBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      this.by = Numbers.Bound(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 0, this.maxScanline);
      textBox.Text = this.by.ToString("X");
    }

    private void byTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.byTextBox_Leave(sender, (EventArgs) e);
    }

    private void wrapCheckBox_CheckedChanged(object sender, EventArgs e) => this.wrapToLength = ((CheckBox) sender).Checked;

    private void toTextBox_Leave(object sender, LayoutEventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.cancelButton = new Button();
      this.okButton = new Button();
      this.valueFrame = new GroupBox();
      this.label1 = new Label();
      this.byTextBox = new TextBox();
      this.wrapCheckBox = new CheckBox();
      this.constantRadioButton = new RadioButton();
      this.decRadioButton = new RadioButton();
      this.incRadioButton = new RadioButton();
      this.scanlineWaveOffsetLabel = new Label();
      this.scanlineWaveOffsetTextBox = new TextBox();
      this.rangeFrame = new GroupBox();
      this.toLabel = new Label();
      this.toTextBox = new TextBox();
      this.fromLabel = new Label();
      this.fromTextBox = new TextBox();
      this.valueFrame.SuspendLayout();
      this.rangeFrame.SuspendLayout();
      this.SuspendLayout();
      this.cancelButton.Location = new Point(111, 192);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new Size(93, 23);
      this.cancelButton.TabIndex = 14;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
      this.okButton.Location = new Point(12, 192);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(93, 23);
      this.okButton.TabIndex = 13;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new EventHandler(this.okButton_Click);
      this.valueFrame.Controls.Add((Control) this.label1);
      this.valueFrame.Controls.Add((Control) this.byTextBox);
      this.valueFrame.Controls.Add((Control) this.wrapCheckBox);
      this.valueFrame.Controls.Add((Control) this.constantRadioButton);
      this.valueFrame.Controls.Add((Control) this.decRadioButton);
      this.valueFrame.Controls.Add((Control) this.incRadioButton);
      this.valueFrame.Controls.Add((Control) this.scanlineWaveOffsetLabel);
      this.valueFrame.Controls.Add((Control) this.scanlineWaveOffsetTextBox);
      this.valueFrame.Location = new Point(12, 69);
      this.valueFrame.Name = "valueFrame";
      this.valueFrame.Size = new Size(192, 117);
      this.valueFrame.TabIndex = 12;
      this.valueFrame.TabStop = false;
      this.valueFrame.Text = "Set Values To";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 71);
      this.label1.Name = "label1";
      this.label1.Size = new Size(22, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "By:";
      this.byTextBox.Location = new Point(34, 68);
      this.byTextBox.Name = "byTextBox";
      this.byTextBox.Size = new Size(48, 20);
      this.byTextBox.TabIndex = 20;
      this.byTextBox.KeyPress += new KeyPressEventHandler(this.byTextBox_KeyPress);
      this.byTextBox.Leave += new EventHandler(this.byTextBox_Leave);
      this.wrapCheckBox.AutoSize = true;
      this.wrapCheckBox.Location = new Point(6, 94);
      this.wrapCheckBox.Name = "wrapCheckBox";
      this.wrapCheckBox.Size = new Size(129, 17);
      this.wrapCheckBox.TabIndex = 18;
      this.wrapCheckBox.Text = "Wrap To Wavelength";
      this.wrapCheckBox.UseVisualStyleBackColor = true;
      this.wrapCheckBox.CheckedChanged += new EventHandler(this.wrapCheckBox_CheckedChanged);
      this.constantRadioButton.AutoSize = true;
      this.constantRadioButton.Location = new Point(103, 45);
      this.constantRadioButton.Name = "constantRadioButton";
      this.constantRadioButton.Size = new Size(67, 17);
      this.constantRadioButton.TabIndex = 17;
      this.constantRadioButton.TabStop = true;
      this.constantRadioButton.Text = "Constant";
      this.constantRadioButton.UseVisualStyleBackColor = true;
      this.constantRadioButton.CheckedChanged += new EventHandler(this.constantRadioButton_CheckedChanged);
      this.decRadioButton.AutoSize = true;
      this.decRadioButton.Location = new Point(52, 45);
      this.decRadioButton.Name = "decRadioButton";
      this.decRadioButton.Size = new Size(45, 17);
      this.decRadioButton.TabIndex = 17;
      this.decRadioButton.TabStop = true;
      this.decRadioButton.Text = "Dec";
      this.decRadioButton.UseVisualStyleBackColor = true;
      this.decRadioButton.CheckedChanged += new EventHandler(this.decRadioButton_CheckedChanged);
      this.incRadioButton.AutoSize = true;
      this.incRadioButton.Checked = true;
      this.incRadioButton.Location = new Point(6, 45);
      this.incRadioButton.Name = "incRadioButton";
      this.incRadioButton.Size = new Size(40, 17);
      this.incRadioButton.TabIndex = 17;
      this.incRadioButton.TabStop = true;
      this.incRadioButton.Text = "Inc";
      this.incRadioButton.UseVisualStyleBackColor = true;
      this.incRadioButton.CheckedChanged += new EventHandler(this.incRadioButton_CheckedChanged);
      this.scanlineWaveOffsetLabel.AutoSize = true;
      this.scanlineWaveOffsetLabel.Location = new Point(6, 22);
      this.scanlineWaveOffsetLabel.Name = "scanlineWaveOffsetLabel";
      this.scanlineWaveOffsetLabel.Size = new Size(70, 13);
      this.scanlineWaveOffsetLabel.TabIndex = 15;
      this.scanlineWaveOffsetLabel.Text = "Wave Offset:";
      this.scanlineWaveOffsetTextBox.Location = new Point(84, 19);
      this.scanlineWaveOffsetTextBox.Name = "scanlineWaveOffsetTextBox";
      this.scanlineWaveOffsetTextBox.Size = new Size(48, 20);
      this.scanlineWaveOffsetTextBox.TabIndex = 16;
      this.scanlineWaveOffsetTextBox.KeyPress += new KeyPressEventHandler(this.scanlineWaveOffsetTextBox_KeyPress);
      this.scanlineWaveOffsetTextBox.Leave += new EventHandler(this.scanlineWaveOffsetTextBox_Leave);
      this.rangeFrame.Controls.Add((Control) this.toLabel);
      this.rangeFrame.Controls.Add((Control) this.toTextBox);
      this.rangeFrame.Controls.Add((Control) this.fromLabel);
      this.rangeFrame.Controls.Add((Control) this.fromTextBox);
      this.rangeFrame.Location = new Point(12, 12);
      this.rangeFrame.Name = "rangeFrame";
      this.rangeFrame.Size = new Size(192, 51);
      this.rangeFrame.TabIndex = 11;
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
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(216, 227);
      this.Controls.Add((Control) this.cancelButton);
      this.Controls.Add((Control) this.okButton);
      this.Controls.Add((Control) this.valueFrame);
      this.Controls.Add((Control) this.rangeFrame);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (SetMultipleWaveOffsetsForm);
      this.Text = "Set Multiple Wave Offsets";
      this.FormClosing += new FormClosingEventHandler(this.SetMultipleSourcesForm_FormClosing);
      this.valueFrame.ResumeLayout(false);
      this.valueFrame.PerformLayout();
      this.rangeFrame.ResumeLayout(false);
      this.rangeFrame.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
