using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlashCard
{
    public partial class FlashCardForm : Form
    {
        private readonly WordSet WordSet;
        private readonly Font ImageFont;

        public FlashCardForm()
        {
            InitializeComponent();
            this.ImageFont = new Font(FontFamily.GenericSansSerif, 1000);

            //讀取先前的設定值.
            this.WordSet = new WordSet(FileSetting.LoadFileSetting());
        }


        private void FlashCardForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ' ':
                    ShowWord(this.WordSet.GetNextWord());
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

        private void FToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag)
            {
                case "O":
                    ImportFile();
                    break;
                case "X":
                    this.Close();
                    break;
                default:
                    WordSet.ImportFile(e.ClickedItem.Tag.ToString());
                    ShowWord();
                    SetSortTypeChecked();
                    break;
            }
        }

        private void ShowWord(string word = "")
        {
            if (string.IsNullOrEmpty(word))
            {
                word = this.WordSet.GetCurrentWord();
            }

            //將文字轉換為圖檔.
            this.picBoxMain.Image = ImageHelper.TextToBitmap(word, this.ImageFont, Rectangle.Empty, Color.Blue, this.BackColor);
        }

        private void ImportFile()
        {
            // 指定開啟的預設路徑
            if(string.IsNullOrWhiteSpace(openFileDialog1.InitialDirectory))
            {
                openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WordSet.ImportFile(openFileDialog1.FileName);
                ShowWord();
                SetSortTypeChecked();
            }
        }

        // 將目前所在路徑的全部卡片檔案(*.txt)都讀入到menu上
        private void LoadFilesToMenu()
        {
            DirectoryInfo folder = new DirectoryInfo(Directory.GetCurrentDirectory());
            int pos = 2;
            
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

            // 最後一行分隔線
            ToolStripSeparator sepline = new ToolStripSeparator();
            FToolStripMenuItem.DropDownItems.Insert(pos, sepline);
        }

        private void InsertFileToMenu(FileInfo file, int pos)
        {
            var menuItem = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(file.Name));
            menuItem.Tag = file.FullName;
            FToolStripMenuItem.DropDownItems.Insert(pos, menuItem);
        }

        private void FlashCardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileSetting.SaveFileSetting(this.WordSet.Setting);
        }

        private void SetSortTypeChecked()
        {
            // 先全部清掉 Checked.
            OriginalSortMenuItem.Checked = false;
            ReverseSortMenuItem.Checked = false;
            RandomSortMenuItem.Checked = false;
            
            // 獲取目前的排序方式.
            switch(this.WordSet.Setting.SortType)
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
    }
}
