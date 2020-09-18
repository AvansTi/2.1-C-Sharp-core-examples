namespace MemeGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btn_GenerateMeme = new System.Windows.Forms.Button();
            this.txt_EnterTopText = new System.Windows.Forms.TextBox();
            this.lbl_EnterTopText = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_TopText = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.memeModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memeModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 419);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.btn_GenerateMeme);
            this.pnlBottom.Controls.Add(this.txt_EnterTopText);
            this.pnlBottom.Controls.Add(this.lbl_EnterTopText);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 447);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(876, 100);
            this.pnlBottom.TabIndex = 1;
            // 
            // btn_GenerateMeme
            // 
            this.btn_GenerateMeme.Location = new System.Drawing.Point(591, 12);
            this.btn_GenerateMeme.Name = "btn_GenerateMeme";
            this.btn_GenerateMeme.Size = new System.Drawing.Size(88, 23);
            this.btn_GenerateMeme.TabIndex = 2;
            this.btn_GenerateMeme.Text = "Generate";
            this.btn_GenerateMeme.UseVisualStyleBackColor = true;
            this.btn_GenerateMeme.Click += new System.EventHandler(this.btn_GenerateMeme_Click);
            // 
            // txt_EnterTopText
            // 
            this.txt_EnterTopText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memeModelBindingSource, "TopText", true));
            this.txt_EnterTopText.Location = new System.Drawing.Point(168, 14);
            this.txt_EnterTopText.Name = "txt_EnterTopText";
            this.txt_EnterTopText.Size = new System.Drawing.Size(407, 22);
            this.txt_EnterTopText.TabIndex = 1;
            this.txt_EnterTopText.TextChanged += new System.EventHandler(this.txt_EnterTopText_TextChanged);
            // 
            // lbl_EnterTopText
            // 
            this.lbl_EnterTopText.AutoSize = true;
            this.lbl_EnterTopText.Location = new System.Drawing.Point(12, 14);
            this.lbl_EnterTopText.Name = "lbl_EnterTopText";
            this.lbl_EnterTopText.Size = new System.Drawing.Size(149, 17);
            this.lbl_EnterTopText.TabIndex = 0;
            this.lbl_EnterTopText.Text = "Vul hier de toptekst in:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // lbl_TopText
            // 
            this.lbl_TopText.AutoSize = true;
            this.lbl_TopText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TopText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memeModelBindingSource, "TopText", true));
            this.lbl_TopText.Font = new System.Drawing.Font("Comic Sans MS", 40.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TopText.ForeColor = System.Drawing.Color.Purple;
            this.lbl_TopText.Location = new System.Drawing.Point(41, 63);
            this.lbl_TopText.Name = "lbl_TopText";
            this.lbl_TopText.Size = new System.Drawing.Size(391, 96);
            this.lbl_TopText.TabIndex = 3;
            this.lbl_TopText.Text = "TOP TEXT";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(591, 42);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // memeModelBindingSource
            // 
            this.memeModelBindingSource.DataSource = typeof(MemeGenerator.Models.MemeModel);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 547);
            this.Controls.Add(this.lbl_TopText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memeModelBindingSource, "TopText", true));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Meme generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memeModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label lbl_TopText;
        private System.Windows.Forms.Button btn_GenerateMeme;
        private System.Windows.Forms.TextBox txt_EnterTopText;
        private System.Windows.Forms.Label lbl_EnterTopText;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.BindingSource memeModelBindingSource;
    }
}

