// Decompiled with JetBrains decompiler
// Type: ScrollBars.MainForm
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ScrollBars
{
  public class MainForm : Form
  {
    private IContainer components = (IContainer) null;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newHDMAEffectToolStripMenuItem;
    private ToolStripMenuItem openHDMAEffectToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private Button newButton;
    private Button openButton;
    private Button aboutButton;
    private Button exitButton;
    private List<Form> effectWindows = new List<Form>();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.menuStrip = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newHDMAEffectToolStripMenuItem = new ToolStripMenuItem();
      this.openHDMAEffectToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.newButton = new Button();
      this.openButton = new Button();
      this.aboutButton = new Button();
      this.exitButton = new Button();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip.Location = new Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new Size(180, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.newHDMAEffectToolStripMenuItem,
        (ToolStripItem) this.openHDMAEffectToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.newHDMAEffectToolStripMenuItem.Name = "newHDMAEffectToolStripMenuItem";
      this.newHDMAEffectToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
      this.newHDMAEffectToolStripMenuItem.Size = new Size(218, 22);
      this.newHDMAEffectToolStripMenuItem.Text = "&New HDMA Effect";
      this.newHDMAEffectToolStripMenuItem.Click += new EventHandler(this.newHDMAEffectToolStripMenuItem_Click);
      this.openHDMAEffectToolStripMenuItem.Name = "openHDMAEffectToolStripMenuItem";
      this.openHDMAEffectToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
      this.openHDMAEffectToolStripMenuItem.Size = new Size(218, 22);
      this.openHDMAEffectToolStripMenuItem.Text = "&Open HDMA Effect";
      this.openHDMAEffectToolStripMenuItem.Click += new EventHandler(this.openHDMAEffectToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(215, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Q";
      this.exitToolStripMenuItem.Size = new Size(218, 22);
      this.exitToolStripMenuItem.Tag = (object) "";
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.aboutToolStripMenuItem
      });
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(107, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
      this.newButton.Location = new Point(12, 27);
      this.newButton.Name = "newButton";
      this.newButton.Size = new Size(75, 23);
      this.newButton.TabIndex = 1;
      this.newButton.Text = "&New";
      this.newButton.UseVisualStyleBackColor = true;
      this.newButton.Click += new EventHandler(this.newButton_Click);
      this.openButton.Location = new Point(93, 27);
      this.openButton.Name = "openButton";
      this.openButton.Size = new Size(75, 23);
      this.openButton.TabIndex = 2;
      this.openButton.Text = "&Open";
      this.openButton.UseVisualStyleBackColor = true;
      this.openButton.Click += new EventHandler(this.openButton_Click);
      this.aboutButton.Location = new Point(12, 56);
      this.aboutButton.Name = "aboutButton";
      this.aboutButton.Size = new Size(75, 23);
      this.aboutButton.TabIndex = 3;
      this.aboutButton.Text = "&About";
      this.aboutButton.UseVisualStyleBackColor = true;
      this.aboutButton.Click += new EventHandler(this.aboutButton_Click);
      this.exitButton.Location = new Point(93, 56);
      this.exitButton.Name = "exitButton";
      this.exitButton.Size = new Size(75, 23);
      this.exitButton.TabIndex = 4;
      this.exitButton.Text = "E&xit";
      this.exitButton.UseVisualStyleBackColor = true;
      this.exitButton.Click += new EventHandler(this.exitButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(180, 91);
      this.Controls.Add((Control) this.exitButton);
      this.Controls.Add((Control) this.aboutButton);
      this.Controls.Add((Control) this.openButton);
      this.Controls.Add((Control) this.newButton);
      this.Controls.Add((Control) this.menuStrip);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MainMenuStrip = this.menuStrip;
      this.Name = nameof (MainForm);
      this.Text = "ScrollBars";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public MainForm() => this.InitializeComponent();

    private void newEffect()
    {
      ScrollingEffectEditor scrollingEffectEditor = new ScrollingEffectEditor();
      this.effectWindows.Add((Form) scrollingEffectEditor);
      scrollingEffectEditor.Show();
    }

    private void openEffect()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.AddExtension = true;
      openFileDialog.Filter = "ScrollBars HDMA File (*.hdma)|*.hdma";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        ImportExport.ReadFileContentsResult fileContentsResult = ImportExport.ReadEffectFileContents(File.ReadAllText(openFileDialog.FileName));
        if (fileContentsResult.Message != null)
        {
          int num1 = (int) MessageBox.Show(fileContentsResult.Message, fileContentsResult.ScrollingEffect == null ? "Error" : "Notice");
        }
        HdmaEffect scrollingEffect = (HdmaEffect) fileContentsResult.ScrollingEffect;
        if (scrollingEffect != null && scrollingEffect.Type == (byte) 0)
        {
          ScrollingEffectEditor scrollingEffectEditor = new ScrollingEffectEditor((ScrollingEffect) scrollingEffect, openFileDialog.FileName);
          this.effectWindows.Add((Form) scrollingEffectEditor);
          scrollingEffectEditor.Show();
        }
        else
        {
          int num2 = (int) MessageBox.Show("Unable to determine effect type!", "Error");
        }
      }
      catch (FileNotFoundException ex)
      {
        int num = (int) MessageBox.Show("File Not Found!", "Error");
      }
      catch (AccessViolationException ex)
      {
        int num = (int) MessageBox.Show("Unable to read file!", "Error");
      }
    }

    private void showAboutDialog()
    {
      string str1 = "04/09/11";
      string str2 = Assembly.GetExecutingAssembly().GetName().Version.ToString();
      string copyright = ((AssemblyCopyrightAttribute) Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false)[0]).Copyright;
      int num = (int) MessageBox.Show("**ScrollBars**\nSMW HDMA Code Generator\n\nVersion " + str2 + " - Build " + str1 + "\n" + copyright, "About");
    }

    private bool tryToCloseEverything()
    {
      for (int index = 0; index < this.effectWindows.Count; ++index)
      {
        if (this.effectWindows[index] != null && !this.effectWindows[index].IsDisposed)
          this.effectWindows[index].Close();
        if (!this.effectWindows[index].IsDisposed)
          return false;
        this.effectWindows.RemoveAt(index);
      }
      return true;
    }

    private void exitApplication()
    {
      if (!this.tryToCloseEverything())
        return;
      Environment.Exit(0);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !this.tryToCloseEverything();

    private void newHDMAEffectToolStripMenuItem_Click(object sender, EventArgs e) => this.newEffect();

    private void newButton_Click(object sender, EventArgs e) => this.newEffect();

    private void openHDMAEffectToolStripMenuItem_Click(object sender, EventArgs e) => this.openEffect();

    private void openButton_Click(object sender, EventArgs e) => this.openEffect();

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => this.showAboutDialog();

    private void aboutButton_Click(object sender, EventArgs e) => this.showAboutDialog();

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.exitApplication();

    private void exitButton_Click(object sender, EventArgs e) => this.exitApplication();
  }
}
