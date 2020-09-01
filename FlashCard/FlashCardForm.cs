using System;
using System.IO;
using System.Windows.Forms;

namespace FlashCard
{
    public partial class FlashCardForm : Form
    {
        private readonly WordSet WordSet;

        public FlashCardForm()
        {
            InitializeComponent();
            this.WordSet = new WordSet();
            ShowWord();

            LoadFilesToMenu();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            //按空白鍵也會觸發
            ShowWord(this.WordSet.GetNextWord());
        }

        private void FlashCardForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar) 
            {
                case 'A':
                case 'a':
                    ShowWord(this.WordSet.GetPreviousWord());
                    break;
                case 'D':
                case 'd':
                    ShowWord(this.WordSet.GetNextWord());
                    break;
            }

            e.Handled = true;
        }

        private void FlashCardForm_Load(object sender, EventArgs e)
        {
            //this.BringToFront();
            //this.Focus();
            this.KeyPreview = true;
        }

        private void FlashCardForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Down:
            //    case Keys.Up:
            //    case Keys.Left:
            //    case Keys.Right:
            //        e.IsInputKey = true;
            //        break;
            //}
        }

        private void TToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Tag)
            {
                case "C":
                    WordSet.OriginalSort();
                    break;
                case "O":
                    WordSet.ReverseSort();
                    break;
                case "R":
                    WordSet.RandomSort();
                    break;
            }

            ShowWord();
        }

        private void FToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag)
            {
                case "I":
                    ImportFile();
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

        private void ShowWord(string word = "")
        {
            if (string.IsNullOrEmpty(word))
            {
                word = this.WordSet.GetCurrentWord();
            }

            this.btnMain.Text = word;
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
            }
        }

        // 將目前所在路徑的全部卡片檔案(*.txt)都讀入到menu上
        private void LoadFilesToMenu()
        {
            DirectoryInfo folder = new DirectoryInfo(Directory.GetCurrentDirectory());
            int pos = 2;
            foreach (var file in folder.GetFiles("*.txt"))
            {
                var menuItem = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(file.Name));
                menuItem.Tag = file.FullName;
                FToolStripMenuItem.DropDownItems.Insert(pos, menuItem);
                pos++;
            }

            // 最後一行分隔線
            ToolStripSeparator sepline = new ToolStripSeparator();
            FToolStripMenuItem.DropDownItems.Insert(pos, sepline);
        }
    }
}
