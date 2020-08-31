using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.btnMain.Text = this.WordSet.GetCurrentWord();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            //按空白鍵也會觸發
            this.btnMain.Text = this.WordSet.GetNextWord();
        }

        private void FlashCardForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar) 
            {
                case 'A':
                case 'a':
                    this.btnMain.Text = this.WordSet.GetPreviousWord();
                    break;
                case 'D':
                case 'd':
                    this.btnMain.Text = this.WordSet.GetNextWord();
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

            this.btnMain.Text = this.WordSet.GetCurrentWord();
        }

        private void FToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag)
            {
                case "I":
                    break;
                case "X":
                    this.Close();
                    break;
            }
        }
    }
}
