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
            this.btnMain = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMain.Font = new System.Drawing.Font("微軟正黑體", 400.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMain.Location = new System.Drawing.Point(0, 30);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(801, 421);
            this.btnMain.TabIndex = 0;
            this.btnMain.Text = "A a";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FToolStripMenuItem
            // 
            this.FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IToolStripMenuItem,
            this.toolStripSeparator,
            this.XToolStripMenuItem});
            this.FToolStripMenuItem.Name = "FToolStripMenuItem";
            this.FToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.FToolStripMenuItem.Text = "檔案(&F)";
            this.FToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FToolStripMenuItem_DropDownItemClicked);
            // 
            // IToolStripMenuItem
            // 
            this.IToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IToolStripMenuItem.Image")));
            this.IToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IToolStripMenuItem.Name = "IToolStripMenuItem";
            this.IToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.IToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.IToolStripMenuItem.Tag = "I";
            this.IToolStripMenuItem.Text = "載入檔案(&I)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(212, 6);
            // 
            // XToolStripMenuItem
            // 
            this.XToolStripMenuItem.Name = "XToolStripMenuItem";
            this.XToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.XToolStripMenuItem.Tag = "X";
            this.XToolStripMenuItem.Text = "結束(&X)";
            // 
            // TToolStripMenuItem
            // 
            this.TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CToolStripMenuItem,
            this.OToolStripMenuItem,
            this.RToolStripMenuItem});
            this.TToolStripMenuItem.Name = "TToolStripMenuItem";
            this.TToolStripMenuItem.Size = new System.Drawing.Size(101, 23);
            this.TToolStripMenuItem.Text = "排列順序(&T)";
            this.TToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TToolStripMenuItem_DropDownItemClicked);
            // 
            // CToolStripMenuItem
            // 
            this.CToolStripMenuItem.Name = "CToolStripMenuItem";
            this.CToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.CToolStripMenuItem.Tag = "C";
            this.CToolStripMenuItem.Text = "順向(&C)";
            // 
            // OToolStripMenuItem
            // 
            this.OToolStripMenuItem.Name = "OToolStripMenuItem";
            this.OToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.OToolStripMenuItem.Tag = "O";
            this.OToolStripMenuItem.Text = "逆向(&O)";
            // 
            // RToolStripMenuItem
            // 
            this.RToolStripMenuItem.Name = "RToolStripMenuItem";
            this.RToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.RToolStripMenuItem.Tag = "R";
            this.RToolStripMenuItem.Text = "隨機排列(&R)";
            // 
            // FlashCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FlashCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "閃卡遊戲";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FlashCardForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FlashCardForm_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FlashCardForm_PreviewKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

