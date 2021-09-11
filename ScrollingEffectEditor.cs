// Decompiled with JetBrains decompiler
// Type: ScrollBars.ScrollingEffectEditor
// Assembly: ScrollBars, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B567376-4CE2-4B68-AFBA-FF4CDFAC1C03
// Assembly location: D:\Download\ScrollBars.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ScrollBars
{
  public class ScrollingEffectEditor : Form
  {
    private const string WINDOWTITLE = "ScrollBars - Scrolling Effect Editor";
    private bool tempDisableChange = false;
    private int currentFreeAddr = -1;
    private ScrollingEffectLayerElementCollection[] layerElementCollections;
    private ScrollingEffect scrollingEffect;
    private string filePath;
    private IContainer components = (IContainer) null;
    private ColumnHeader scanlineColumnHeader;
    private ColumnHeader scrollTableColumnHeader;
    private ColumnHeader speedColumnHeader;
    private TextBox vOffsetBG1TextBox;
    private Label vOffsetAddressBG1Label;
    private CheckBox verticalWrapBG1CheckBox;
    private CheckBox compressionBG1CheckBox;
    private CheckBox verticalOffsetBG1CheckBox;
    private CheckBox enableBG1CheckBox;
    private Label scrollTableBG1Label;
    private ComboBox scrollTableBG1ComboBox;
    private Label currentScanlineSpeedBG1Label;
    private TextBox scrollSpeedBG1TextBox;
    private Label inHexBG1Label;
    private TabControl effectDataParallaxTabControl;
    private TabPage bg1TabPage;
    private TabPage bg2TabPage;
    private TabPage bg3TabPage;
    private TabPage bg4TabPage;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem exportCodeToolStripMenuItem;
    private ToolStripSeparator fileToolStripSeparator;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ScrollingEffectLayerElementCollection bg1LayerElementCollection;
    private ScrollingEffectLayerElementCollection bg2LayerElementCollection;
    private ScrollingEffectLayerElementCollection bg3LayerElementCollection;
    private ScrollingEffectLayerElementCollection bg4LayerElementCollection;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private TabPage settingsTabPage;
    private GroupBox currentFreeAddrFrame;
    private Label lengthLabel;
    private TextBox lengthTextBox;
    private Label addressLabel;
    private TextBox addressTextBox;
    private Button newButton;
    private Button removeButton;
    private Button optimizeButton;
    private Button checkIfEnoughButton;
    private GroupBox mainSettingsFrame;
    private Label bankLabel;
    private TextBox bankTextBox;
    private Panel settingsPanel;
    private ListView freeAddrListView;
    private ColumnHeader blankColumnHeader;
    private ColumnHeader addressColumnHeader;
    private ColumnHeader lengthColumnHeader;

    public ScrollingEffectEditor()
    {
      this.initialize();
      this.makeNewEffect();
    }

    public ScrollingEffectEditor(ScrollingEffect effect, string filePath)
    {
      this.initialize();
      this.filePath = filePath;
      this.loadEffect(effect);
      this.updateTitle();
    }

    private void initialize()
    {
      this.InitializeComponent();
      this.layerElementCollections = new ScrollingEffectLayerElementCollection[4]
      {
        this.bg1LayerElementCollection,
        this.bg2LayerElementCollection,
        this.bg3LayerElementCollection,
        this.bg4LayerElementCollection
      };
    }

    private void updateTitle() => this.Text = "ScrollBars - Scrolling Effect Editor" + (this.filePath != null ? " - " + Path.GetFileName(this.filePath) : "");

    private bool beenModified
    {
      get
      {
        bool flag = false;
        for (int index = 0; index < 4; ++index)
          flag |= this.layerElementCollections[index].BeenModified;
        return flag;
      }
      set
      {
        for (int index = 0; index < 4; ++index)
          this.layerElementCollections[index].BeenModified = false;
      }
    }

    private void loadEffect(ScrollingEffect effect)
    {
      this.scrollingEffect = effect;
      for (int index = 0; index < 4; ++index)
        this.layerElementCollections[index].LayerData = effect.Layers[index];
      this.loadFreeAddrs();
      this.tempDisableChange = true;
      this.bankTextBox.Text = effect.Bank.ToString("X2");
      this.tempDisableChange = false;
      this.updateElementEnableStates();
    }

    private void makeNewEffect()
    {
      this.loadEffect(new ScrollingEffect());
      this.filePath = (string) null;
      this.updateTitle();
    }

    private bool openEffect()
    {
      if (!this.checkDontSave())
        return false;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.AddExtension = true;
      openFileDialog.Filter = "ScrollBars HDMA File (*.hdma)|*.hdma";
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
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
            this.loadEffect((ScrollingEffect) scrollingEffect);
            this.filePath = openFileDialog.FileName;
            this.updateTitle();
            return true;
          }
          int num2 = (int) MessageBox.Show("Unable to determine effect type!", "Error");
        }
        catch (FileNotFoundException ex)
        {
          int num = (int) MessageBox.Show("File Not Found!", "Error");
          return false;
        }
        catch (AccessViolationException ex)
        {
          int num = (int) MessageBox.Show("Unable to read file!", "Error");
          return false;
        }
      }
      return false;
    }

    private bool saveEffectAs()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.AddExtension = true;
      saveFileDialog.Filter = "ScrollBars HDMA File (*.hdma)|*.hdma";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return false;
      this.filePath = saveFileDialog.FileName;
      if (!this.saveEffect())
        return false;
      this.updateTitle();
      return true;
    }

    private bool saveEffect()
    {
      if (this.filePath == null)
        return this.saveEffectAs();
      try
      {
        File.WriteAllText(this.filePath, ImportExport.GenerateScrollingEffectFileContents(this.scrollingEffect));
        this.beenModified = false;
        return true;
      }
      catch (AccessViolationException ex)
      {
        int num = (int) MessageBox.Show("Unable to write to file!", "Error");
        return false;
      }
    }

    private bool exportEffect()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.AddExtension = true;
      saveFileDialog.Filter = "LevelASMTool Code File (*.asm)|*.asm";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return false;
      this.filePath = saveFileDialog.FileName;
      try
      {
        File.WriteAllText(this.filePath, CodeGeneration.GenerateScrollingEffectCode(this.scrollingEffect));
        return true;
      }
      catch (AccessViolationException ex)
      {
        int num = (int) MessageBox.Show("Unable to write to file!", "Error");
        return false;
      }
    }

    private bool checkDontSave()
    {
      if (!this.beenModified)
        return true;
      switch (MessageBox.Show("Do you want to save this effect?", "Save?", MessageBoxButtons.YesNoCancel))
      {
        case DialogResult.Yes:
          return this.saveEffect();
        case DialogResult.No:
          return true;
        default:
          return false;
      }
    }

    private void loadFreeAddrs()
    {
      bool tempDisableChange = this.tempDisableChange;
      this.tempDisableChange = true;
      this.freeAddrListView.Items.Clear();
      foreach (FreeAddr freeAddr in this.scrollingEffect.FreeAddrs)
        this.freeAddrListView.Items.Add(this.generateFreeAddrListViewItem(freeAddr));
      if (this.currentFreeAddr >= this.scrollingEffect.FreeAddrs.Count)
        this.currentFreeAddr = -1;
      else if (this.currentFreeAddr > -1)
        this.freeAddrListView.SelectedIndices.Add(this.currentFreeAddr);
      this.tempDisableChange = tempDisableChange;
    }

    private void loadFreeAddr(FreeAddr freeAddr, int freeAddrNum)
    {
      bool flag = this.freeAddrListView.SelectedIndices.Contains(freeAddrNum);
      this.freeAddrListView.Items[freeAddrNum] = this.generateFreeAddrListViewItem(freeAddr);
      this.tempDisableChange = true;
      this.freeAddrListView.Items[freeAddrNum].Selected = flag;
      this.tempDisableChange = false;
    }

    private void reloadFreeAddr(int freeAddrNum) => this.loadFreeAddr(this.scrollingEffect.FreeAddrs[freeAddrNum], freeAddrNum);

    private ListViewItem generateFreeAddrListViewItem(FreeAddr freeAddr) => new ListViewItem(new string[3]
    {
      "",
      "$" + freeAddr.Addr.ToString("X4"),
      "0x" + ((int) freeAddr.LengthMinusOne + 1).ToString("X")
    });

    private void updateElementEnableStates()
    {
      if (this.scrollingEffect != null)
      {
        this.setFreeAddrEditEnabled(this.currentFreeAddr > -1);
        this.freeAddrListView.Enabled = true;
        this.newButton.Enabled = true;
        this.removeButton.Enabled = true;
        this.optimizeButton.Enabled = true;
        this.checkIfEnoughButton.Enabled = true;
        this.bankTextBox.Enabled = true;
      }
      else
      {
        this.setFreeAddrEditEnabled(false);
        this.freeAddrListView.Enabled = false;
        this.newButton.Enabled = false;
        this.removeButton.Enabled = false;
        this.optimizeButton.Enabled = false;
        this.checkIfEnoughButton.Enabled = false;
        this.bankTextBox.Enabled = false;
      }
    }

    private void selectFreeAddr(int freeAddrNum)
    {
      this.currentFreeAddr = freeAddrNum;
      this.setFreeAddrEditEnabled(freeAddrNum > -1);
      if (freeAddrNum < 0)
        return;
      FreeAddr freeAddr = this.scrollingEffect.FreeAddrs[freeAddrNum];
      this.tempDisableChange = true;
      this.addressTextBox.Text = freeAddr.Addr.ToString("X4");
      this.lengthTextBox.Text = ((int) freeAddr.LengthMinusOne + 1).ToString("X");
      this.tempDisableChange = false;
    }

    private void setFreeAddrEditEnabled(bool enabled)
    {
      this.addressTextBox.Enabled = enabled;
      this.lengthTextBox.Enabled = enabled;
    }

    private void addFreeAddr()
    {
      FreeAddr freeAddr = new FreeAddr((ushort) 0, (ushort) 0);
      this.scrollingEffect.FreeAddrs.Add(freeAddr);
      this.freeAddrListView.Items.Add(this.generateFreeAddrListViewItem(freeAddr));
      this.beenModified = true;
    }

    private void removeFreeAddr(int freeAddrIndex)
    {
      this.scrollingEffect.FreeAddrs.RemoveAt(freeAddrIndex);
      this.freeAddrListView.Items.RemoveAt(freeAddrIndex);
      if (freeAddrIndex == this.currentFreeAddr)
      {
        this.currentFreeAddr = -1;
        this.setFreeAddrEditEnabled(false);
      }
      this.beenModified = true;
    }

    private void removeCurrentFreeAddr()
    {
      this.removeFreeAddr(this.currentFreeAddr);
      this.beenModified = true;
    }

    private void optimizeFreeAddrs()
    {
      this.scrollingEffect.FreeAddrs = FreeAddr.GenerateOptimizedFreeAddrList(this.scrollingEffect.FreeAddrs);
      this.currentFreeAddr = -1;
      this.loadFreeAddrs();
      this.beenModified = true;
    }

    private void ScrollingEffectEditor_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !this.checkDontSave();

    private void freeAddrListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
    {
      e.NewWidth = ((ListView) sender).Columns[e.ColumnIndex].Width;
      e.Cancel = true;
    }

    private void freeAddrListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      ListView.SelectedIndexCollection selectedIndices = ((ListView) sender).SelectedIndices;
      if (selectedIndices.Count <= 0)
        return;
      this.selectFreeAddr(selectedIndices[0]);
    }

    private void newButton_Click(object sender, EventArgs e) => this.addFreeAddr();

    private void removeButton_Click(object sender, EventArgs e)
    {
      if (this.currentFreeAddr < 0)
        return;
      this.removeCurrentFreeAddr();
    }

    private void optimizeButton_Click(object sender, EventArgs e) => this.optimizeFreeAddrs();

    private void checkIfEnoughButton_Click(object sender, EventArgs e)
    {
      try
      {
        CodeGeneration.GenerateScrollingEffectCode(this.scrollingEffect);
      }
      catch (FreeAddr.NotEnoughFreeAddrsException ex)
      {
        int num = (int) MessageBox.Show("Not enough free addresses");
        return;
      }
      int num1 = (int) MessageBox.Show("Enough free addresses");
    }

    private void addressTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int num = Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 0) & (int) ushort.MaxValue;
      textBox.Text = num.ToString("X4");
      FreeAddr freeAddr = this.scrollingEffect.FreeAddrs[this.currentFreeAddr];
      this.scrollingEffect.FreeAddrs.RemoveAt(this.currentFreeAddr);
      freeAddr.Addr = (ushort) num;
      this.scrollingEffect.FreeAddrs.Insert(this.currentFreeAddr, freeAddr);
      this.reloadFreeAddr(this.currentFreeAddr);
      this.beenModified = true;
    }

    private void addressTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.addressTextBox_Leave(sender, (EventArgs) e);
    }

    private void lengthTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int num = Math.Min(Math.Max(Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, 1), 1), 65536);
      textBox.Text = num.ToString("X");
      FreeAddr freeAddr = this.scrollingEffect.FreeAddrs[this.currentFreeAddr];
      this.scrollingEffect.FreeAddrs.RemoveAt(this.currentFreeAddr);
      freeAddr.LengthMinusOne = (ushort) (num - 1);
      this.scrollingEffect.FreeAddrs.Insert(this.currentFreeAddr, freeAddr);
      this.reloadFreeAddr(this.currentFreeAddr);
      this.beenModified = true;
    }

    private void lengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.lengthTextBox_Leave(sender, (EventArgs) e);
    }

    private void bankTextBox_Leave(object sender, EventArgs e)
    {
      if (this.tempDisableChange)
        return;
      TextBox textBox = (TextBox) sender;
      int num = Numbers.IntParseSafe(textBox.Text, NumberStyles.HexNumber, (int) sbyte.MaxValue) & (int) byte.MaxValue;
      textBox.Text = num.ToString("X2");
      this.scrollingEffect.Bank = (byte) num;
      this.beenModified = true;
    }

    private void bankTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.bankTextBox_Leave(sender, (EventArgs) e);
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e) => this.makeNewEffect();

    private void ScrollingEffectEditor_Resize(object sender, EventArgs e)
    {
      this.effectDataParallaxTabControl.Width = this.Width - 40;
      for (int index = 0; index < 4; ++index)
        this.layerElementCollections[index].Width = this.Width - 54;
      this.settingsPanel.Width = this.Width - 48;
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e) => this.openEffect();

    private void saveToolStripMenuItem_Click(object sender, EventArgs e) => this.saveEffect();

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => this.saveEffectAs();

    private void exportCodeToolStripMenuItem_Click(object sender, EventArgs e) => this.exportEffect();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.scanlineColumnHeader = new ColumnHeader();
      this.scrollTableColumnHeader = new ColumnHeader();
      this.speedColumnHeader = new ColumnHeader();
      this.vOffsetBG1TextBox = new TextBox();
      this.vOffsetAddressBG1Label = new Label();
      this.verticalWrapBG1CheckBox = new CheckBox();
      this.compressionBG1CheckBox = new CheckBox();
      this.verticalOffsetBG1CheckBox = new CheckBox();
      this.enableBG1CheckBox = new CheckBox();
      this.scrollTableBG1Label = new Label();
      this.scrollTableBG1ComboBox = new ComboBox();
      this.currentScanlineSpeedBG1Label = new Label();
      this.scrollSpeedBG1TextBox = new TextBox();
      this.inHexBG1Label = new Label();
      this.effectDataParallaxTabControl = new TabControl();
      this.bg1TabPage = new TabPage();
      this.bg2TabPage = new TabPage();
      this.bg3TabPage = new TabPage();
      this.bg4TabPage = new TabPage();
      this.settingsTabPage = new TabPage();
      this.settingsPanel = new Panel();
      this.mainSettingsFrame = new GroupBox();
      this.bankLabel = new Label();
      this.bankTextBox = new TextBox();
      this.currentFreeAddrFrame = new GroupBox();
      this.lengthLabel = new Label();
      this.lengthTextBox = new TextBox();
      this.addressLabel = new Label();
      this.addressTextBox = new TextBox();
      this.checkIfEnoughButton = new Button();
      this.newButton = new Button();
      this.optimizeButton = new Button();
      this.removeButton = new Button();
      this.menuStrip = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new ToolStripMenuItem();
      this.exportCodeToolStripMenuItem = new ToolStripMenuItem();
      this.fileToolStripSeparator = new ToolStripSeparator();
      this.closeToolStripMenuItem = new ToolStripMenuItem();
      this.freeAddrListView = new ListView();
      this.blankColumnHeader = new ColumnHeader();
      this.addressColumnHeader = new ColumnHeader();
      this.lengthColumnHeader = new ColumnHeader();
      this.bg1LayerElementCollection = new ScrollingEffectLayerElementCollection();
      this.bg2LayerElementCollection = new ScrollingEffectLayerElementCollection();
      this.bg3LayerElementCollection = new ScrollingEffectLayerElementCollection();
      this.bg4LayerElementCollection = new ScrollingEffectLayerElementCollection();
      this.effectDataParallaxTabControl.SuspendLayout();
      this.bg1TabPage.SuspendLayout();
      this.bg2TabPage.SuspendLayout();
      this.bg3TabPage.SuspendLayout();
      this.bg4TabPage.SuspendLayout();
      this.settingsTabPage.SuspendLayout();
      this.settingsPanel.SuspendLayout();
      this.mainSettingsFrame.SuspendLayout();
      this.currentFreeAddrFrame.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      this.scanlineColumnHeader.DisplayIndex = 0;
      this.scanlineColumnHeader.Text = "#";
      this.scanlineColumnHeader.Width = 31;
      this.scrollTableColumnHeader.DisplayIndex = 1;
      this.scrollTableColumnHeader.Text = "Tbl";
      this.scrollTableColumnHeader.Width = 36;
      this.speedColumnHeader.DisplayIndex = 2;
      this.speedColumnHeader.Text = "Speed";
      this.speedColumnHeader.Width = 53;
      this.vOffsetBG1TextBox.Enabled = false;
      this.vOffsetBG1TextBox.Location = new Point(100, 113);
      this.vOffsetBG1TextBox.Name = "vOffsetBG1TextBox";
      this.vOffsetBG1TextBox.Size = new Size(48, 20);
      this.vOffsetBG1TextBox.TabIndex = 4;
      this.vOffsetAddressBG1Label.AutoSize = true;
      this.vOffsetAddressBG1Label.Location = new Point(5, 116);
      this.vOffsetAddressBG1Label.Name = "vOffsetAddressBG1Label";
      this.vOffsetAddressBG1Label.Size = new Size(89, 13);
      this.vOffsetAddressBG1Label.TabIndex = 4;
      this.verticalWrapBG1CheckBox.AutoSize = true;
      this.verticalWrapBG1CheckBox.Enabled = false;
      this.verticalWrapBG1CheckBox.Location = new Point(6, 66);
      this.verticalWrapBG1CheckBox.Name = "verticalWrapBG1CheckBox";
      this.verticalWrapBG1CheckBox.Size = new Size(234, 17);
      this.verticalWrapBG1CheckBox.TabIndex = 2;
      this.verticalWrapBG1CheckBox.Text = "Enable Vertical Wrap (takes up more space)";
      this.verticalWrapBG1CheckBox.UseVisualStyleBackColor = true;
      this.compressionBG1CheckBox.AutoSize = true;
      this.compressionBG1CheckBox.Checked = true;
      this.compressionBG1CheckBox.CheckState = CheckState.Checked;
      this.compressionBG1CheckBox.Enabled = false;
      this.compressionBG1CheckBox.Location = new Point(6, 89);
      this.compressionBG1CheckBox.Name = "compressionBG1CheckBox";
      this.compressionBG1CheckBox.Size = new Size(122, 17);
      this.compressionBG1CheckBox.TabIndex = 3;
      this.compressionBG1CheckBox.Text = "Enable Compression";
      this.compressionBG1CheckBox.UseVisualStyleBackColor = true;
      this.verticalOffsetBG1CheckBox.AutoSize = true;
      this.verticalOffsetBG1CheckBox.Checked = true;
      this.verticalOffsetBG1CheckBox.CheckState = CheckState.Checked;
      this.verticalOffsetBG1CheckBox.Enabled = false;
      this.verticalOffsetBG1CheckBox.Location = new Point(6, 42);
      this.verticalOffsetBG1CheckBox.Name = "verticalOffsetBG1CheckBox";
      this.verticalOffsetBG1CheckBox.Size = new Size(248, 17);
      this.verticalOffsetBG1CheckBox.TabIndex = 1;
      this.verticalOffsetBG1CheckBox.Text = "Enable Vertical Scrolling (takes up more space)";
      this.verticalOffsetBG1CheckBox.UseVisualStyleBackColor = true;
      this.enableBG1CheckBox.AutoSize = true;
      this.enableBG1CheckBox.Location = new Point(6, 19);
      this.enableBG1CheckBox.Name = "enableBG1CheckBox";
      this.enableBG1CheckBox.Size = new Size(193, 17);
      this.enableBG1CheckBox.TabIndex = 0;
      this.enableBG1CheckBox.Text = "Enable Parallax HDMA for this layer";
      this.enableBG1CheckBox.UseVisualStyleBackColor = true;
      this.scrollTableBG1Label.AutoSize = true;
      this.scrollTableBG1Label.Location = new Point(6, 23);
      this.scrollTableBG1Label.Name = "scrollTableBG1Label";
      this.scrollTableBG1Label.Size = new Size(66, 13);
      this.scrollTableBG1Label.TabIndex = 0;
      this.scrollTableBG1ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.scrollTableBG1ComboBox.Enabled = false;
      this.scrollTableBG1ComboBox.FormattingEnabled = true;
      this.scrollTableBG1ComboBox.Items.AddRange(new object[2]
      {
        (object) "#1",
        (object) "#2"
      });
      this.scrollTableBG1ComboBox.Location = new Point(82, 20);
      this.scrollTableBG1ComboBox.Name = "scrollTableBG1ComboBox";
      this.scrollTableBG1ComboBox.Size = new Size(40, 21);
      this.scrollTableBG1ComboBox.TabIndex = 0;
      this.currentScanlineSpeedBG1Label.AutoSize = true;
      this.currentScanlineSpeedBG1Label.Location = new Point(6, 51);
      this.currentScanlineSpeedBG1Label.Name = "currentScanlineSpeedBG1Label";
      this.currentScanlineSpeedBG1Label.Size = new Size(70, 13);
      this.currentScanlineSpeedBG1Label.TabIndex = 1;
      this.scrollSpeedBG1TextBox.Enabled = false;
      this.scrollSpeedBG1TextBox.Location = new Point(82, 48);
      this.scrollSpeedBG1TextBox.Name = "scrollSpeedBG1TextBox";
      this.scrollSpeedBG1TextBox.Size = new Size(40, 20);
      this.scrollSpeedBG1TextBox.TabIndex = 1;
      this.inHexBG1Label.AutoSize = true;
      this.inHexBG1Label.Location = new Point(128, 51);
      this.inHexBG1Label.Name = "inHexBG1Label";
      this.inHexBG1Label.Size = new Size(41, 13);
      this.inHexBG1Label.TabIndex = 1;
      this.effectDataParallaxTabControl.Controls.Add((Control) this.bg1TabPage);
      this.effectDataParallaxTabControl.Controls.Add((Control) this.bg2TabPage);
      this.effectDataParallaxTabControl.Controls.Add((Control) this.bg3TabPage);
      this.effectDataParallaxTabControl.Controls.Add((Control) this.bg4TabPage);
      this.effectDataParallaxTabControl.Controls.Add((Control) this.settingsTabPage);
      this.effectDataParallaxTabControl.Location = new Point(12, 27);
      this.effectDataParallaxTabControl.Name = "effectDataParallaxTabControl";
      this.effectDataParallaxTabControl.SelectedIndex = 0;
      this.effectDataParallaxTabControl.Size = new Size(1256, 414);
      this.effectDataParallaxTabControl.TabIndex = 1;
      this.bg1TabPage.Controls.Add((Control) this.bg1LayerElementCollection);
      this.bg1TabPage.Location = new Point(4, 22);
      this.bg1TabPage.Name = "bg1TabPage";
      this.bg1TabPage.Padding = new Padding(3);
      this.bg1TabPage.Size = new Size(1248, 388);
      this.bg1TabPage.TabIndex = 0;
      this.bg1TabPage.Text = "Layer 1";
      this.bg1TabPage.UseVisualStyleBackColor = true;
      this.bg2TabPage.Controls.Add((Control) this.bg2LayerElementCollection);
      this.bg2TabPage.Location = new Point(4, 22);
      this.bg2TabPage.Name = "bg2TabPage";
      this.bg2TabPage.Padding = new Padding(3);
      this.bg2TabPage.Size = new Size(1248, 388);
      this.bg2TabPage.TabIndex = 5;
      this.bg2TabPage.Text = "Layer 2";
      this.bg2TabPage.UseVisualStyleBackColor = true;
      this.bg3TabPage.Controls.Add((Control) this.bg3LayerElementCollection);
      this.bg3TabPage.Location = new Point(4, 22);
      this.bg3TabPage.Name = "bg3TabPage";
      this.bg3TabPage.Size = new Size(1248, 388);
      this.bg3TabPage.TabIndex = 6;
      this.bg3TabPage.Text = "Layer 3";
      this.bg3TabPage.UseVisualStyleBackColor = true;
      this.bg4TabPage.Controls.Add((Control) this.bg4LayerElementCollection);
      this.bg4TabPage.Location = new Point(4, 22);
      this.bg4TabPage.Name = "bg4TabPage";
      this.bg4TabPage.Size = new Size(1248, 388);
      this.bg4TabPage.TabIndex = 7;
      this.bg4TabPage.Text = "Layer 4";
      this.bg4TabPage.UseVisualStyleBackColor = true;
      this.settingsTabPage.Controls.Add((Control) this.settingsPanel);
      this.settingsTabPage.Location = new Point(4, 22);
      this.settingsTabPage.Name = "settingsTabPage";
      this.settingsTabPage.Padding = new Padding(3);
      this.settingsTabPage.Size = new Size(1248, 388);
      this.settingsTabPage.TabIndex = 8;
      this.settingsTabPage.Text = "Free RAM";
      this.settingsTabPage.UseVisualStyleBackColor = true;
      this.settingsPanel.Controls.Add((Control) this.freeAddrListView);
      this.settingsPanel.Controls.Add((Control) this.mainSettingsFrame);
      this.settingsPanel.Controls.Add((Control) this.currentFreeAddrFrame);
      this.settingsPanel.Controls.Add((Control) this.checkIfEnoughButton);
      this.settingsPanel.Controls.Add((Control) this.newButton);
      this.settingsPanel.Controls.Add((Control) this.optimizeButton);
      this.settingsPanel.Controls.Add((Control) this.removeButton);
      this.settingsPanel.Location = new Point(0, 0);
      this.settingsPanel.Name = "settingsPanel";
      this.settingsPanel.Size = new Size(1248, 392);
      this.settingsPanel.TabIndex = 25;
      this.mainSettingsFrame.Controls.Add((Control) this.bankLabel);
      this.mainSettingsFrame.Controls.Add((Control) this.bankTextBox);
      this.mainSettingsFrame.Location = new Point(236, 199);
      this.mainSettingsFrame.Name = "mainSettingsFrame";
      this.mainSettingsFrame.Size = new Size(114, 48);
      this.mainSettingsFrame.TabIndex = 24;
      this.mainSettingsFrame.TabStop = false;
      this.mainSettingsFrame.Text = "Main Settings";
      this.bankLabel.AutoSize = true;
      this.bankLabel.Location = new Point(6, 22);
      this.bankLabel.Name = "bankLabel";
      this.bankLabel.Size = new Size(35, 13);
      this.bankLabel.TabIndex = 24;
      this.bankLabel.Text = "Bank:";
      this.bankTextBox.Enabled = false;
      this.bankTextBox.Location = new Point(60, 19);
      this.bankTextBox.Name = "bankTextBox";
      this.bankTextBox.Size = new Size(48, 20);
      this.bankTextBox.TabIndex = 25;
      this.bankTextBox.KeyPress += new KeyPressEventHandler(this.bankTextBox_KeyPress);
      this.bankTextBox.Leave += new EventHandler(this.bankTextBox_Leave);
      this.currentFreeAddrFrame.Controls.Add((Control) this.lengthLabel);
      this.currentFreeAddrFrame.Controls.Add((Control) this.lengthTextBox);
      this.currentFreeAddrFrame.Controls.Add((Control) this.addressLabel);
      this.currentFreeAddrFrame.Controls.Add((Control) this.addressTextBox);
      this.currentFreeAddrFrame.Location = new Point(236, 6);
      this.currentFreeAddrFrame.Name = "currentFreeAddrFrame";
      this.currentFreeAddrFrame.Size = new Size(114, 71);
      this.currentFreeAddrFrame.TabIndex = 1;
      this.currentFreeAddrFrame.TabStop = false;
      this.currentFreeAddrFrame.Text = "Edit Address";
      this.lengthLabel.AutoSize = true;
      this.lengthLabel.Location = new Point(6, 48);
      this.lengthLabel.Name = "lengthLabel";
      this.lengthLabel.Size = new Size(43, 13);
      this.lengthLabel.TabIndex = 22;
      this.lengthLabel.Text = "Length:";
      this.lengthTextBox.Enabled = false;
      this.lengthTextBox.Location = new Point(60, 45);
      this.lengthTextBox.Name = "lengthTextBox";
      this.lengthTextBox.Size = new Size(48, 20);
      this.lengthTextBox.TabIndex = 23;
      this.lengthTextBox.KeyPress += new KeyPressEventHandler(this.lengthTextBox_KeyPress);
      this.lengthTextBox.Leave += new EventHandler(this.lengthTextBox_Leave);
      this.addressLabel.AutoSize = true;
      this.addressLabel.Location = new Point(6, 22);
      this.addressLabel.Name = "addressLabel";
      this.addressLabel.Size = new Size(48, 13);
      this.addressLabel.TabIndex = 20;
      this.addressLabel.Text = "Address:";
      this.addressTextBox.Enabled = false;
      this.addressTextBox.Location = new Point(60, 19);
      this.addressTextBox.Name = "addressTextBox";
      this.addressTextBox.Size = new Size(48, 20);
      this.addressTextBox.TabIndex = 21;
      this.addressTextBox.KeyPress += new KeyPressEventHandler(this.addressTextBox_KeyPress);
      this.addressTextBox.Leave += new EventHandler(this.addressTextBox_Leave);
      this.checkIfEnoughButton.Enabled = false;
      this.checkIfEnoughButton.Location = new Point(236, 170);
      this.checkIfEnoughButton.Name = "checkIfEnoughButton";
      this.checkIfEnoughButton.Size = new Size(114, 23);
      this.checkIfEnoughButton.TabIndex = 2;
      this.checkIfEnoughButton.Text = "Check If Enough";
      this.checkIfEnoughButton.UseVisualStyleBackColor = true;
      this.checkIfEnoughButton.Click += new EventHandler(this.checkIfEnoughButton_Click);
      this.newButton.Enabled = false;
      this.newButton.Location = new Point(236, 83);
      this.newButton.Name = "newButton";
      this.newButton.Size = new Size(114, 23);
      this.newButton.TabIndex = 2;
      this.newButton.Text = "New Address";
      this.newButton.UseVisualStyleBackColor = true;
      this.newButton.Click += new EventHandler(this.newButton_Click);
      this.optimizeButton.Enabled = false;
      this.optimizeButton.Location = new Point(236, 141);
      this.optimizeButton.Name = "optimizeButton";
      this.optimizeButton.Size = new Size(114, 23);
      this.optimizeButton.TabIndex = 2;
      this.optimizeButton.Text = "Optimize List";
      this.optimizeButton.UseVisualStyleBackColor = true;
      this.optimizeButton.Click += new EventHandler(this.optimizeButton_Click);
      this.removeButton.Enabled = false;
      this.removeButton.Location = new Point(236, 112);
      this.removeButton.Name = "removeButton";
      this.removeButton.Size = new Size(114, 23);
      this.removeButton.TabIndex = 2;
      this.removeButton.Text = "Remove";
      this.removeButton.UseVisualStyleBackColor = true;
      this.removeButton.Click += new EventHandler(this.removeButton_Click);
      this.menuStrip.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.fileToolStripMenuItem
      });
      this.menuStrip.Location = new Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new Size(1280, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.newToolStripMenuItem,
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.saveAsToolStripMenuItem,
        (ToolStripItem) this.exportCodeToolStripMenuItem,
        (ToolStripItem) this.fileToolStripSeparator,
        (ToolStripItem) this.closeToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = Keys.N | Keys.Control;
      this.newToolStripMenuItem.Size = new Size(192, 22);
      this.newToolStripMenuItem.Text = "&New";
      this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
      this.openToolStripMenuItem.Size = new Size(192, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Control;
      this.saveToolStripMenuItem.Size = new Size(192, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
      this.saveAsToolStripMenuItem.Size = new Size(192, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As";
      this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
      this.exportCodeToolStripMenuItem.Name = "exportCodeToolStripMenuItem";
      this.exportCodeToolStripMenuItem.ShortcutKeys = Keys.E | Keys.Control;
      this.exportCodeToolStripMenuItem.Size = new Size(192, 22);
      this.exportCodeToolStripMenuItem.Text = "G&enerate Code";
      this.exportCodeToolStripMenuItem.Click += new EventHandler(this.exportCodeToolStripMenuItem_Click);
      this.fileToolStripSeparator.Name = "fileToolStripSeparator";
      this.fileToolStripSeparator.Size = new Size(189, 6);
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.ShortcutKeys = Keys.W | Keys.Control;
      this.closeToolStripMenuItem.Size = new Size(192, 22);
      this.closeToolStripMenuItem.Text = "&Close";
      this.freeAddrListView.Columns.AddRange(new ColumnHeader[3]
      {
        this.blankColumnHeader,
        this.addressColumnHeader,
        this.lengthColumnHeader
      });
      this.freeAddrListView.Enabled = false;
      this.freeAddrListView.FullRowSelect = true;
      this.freeAddrListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.freeAddrListView.HideSelection = false;
      this.freeAddrListView.Location = new Point(6, 6);
      this.freeAddrListView.MultiSelect = false;
      this.freeAddrListView.Name = "freeAddrListView";
      this.freeAddrListView.Size = new Size(224, 376);
      this.freeAddrListView.TabIndex = 25;
      this.freeAddrListView.UseCompatibleStateImageBehavior = false;
      this.freeAddrListView.View = View.Details;
      this.freeAddrListView.ColumnWidthChanging += new ColumnWidthChangingEventHandler(this.freeAddrListView_ColumnWidthChanging);
      this.freeAddrListView.SelectedIndexChanged += new EventHandler(this.freeAddrListView_SelectedIndexChanged);
      this.blankColumnHeader.Width = 0;
      this.addressColumnHeader.Text = "Address";
      this.addressColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.addressColumnHeader.Width = 110;
      this.lengthColumnHeader.Text = "Length";
      this.lengthColumnHeader.TextAlign = HorizontalAlignment.Center;
      this.lengthColumnHeader.Width = 110;
      this.bg1LayerElementCollection.Location = new Point(3, 3);
      this.bg1LayerElementCollection.Name = "bg1LayerElementCollection";
      this.bg1LayerElementCollection.Size = new Size(1242, 381);
      this.bg1LayerElementCollection.TabIndex = 0;
      this.bg2LayerElementCollection.Location = new Point(3, 3);
      this.bg2LayerElementCollection.Name = "bg2LayerElementCollection";
      this.bg2LayerElementCollection.Size = new Size(1242, 381);
      this.bg2LayerElementCollection.TabIndex = 0;
      this.bg3LayerElementCollection.Location = new Point(3, 3);
      this.bg3LayerElementCollection.Name = "bg3LayerElementCollection";
      this.bg3LayerElementCollection.Size = new Size(1242, 381);
      this.bg3LayerElementCollection.TabIndex = 2;
      this.bg4LayerElementCollection.Location = new Point(3, 3);
      this.bg4LayerElementCollection.Name = "bg4LayerElementCollection";
      this.bg4LayerElementCollection.Size = new Size(1242, 381);
      this.bg4LayerElementCollection.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1280, 453);
      this.Controls.Add((Control) this.effectDataParallaxTabControl);
      this.Controls.Add((Control) this.menuStrip);
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1296, 491);
      this.MinimumSize = new Size(404, 491);
      this.Name = nameof (ScrollingEffectEditor);
      this.FormClosing += new FormClosingEventHandler(this.ScrollingEffectEditor_FormClosing);
      this.Resize += new EventHandler(this.ScrollingEffectEditor_Resize);
      this.effectDataParallaxTabControl.ResumeLayout(false);
      this.bg1TabPage.ResumeLayout(false);
      this.bg2TabPage.ResumeLayout(false);
      this.bg3TabPage.ResumeLayout(false);
      this.bg4TabPage.ResumeLayout(false);
      this.settingsTabPage.ResumeLayout(false);
      this.settingsPanel.ResumeLayout(false);
      this.mainSettingsFrame.ResumeLayout(false);
      this.mainSettingsFrame.PerformLayout();
      this.currentFreeAddrFrame.ResumeLayout(false);
      this.currentFreeAddrFrame.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
