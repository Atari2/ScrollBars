﻿// Decompiled with JetBrains decompiler
// Type: ScrollBars.SetMultipleMultipliersForm
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
  public class SetMultipleMultipliersForm : Form
  {
    private IContainer components = (IContainer) null;
    private Button cancelButton;
    private Button okButton;
    private GroupBox valueFrame;
    private GroupBox rangeFrame;
    private Label toLabel;
    private TextBox toTextBox;
    private Label fromLabel;
    private TextBox fromTextBox;
    private ComboBox scanlineMultiplierComboBox;
    private Label scanlineMultiplierLabel;
    private int fromScanline;
    private int toScanline;
    private ScrollingEffectLayerElementCollection scrollingEffectLayerElementCollection;
    private int maxScanline;
    private int multiplier;

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
      this.rangeFrame = new GroupBox();
      this.toLabel = new Label();
      this.toTextBox = new TextBox();
      this.fromLabel = new Label();
      this.fromTextBox = new TextBox();
      this.scanlineMultiplierComboBox = new ComboBox();
      this.scanlineMultiplierLabel = new Label();
      this.valueFrame.SuspendLayout();
      this.rangeFrame.SuspendLayout();
      this.SuspendLayout();
      this.cancelButton.Location = new Point(111, 126);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new Size(93, 23);
      this.cancelButton.TabIndex = 14;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
      this.okButton.Location = new Point(12, 126);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(93, 23);
      this.okButton.TabIndex = 13;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new EventHandler(this.okButton_Click);
      this.valueFrame.Controls.Add((Control) this.scanlineMultiplierComboBox);
      this.valueFrame.Controls.Add((Control) this.scanlineMultiplierLabel);
      this.valueFrame.Location = new Point(12, 69);
      this.valueFrame.Name = "valueFrame";
      this.valueFrame.Size = new Size(192, 51);
      this.valueFrame.TabIndex = 12;
      this.valueFrame.TabStop = false;
      this.valueFrame.Text = "Set Values To";
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
      this.scanlineMultiplierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
      this.scanlineMultiplierComboBox.Location = new Point(63, 19);
      this.scanlineMultiplierComboBox.Name = "scanlineMultiplierComboBox";
      this.scanlineMultiplierComboBox.Size = new Size(48, 21);
      this.scanlineMultiplierComboBox.TabIndex = 7;
      this.scanlineMultiplierComboBox.SelectedIndexChanged += new EventHandler(this.scanlineMultiplierComboBox_SelectedIndexChanged);
      this.scanlineMultiplierLabel.AutoSize = true;
      this.scanlineMultiplierLabel.Location = new Point(6, 22);
      this.scanlineMultiplierLabel.Name = "scanlineMultiplierLabel";
      this.scanlineMultiplierLabel.Size = new Size(51, 13);
      this.scanlineMultiplierLabel.TabIndex = 6;
      this.scanlineMultiplierLabel.Text = "Multiplier:";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(216, 161);
      this.Controls.Add((Control) this.cancelButton);
      this.Controls.Add((Control) this.okButton);
      this.Controls.Add((Control) this.valueFrame);
      this.Controls.Add((Control) this.rangeFrame);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (SetMultipleMultipliersForm);
      this.Text = "Set Multiple Multipliers";
      this.FormClosing += new FormClosingEventHandler(this.SetMultipleMultipliersForm_FormClosing);
      this.valueFrame.ResumeLayout(false);
      this.valueFrame.PerformLayout();
      this.rangeFrame.ResumeLayout(false);
      this.rangeFrame.PerformLayout();
      this.ResumeLayout(false);
    }

    public SetMultipleMultipliersForm(
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
      this.multiplier = fromScanline != -1 ? scrollingEffectLayerElementCollection.LayerData.Table[this.fromScanline].MultiplierIndex : 3;
      this.scanlineMultiplierComboBox.SelectedIndex = this.multiplier;
    }

    private void SetMultipleMultipliersForm_FormClosing(object sender, FormClosingEventArgs e) => this.Owner.Enabled = true;

    private void okButton_Click(object sender, EventArgs e)
    {
      int num1 = Math.Min(this.fromScanline, this.toScanline);
      int num2 = Math.Max(this.fromScanline, this.toScanline);
      for (int index = num1; index <= num2; ++index)
        this.scrollingEffectLayerElementCollection.LayerData.Table[index].MultiplierIndex = this.multiplier;
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

    private void scanlineMultiplierComboBox_SelectedIndexChanged(object sender, EventArgs e) => this.multiplier = ((ListControl) sender).SelectedIndex;
  }
}
