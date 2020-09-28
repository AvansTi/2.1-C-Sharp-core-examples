namespace LoadWebsitesAsync
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
            this.btn_LoadSync = new System.Windows.Forms.Button();
            this.btn_LoadAsync = new System.Windows.Forms.Button();
            this.txt_Logging = new System.Windows.Forms.TextBox();
            this.btn_LoadParallelAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LoadSync
            // 
            this.btn_LoadSync.Location = new System.Drawing.Point(13, 24);
            this.btn_LoadSync.Name = "btn_LoadSync";
            this.btn_LoadSync.Size = new System.Drawing.Size(172, 23);
            this.btn_LoadSync.TabIndex = 0;
            this.btn_LoadSync.Text = "Load sync";
            this.btn_LoadSync.UseVisualStyleBackColor = true;
            this.btn_LoadSync.Click += new System.EventHandler(this.Btn_LoadSync_Click);
            // 
            // btn_LoadAsync
            // 
            this.btn_LoadAsync.Location = new System.Drawing.Point(13, 54);
            this.btn_LoadAsync.Name = "btn_LoadAsync";
            this.btn_LoadAsync.Size = new System.Drawing.Size(172, 23);
            this.btn_LoadAsync.TabIndex = 1;
            this.btn_LoadAsync.Text = "Load async";
            this.btn_LoadAsync.UseVisualStyleBackColor = true;
            this.btn_LoadAsync.Click += new System.EventHandler(this.Btn_LoadAsync_Click);
            // 
            // txt_Logging
            // 
            this.txt_Logging.Location = new System.Drawing.Point(13, 122);
            this.txt_Logging.Multiline = true;
            this.txt_Logging.Name = "txt_Logging";
            this.txt_Logging.Size = new System.Drawing.Size(775, 316);
            this.txt_Logging.TabIndex = 2;
            // 
            // btn_LoadParallelAsync
            // 
            this.btn_LoadParallelAsync.Location = new System.Drawing.Point(13, 83);
            this.btn_LoadParallelAsync.Name = "btn_LoadParallelAsync";
            this.btn_LoadParallelAsync.Size = new System.Drawing.Size(172, 23);
            this.btn_LoadParallelAsync.TabIndex = 3;
            this.btn_LoadParallelAsync.Text = "Load parallel async";
            this.btn_LoadParallelAsync.UseVisualStyleBackColor = true;
            this.btn_LoadParallelAsync.Click += new System.EventHandler(this.Btn_LoadParallelAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_LoadParallelAsync);
            this.Controls.Add(this.txt_Logging);
            this.Controls.Add(this.btn_LoadAsync);
            this.Controls.Add(this.btn_LoadSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadSync;
        private System.Windows.Forms.Button btn_LoadAsync;
        private System.Windows.Forms.TextBox txt_Logging;
        private System.Windows.Forms.Button btn_LoadParallelAsync;
    }
}

