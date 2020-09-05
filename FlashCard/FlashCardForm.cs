using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlashCard
{
    public partial class FlashCardForm : Form
    {
        private readonly Font ImageFont;
        private readonly WordSet WordSet;
        private bool IsFullScreen = false;
        private ScreenInfo FormInfo;
        private ScreenInfo PicMainInfo;

        public FlashCardForm()
        {
            InitializeComponent();
            this.ImageFont = new Font(FontFamily.GenericSansSerif, 1000);

            //讀取先前的設定值.
            this.WordSet = new WordSet(FileSetting.Load());
        }

        private void FlashCardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileSetting.Save(this.WordSet.Setting);
        }

        private void FlashCardForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ' ':
                    ShowWord(this.WordSet.GetNextWord());
                    e.Handled = true;
                    break;

                case '0':
                    ShowWord(this.WordSet.GetFirstWord());
                    e.Handled = true;
                    break;
            }
        }

        private void FlashCardForm_Load(object sender, EventArgs e)
        {
            ShowWord();
            LoadRecentPathToMenu();
            SetSortTypeChecked();
        }

        private void FlashCardForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Left:
                    ShowWord(this.WordSet.GetPreviousWord());
                    break;

                case Keys.Down:
                case Keys.Right:
                    ShowWord(this.WordSet.GetNextWord());
                    break;

                case Keys.F11:
                    SetFullScreen();
                    break;
            }
        }

        private void SetFullScreen()
        {
            Rectangle rect = Screen.GetBounds(this);
            if (IsFullScreen)
            {
                // 取消全屏
                FormBorderStyle = FormBorderStyle.Sizable;
                picBoxMain.Dock = DockStyle.None;
                
                FormInfo.CopyToControl(this);
                PicMainInfo.CopyToControl(picBoxMain);

                picBoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                menuStrip1.Show();
            }
            else
            {
                //記住先前的值.
                FormInfo = new ScreenInfo(this);
                PicMainInfo = new ScreenInfo(picBoxMain);

                // 設置全屏
                FormBorderStyle = FormBorderStyle.None;
                picBoxMain.Dock = DockStyle.Fill;

                Location = new Point(0, 0);
                Width = rect.Width;
                Height = rect.Height;
                
                picBoxMain.Location = new Point(0, 0);
                picBoxMain.Width = rect.Width;
                picBoxMain.Height = rect.Height;

                menuStrip1.GripStyle = ToolStripGripStyle.Hidden;

                menuStrip1.Hide();
            }

            IsFullScreen = !IsFullScreen;
        }

        private void FToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag)
            {
                case "O":
                    ImportFile();
                    break;

                case "M":
                    ImportImageFolder();
                    break;

                case "X":
                    this.Close();
                    break;

                default:
                    WordPath wordPath = this.WordSet.Setting.RecentPaths[(int)e.ClickedItem.Tag];
                    if (wordPath.PathMode == DisplayMode.ImageFolder)
                    {
                        WordSet.ImportImageFolder(wordPath.Path);
                    }
                    else
                    {
                        WordSet.ImportFile(wordPath.Path);
                    }

                    ShowWord();
                    LoadRecentPathToMenu();
                    break;
            }
        }

        private void ImportFile()
        {
            // 指定開啟的預設路徑
            if (string.IsNullOrWhiteSpace(openFileDialog1.InitialDirectory))
            {
                openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WordSet.ImportFile(openFileDialog1.FileName);
                ShowWord();
                LoadRecentPathToMenu();
            }
        }

        private void ImportImageFolder()
        {
            // 指定開啟的預設路徑
            if (string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory();
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                WordSet.ImportImageFolder(folderBrowserDialog1.SelectedPath);
                ShowWord();
                LoadRecentPathToMenu();
            }
        }

        private void LoadRecentPathToMenu()
        {
            if (this.WordSet.Setting.RecentPaths == null)
            {
                return;
            }

            // 清掉先前的
            int pos = FToolStripMenuItem.DropDownItems.IndexOfKey("toolStripSeparator") + 1;
            int length = FToolStripMenuItem.DropDownItems.Count - pos - 1;
            for (int j = 0; j < length; j++)
            {
                FToolStripMenuItem.DropDownItems.RemoveAt(pos);
            }

            //依照目前的設定重畫
            int i = 0;
            foreach (WordPath item in this.WordSet.Setting.RecentPaths)
            {
                var menuItem = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(item.Path));
                menuItem.Tag = i;
                menuItem.Image = ImageHelper.GetExtImage(item);
                menuItem.ImageTransparentColor = Color.White;
                FToolStripMenuItem.DropDownItems.Insert(pos + i, menuItem);
                i++;
            }

            // 最後一行分隔線(有抓到檔案才畫)
            if (i > 0)
            {
                ToolStripSeparator sepline = new ToolStripSeparator();
                FToolStripMenuItem.DropDownItems.Insert(pos + i, sepline);
            }
        }

        private void picBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ShowWord(this.WordSet.GetNextWord());
                    break;

                case MouseButtons.Right:
                    ShowWord(this.WordSet.GetPreviousWord());
                    break;
            }
        }

        private void SetSortTypeChecked()
        {
            // 先全部清掉 Checked.
            OriginalSortMenuItem.Checked = false;
            ReverseSortMenuItem.Checked = false;
            RandomSortMenuItem.Checked = false;

            // 獲取目前的排序方式.
            switch (this.WordSet.Setting.SortType)
            {
                case SortType.Random:
                    RandomSortMenuItem.Checked = true;
                    break;

                case SortType.Reverse:
                    ReverseSortMenuItem.Checked = true;
                    break;

                default:
                    OriginalSortMenuItem.Checked = true;
                    break;
            }
        }

        private void ShowWord(string word = "")
        {
            if (string.IsNullOrEmpty(word))
            {
                word = this.WordSet.GetCurrentWord();
            }

            if (this.WordSet.Setting.DisplayMode == DisplayMode.ImageFolder)
            {
                //讀取該路徑的圖檔
                this.picBoxMain.Load(word);
            }
            else
            {
                //將文字轉換為圖檔.
                this.picBoxMain.Image = ImageHelper.TextToBitmap(word, this.ImageFont, Rectangle.Empty, Color.Green, this.BackColor);
            }
        }

        private void TToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag)
            {
                case "C":
                    WordSet.OriginalSort();
                    break;

                case "R":
                    WordSet.ReverseSort();
                    break;

                case "N":
                    WordSet.RandomSort();
                    break;
            }

            ShowWord();
            SetSortTypeChecked();
        }
    }
}