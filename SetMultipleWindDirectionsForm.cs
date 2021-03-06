// Decompiled with JetBrains decompiler
// Type: ScrollBars.SetMultipleWindDirectionsForm
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
  public class SetMultipleWindDirectionsForm : Form
  {
    private int fromScanline;
    private int toScanline;
    private ScrollingEffectLayerElementCollection scrollingEffectLayerElementCollection;
    private int maxScanline;
    private int windDir;
    private IContainer components = (IContainer) null;
    private GroupBox rangeFrame;
    private Label fromLabel;
    private TextBox fromTextBox;
    private Label toLabel;
    private TextBox toTextBox;
    private GroupBox valueFrame;
    private Button okButton;
    private Button cancelButton;
    private Label scanlineWindDirectionLabel;
    private ComboBox scanlineWindDirectionComboBox;

    public SetMultipleWindDirectionsForm(
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
      this.windDir = fromScanline != -1 ? scrollingEffectLayerElementCollection.LayerData.Table[this.fromScanline].WindDirection : 0;
      this.scanlineWindDirectionComboBox.SelectedIndex = this.windDir;
    }

    private void SetMultipleGroupsForm_FormClosing(object sender, FormClosingEventArgs e) => this.Owner.Enabled = true;

    private void okButton_Click(object sender, EventArgs e)
    {
      int num1 = Math.Min(this.fromScanline, this.toScanline);
      int num2 = Math.Max(this.fromScanline, this.toScanline);
      for (int index = num1; index <= num2; ++index)
        this.scrollingEffectLayerElementCollection.LayerData.Table[index].WindDirection = this.windDir;
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

    private void scanlineWindDirectionComboBox_SelectedIndexChanged(object sender, EventArgs e) => this.windDir = ((ListControl) sender).SelectedIndex;

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
      this.okButton = new Button();
      this.cancelButton = new Button();
      this.scanlineWindDirectionLabel = new Label();
      this.scanlineWindDirectionComboBox = new ComboBox();
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
      this.valueFrame.Controls.Add((Control) this.scanlineWindDirectionLabel);
      this.valueFrame.Controls.Add((Control) this.scanlineWindDirectionComboBox);
      this.valueFrame.Location = new Point(12, 69);
      this.valueFrame.Name = "valueFrame";
      this.valueFrame.Size = new Size(192, 51);
      this.valueFrame.TabIndex = 8;
      this.valueFrame.TabStop = false;
      this.valueFrame.Text = "Set Values To";
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
      this.scanlineWindDirectionLabel.AutoSize = true;
      this.scanlineWindDirectionLabel.Location = new Point(6, 22);
      this.scanlineWindDirectionLabel.Name = "scanlineWindDirectionLabel";
      this.scanlineWindDirectionLabel.Size = new Size(80, 13);
      this.scanlineWindDirectionLabel.TabIndex = 14;
      this.scanlineWindDirectionLabel.Text = "Wind Direction:";
      this.scanlineWindDirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scanlineWindDirectionComboBox.FormattingEnabled = true;
      this.scanlineWindDirectionComboBox.Items.AddRange(new object[2]
      {
        (object) "Left",
        (object) "Right"
      });
      this.scanlineWindDirectionComboBox.Location = new Point(92, 19);
      this.scanlineWindDirectionComboBox.Name = "scanlineWindDirectionComboBox";
      this.scanlineWindDirectionComboBox.Size = new Size(48, 21);
      this.scanlineWindDirectionComboBox.TabIndex = 15;
      this.scanlineWindDirectionComboBox.SelectedIndexChanged += new EventHandler(this.scanlineWindDirectionComboBox_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(216, 161);
      this.Controls.Add((Control) this.cancelButton);
      this.Controls.Add((Control) this.okButton);
      this.Controls.Add((Control) this.valueFrame);
      this.Controls.Add((Control) this.rangeFrame);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (SetMultipleWindDirectionsForm);
      this.Text = "Set Multiple Wind Directions";
      this.FormClosing += new FormClosingEventHandler(this.SetMultipleGroupsForm_FormClosing);
      this.rangeFrame.ResumeLayout(false);
      this.rangeFrame.PerformLayout();
      this.valueFrame.ResumeLayout(false);
      this.valueFrame.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
