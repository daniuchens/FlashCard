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
            LoadFilesToMenu();
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
            }
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
                    WordSet.ImportFile(e.ClickedItem.Tag.ToString());
                    ShowWord();
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
            }
        }

        private void InsertFileToMenu(FileInfo file, int pos)
        {
            var menuItem = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(file.Name));
            menuItem.Tag = file.FullName;
            FToolStripMenuItem.DropDownItems.Insert(pos, menuItem);
        }

        // 將目前所在路徑的全部卡片檔案(*.txt)都讀入到menu上
        private void LoadFilesToMenu()
        {
            DirectoryInfo folder = new DirectoryInfo(Directory.GetCurrentDirectory());
            int pos = 3;

            foreach (var file in folder.GetFiles("*.txt"))
            {
                InsertFileToMenu(file, pos);
                pos++;
            }

            foreach (var file in folder.GetFiles("*.csv"))
            {
                InsertFileToMenu(file, pos);
                pos++;
            }

            // 最後一行分隔線(有抓到檔案才畫)
            if (pos > 3)
            {
                ToolStripSeparator sepline = new ToolStripSeparator();
                FToolStripMenuItem.DropDownItems.Insert(pos, sepline);
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
            switch(e.ClickedItem.Tag)
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