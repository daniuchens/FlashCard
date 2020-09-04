namespace FlashCard
{
    partial class FlashCardForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlashCardForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OriginalSortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReverseSortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomSortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picBoxMain = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FToolStripMenuItem,
            this.TToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FToolStripMenuItem
            // 
            this.FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenuItem,
            this.toolStripSeparator,
            this.XToolStripMenuItem});
            this.FToolStripMenuItem.Name = "FToolStripMenuItem";
            this.FToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.FToolStripMenuItem.Text = "檔案(&F)";
            this.FToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FToolStripMenuItem_DropDownItemClicked);
            // 
            // OpenFileMenuItem
            // 
            this.OpenFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileMenuItem.Image")));
            this.OpenFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileMenuItem.Size = new System.Drawing.Size(231, 26);
            this.OpenFileMenuItem.Tag = "O";
            this.OpenFileMenuItem.Text = "載入檔案(&O)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(228, 6);
            // 
            // XToolStripMenuItem
            // 
            this.XToolStripMenuItem.Name = "XToolStripMenuItem";
            this.XToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.XToolStripMenuItem.Tag = "X";
            this.XToolStripMenuItem.Text = "結束(&X)";
            // 
            // TToolStripMenuItem
            // 
            this.TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OriginalSortMenuItem,
            this.ReverseSortMenuItem,
            this.RandomSortMenuItem});
            this.TToolStripMenuItem.Name = "TToolStripMenuItem";
            this.TToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.TToolStripMenuItem.Text = "排列順序(&S)";
            this.TToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TToolStripMenuItem_DropDownItemClicked);
            // 
            // OriginalSortMenuItem
            // 
            this.OriginalSortMenuItem.Name = "OriginalSortMenuItem";
            this.OriginalSortMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.OriginalSortMenuItem.Size = new System.Drawing.Size(231, 26);
            this.OriginalSortMenuItem.Tag = "C";
            this.OriginalSortMenuItem.Text = "順向(&C)";
            // 
            // ReverseSortMenuItem
            // 
            this.ReverseSortMenuItem.Name = "ReverseSortMenuItem";
            this.ReverseSortMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ReverseSortMenuItem.Size = new System.Drawing.Size(231, 26);
            this.ReverseSortMenuItem.Tag = "R";
            this.ReverseSortMenuItem.Text = "逆向(&R)";
            // 
            // RandomSortMenuItem
            // 
            this.RandomSortMenuItem.Name = "RandomSortMenuItem";
            this.RandomSortMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.RandomSortMenuItem.Size = new System.Drawing.Size(231, 26);
            this.RandomSortMenuItem.Tag = "N";
            this.RandomSortMenuItem.Text = "隨機排列(&N)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "文字檔案|*.txt|CSV檔案|*.csv";
            // 
            // picBoxMain
            // 
            this.picBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxMain.Location = new System.Drawing.Point(0, 30);
            this.picBoxMain.Name = "picBoxMain";
            this.picBoxMain.Size = new System.Drawing.Size(800, 421);
            this.picBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxMain.TabIndex = 2;
            this.picBoxMain.TabStop = false;
            this.picBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxMain_MouseDown);
            // 
            // FlashCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBoxMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FlashCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "閃卡遊戲";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlashCardForm_FormClosing);
            this.Load += new System.EventHandler(this.FlashCardForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FlashCardForm_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FlashCardForm_PreviewKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OriginalSortMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReverseSortMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomSortMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picBoxMain;
    }
}

