// Decompiled with JetBrains decompiler
// Type: ScrollBars.SetMultipleScrollSpeedsForm
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
  public class SetMultipleScrollSpeedsForm : Form
  {
    private IContainer components = (IContainer) null;
    private Button cancelButton;
    private Button okButton;
    private GroupBox valueFrame;
    private Label label1;
    private TextBox toSpeedTextBox;
    private Label label2;
    private TextBox fromSpeedTextBox;
    private GroupBox rangeFrame;
    private Label toLabel;
    private TextBox toTextBox;
    private Label fromLabel;
    private TextBox fromTextBox;
    private RadioButton endAtRadioButton;
    private RadioButton approachRadioButton;
    private int fromScanline;
    private int toScanline;
    private ScrollingEffectLayerElementCollection scrollingEffectLayerElementCollection;
    private int maxScanline;
    private int fromSpeed;
    private int toSpeed;
    private bool endAt = false;

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
      this.endAtRadioButton = new RadioButton();
      this.approachRadioButton = new RadioButton();
      this.label1 = new Label();
      this.toSpeedTextBox = new TextBox();
      this.label2 = new Label();
      this.fromSpeedTextBox = new TextBox();
      this.rangeFrame = new GroupBox();
      this.toLabel = new Label();
      this.toTextBox = new TextBox();
      this.fromLabel = new Label();
      this.fromTextBox = new TextBox();
      this.valueFrame.SuspendLayout();
      this.rangeFrame.SuspendLayout();
      this.SuspendLayout();
      this.cancelButton.Location = new Point(111, 143);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new Size(93, 23);
      this.cancelButton.TabIndex = 18;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
      this.okButton.Location = new Point(12, 143);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(93, 23);
      this.okButton.TabIndex = 17;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new EventHandler(this.okButton_Click);
      this.valueFrame.Controls.Add((Control) this.endAtRadioButton);
      this.valueFrame.Controls.Add((Control) this.approachRadioButton);
      this.valueFrame.Controls.Add((Control) this.label1);
      this.valueFrame.Controls.Add((Control) this.toSpeedTextBox);
      this.valueFrame.Controls.Add((Control) this.label2);
      this.valueFrame.Controls.Add((Control) this.fromSpeedTextBox);
      this.valueFrame.Location = new Point(12, 69);
      this.valueFrame.Name = "valueFrame";
      this.valueFrame.Size = new Size(192, 68);
      this.valueFrame.TabIndex = 16;
      this.valueFrame.TabStop = false;
      this.valueFrame.Text = "Set Values To";
      this.endAtRadioButton.AutoSize = true;
      this.endAtRadioButton.Checked = true;
      this.endAtRadioButton.Location = new Point(9, 45);
      this.endAtRadioButton.Name = "endAtRadioButton";
      this.endAtRadioButton.Size = new Size(57, 17);
      this.endAtRadioButton.TabIndex = 12;
      this.endAtRadioButton.TabStop = true;
      this.endAtRadioButton.Text = "End At";
      this.endAtRadioButton.UseVisualStyleBackColor = true;
      this.endAtRadioButton.CheckedChanged += new EventHandler(this.endAtRadioButton_CheckedChanged);
      this.approachRadioButton.AutoSize = true;
      this.approachRadioButton.Location = new Point(72, 45);
      this.approachRadioButton.Name = "approachRadioButton";
      this.approachRadioButton.Size = new Size(101, 17);
      this.approachRadioButton.TabIndex = 12;
      this.approachRadioButton.Text = "Approach Value";
      this.approachRadioButton.UseVisualStyleBackColor = true;
      this.approachRadioButton.CheckedChanged += new EventHandler(this.approachRadioButton_CheckedChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(109, 22);
      this.label1.Name = "label1";
      this.label1.Size = new Size(23, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "To:";
      this.toSpeedTextBox.Location = new Point(138, 19);
      this.toSpeedTextBox.Name = "toSpeedTextBox";
      this.toSpeedTextBox.Size = new Size(48, 20);
      this.toSpeedTextBox.TabIndex = 11;
      this.toSpeedTextBox.KeyPress += new KeyPressEventHandler(this.toSpeedTextBox_KeyPress);
      this.toSpeedTextBox.Leave += new EventHandler(this.toSpeedTextBox_Leave);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 22);
      this.label2.Name = "label2";
      this.label2.Size = new Size(33, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "From:";
      this.fromSpeedTextBox.Location = new Point(45, 19);
      this.fromSpeedTextBox.Name = "fromSpeedTextBox";
      this.fromSpeedTextBox.Size = new Size(48, 20);
      this.fromSpeedTextBox.TabIndex = 9;
      this.fromSpeedTextBox.KeyPress += new KeyPressEventHandler(this.fromSpeedTextBox_KeyPress);
      this.fromSpeedTextBox.Leave += new EventHandler(this.fromSpeedTextBox_Leave);
      this.rangeFrame.Controls.Add((Control) this.toLabel);
      this.rangeFrame.Controls.Add((Control) this.toTextBox);
      this.rangeFrame.Controls.Add((Control) this.fromLabel);
      this.rangeFrame.Controls.Add((Control) this.fromTextBox);
      this.rangeFrame.Location = new Point(12, 12);
      this.rangeFrame.Name = "rangeFrame";
      this.rangeFrame.Size = new Size(192, 51);
      this.rangeFrame.TabIndex = 15;
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
      this.ClientSize = new Size(216, 178);
      this.Controls.Add((Control) this.cancelButton);
      this.Controls.Add((Control) this.okButton);
      this.Controls.Add((Control) this.valueFrame);
      this.Controls.Add((Control) this.rangeFrame);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (SetMultipleScrollSpeedsForm);
      this.Text = "Set Multiple Scroll Speeds";
      this.FormClosing += new FormClosingEventHandler(this.SetMultipleScrollSpeedsForm_FormClosing);
      this.valueFrame.ResumeLayout(false);
      this.valueFrame.PerformLayout();
      this.rangeFrame.ResumeLayout(false);
      this.rangeFrame.PerformLayout();
      this.ResumeLayout(false);
    }

    public SetMultipleScrollSpeedsForm(
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
      this.fromSpeed = fromScanline != -1 ? (this.toSpeed = scrollingEffectLayerElementCollection.LayerData.Table[this.fromScanline].ScrollSpeed) : (this.toSpeed = 512);
      this.fromSpeedTextBox.Text = this.fromSpeed.ToString("X");
      this.toSpeedTextBox.Text = this.toSpeed.ToString("X");
    }

    private void SetMultipleScrollSpeedsForm_FormClosing(object sender, FormClosingEventArgs e) => this.Owner.Enabled = true;

    private void okButton_Click(object sender, EventArgs e)
    {
      int num1 = this.toSpeed - this.fromSpeed;
      if (this.toScanline >= this.fromScanline)
      {
        int num2 = this.toScanline - this.fromScanline;
        if (!this.endAt)
          ++num2;
        int fromScanline = this.fromScanline;
        int num3 = 0;
        while (fromScanline <= this.toScanline)
        {
          this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].ScrollSpeed = (int) (ushort) Numbers.Bound((int) ((double) this.fromSpeed + 1.0 * (double) num3 / (double) num2 * (double) num1), 0, 512);
          ++fromScanline;
          ++num3;
        }
      }
      else
      {
        int num4 = this.fromScanline - this.toScanline;
        if (!this.endAt)
          ++num4;
        int fromScanline = this.fromScanline;
        int num5 = 0;
        while (fromScanline >= this.toScanline)
        {
          this.scrollingEffectLayerElementCollection.LayerData.Table[fromScanline].ScrollSpeed = (int) (ushort) Numbers.Bound((int) ((double) this.fromSpeed + 1.0 * (double) num5 / (double) num4 * (double) num1), 0, 512);
          --fromScanline;
          ++num5;
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

    private void fromSpeedTextBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      this.fromSpeed = Numbers.Bound(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 0, 512);
      textBox.Text = this.fromSpeed.ToString("X");
    }

    private void fromSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.fromSpeedTextBox_Leave(sender, (EventArgs) e);
    }

    private void toSpeedTextBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      this.toSpeed = Numbers.Bound(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0), 0, 512);
      textBox.Text = this.toSpeed.ToString("X");
    }

    private void toSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.toSpeedTextBox_Leave(sender, (EventArgs) e);
    }

    private void approachRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (!((RadioButton) sender).Checked)
        return;
      this.endAt = false;
    }

    private void endAtRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (!((RadioButton) sender).Checked)
        return;
      this.endAt = true;
    }
  }
}
